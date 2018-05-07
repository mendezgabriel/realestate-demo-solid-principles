using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateDemo.BusinessInterfaces;
using RealEstateDemo.Common;
using RealEstateDemo.Common.Extensions;
using RealEstateDemo.Domain;

namespace RealEstateDemo.WebUI.Controllers
{
	/// <summary>
	/// Provides server-side logic for the portions of the UI that relate to real estate properties.
	/// </summary>
    public class PropertyController : Controller
    {
		readonly IPropertyProcessor propertyProcessor;

		/// <summary>
		/// Creates a new instance of this.
		/// </summary>
		/// <param name="propertyProcessor">How to process property-related data according to business rules.</param>
		public PropertyController(IPropertyProcessor propertyProcessor)
		{
			this.propertyProcessor = propertyProcessor;
		}

        /// <summary>
        /// Renders the search view.
        /// </summary>
        /// <returns>The view.</returns>
        public ActionResult Search()
        {
            var model = new SearchViewModel
            {
                PriceRangeValues = GetPriceRangeValues()
            };
            return View(model);
        }

        /// <summary>
        /// Renders the results view.
        /// </summary>
        /// <returns>The view.</returns>
        public ActionResult Results(string suburbId, string minPrice, string maxPrice)
		{
            var Id = suburbId.GetDecimalValueOrDefault();
            var minimumPrice = minPrice.GetDecimalValueOrDefault();
            var maximumPrice = maxPrice.GetDecimalValueOrDefault();

            var suburb = new Suburb
            {
                Id = (int)Id
            };
            var priceRange = new PriceRange(minimumPrice, maximumPrice);
            var model = propertyProcessor.FindMatchingPropertiesBy(suburb, priceRange);

            return View(model);
		}

        /// <summary>
        /// Renders the details view.
        /// </summary>
        /// <returns>The view.</returns>
		public ActionResult Details(int Id)
		{
            var model = propertyProcessor.FindBy(Id);
			return View(model);
		}

        /// <summary>
        /// Adds a new enquiry to a specified property.
        /// </summary>
        /// <param name="form">The form objects.</param>
        /// <returns>The view.</returns>
        [HttpPost]
        public ActionResult AddEnquiry(FormCollection form)
        {
            var propertyId = form["propertyId"];
            var email = form["email"];
            var body = form["body"];

            var property = new Property
            {
                Id = int.Parse(propertyId)
            };

            var enquiry = new Enquiry
            {
                ContactEmail = email,
                Body = body
            };

            propertyProcessor.AddEnquiry(property, enquiry);

            return RedirectToAction("ThankYou");
        }

        /// <summary>
        /// Renders the thank you view.
        /// </summary>
        /// <returns>The view.</returns>
		public ActionResult ThankYou()
		{
			return View();
		}

        /// <summary>
        /// Helper action method for the autocomplete function for the search page.
        /// </summary>
        /// <param name="searchText">The text used to filter the locations.</param>
        /// <returns>A collection of locations in Json format.</returns>
        public JsonResult AutoCompleteSuburb(string searchText)
        {
            var locations = propertyProcessor.FindMathingLocationsBy(searchText);
            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Provides the model for the search view.
        /// </summary>
        public class SearchViewModel
        {
            public List<SelectListItem> PriceRangeValues { get; set; }
        }

        /// <summary>
        /// Gets a collection of values to be used as the pricing choice options.
        /// </summary>
        /// <returns>The collection.</returns>
        private List<SelectListItem> GetPriceRangeValues()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Selected = true,
                Text = "Any",
                Value = "0"
            });

            for (int i = 1500; i <= 2500000; i += 1500)
            {
                items.Add(new SelectListItem
                {
                    Text = i.ToString("N"),
                    Value = i.ToString()
                });
            }

            return items;
        }
    }
}
