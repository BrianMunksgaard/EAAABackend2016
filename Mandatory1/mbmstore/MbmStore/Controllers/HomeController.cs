using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    /// <summary>
    /// The home controller is the application default controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Redirect to CatalogueController.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Catalogue");
        }
    }
}