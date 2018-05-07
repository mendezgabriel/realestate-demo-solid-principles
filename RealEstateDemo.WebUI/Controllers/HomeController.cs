using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateDemo.WebUI.Controllers
{
    /// <summary>
    /// Provides server-side logic for the home page.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Renders the default view.
        /// </summary>
        /// <returns>The view.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
