using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateDemo.BusinessInterfaces;
using RealEstateDemo.Common;
using RealEstateDemo.Domain;
using RealEstateDemo.RepositoryInterfaces;

namespace RealEstateDemo.Business
{
	/// <summary>
	/// Process a <see cref="Domain.Property"/> according to the business rules.
	/// </summary>
	public class PropertyProcessor : IPropertyProcessor
	{
		readonly IPropertyRepository propertyRepository;

		/// <summary>
		/// Creates a new instance of this.
		/// </summary>
		/// <param name="propertyRepository">How to persist/retrieve property-related data from the data repository.</param>
		public PropertyProcessor(IPropertyRepository propertyRepository)
		{
			this.propertyRepository = propertyRepository;
		}

		/// <summary>
		/// Gets a list of matching properties by <paramref name="suburb"/> and <paramref name="priceRange"/>.
		/// </summary>
		/// <param name="suburb">The <see cref="Suburb"/> on which the property is located.</param>
		/// <param name="priceRange">The price range used to filter the properties.</param>
		/// <returns>A list of matching properties.</returns>
        public List<Property> FindMatchingPropertiesBy(Suburb suburb, PriceRange priceRange)
		{
            var properties = propertyRepository.FindBy(suburb, priceRange);
            return properties.ToList();
		}

        /// <summary>
        /// Finds a property by its Id
        /// </summary>
        /// <param name="id">The property's identifier.</param>
        /// <returns>The object found.</returns>
        public Property FindBy(int id)
        {
            return propertyRepository.FindById(id);
        }

		/// <summary>
		/// Adds an enquiry to a property.
		/// </summary>
		/// <param name="property">The <see cref="Property"/> object that is the subject of the enquiry.</param>
		/// <param name="enquiry">The <see cref="Enquiry"/> details.</param>
		public void AddEnquiry(Property property, Enquiry enquiry)
		{
            propertyRepository.AddEnquiry(property, enquiry);
		}

        /// <summary>
        /// Gets a list of matching locations by <paramref name="suburb"/>.
        /// </summary>
        /// <param name="suburb">The search criteria used by the filter.</param>
        /// <returns>A list of matching locations.</returns>
        public List<Location> FindMathingLocationsBy(string searchText)
        {
            searchText = searchText != null ? searchText.ToLowerInvariant() : string.Empty;

            var locations = propertyRepository.GetAvailableLocations()
                .Where(location => location.Suburb.Name.ToLowerInvariant().Contains(searchText) ||
                    location.Suburb.PostCode.ToLowerInvariant().Contains(searchText));

            return locations.ToList();
        }
	}
}
