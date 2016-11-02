using MbmStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    /// <summary>
    /// This controller is used to create navigation ui elements
    /// for the shop application.
    /// </summary>
    public class NavController : Controller
    {
        /// <summary>
        /// Returns all product categories to the view.
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = Repository.Instance.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}