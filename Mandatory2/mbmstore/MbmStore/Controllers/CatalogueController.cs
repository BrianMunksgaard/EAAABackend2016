using MbmStore.Infrastructure;
using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class CatalogueController : Controller
    {
        /// <summary>
        /// Reference to the repository.
        /// </summary>
        private Repository repository = new Repository();

        /// <summary>
        /// Returns a view with all the product data
        /// from the repository.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // Get reference to products repository. The repository
            // holds all data for the application.
            List<Product> products = repository.Products;

            // Store the products in the view bag.
            ViewBag.Repository = repository;
            return View();
        }
    }
}