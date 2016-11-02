using MbmStore.Infrastructure;
using MbmStore.Models;
using MbmStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    /// <summary>
    /// The catalogue controller is used when browsing
    /// products in the store.
    /// </summary>
    public class CatalogueController : Controller
    {
        /// <summary>
        /// Products per page.
        /// </summary>
        public int PageSize = 4;

        /// <summary>
        /// Reference to the repository.
        /// </summary>
        private Repository repository = Repository.Instance;

        /// <summary>
        /// Retrieves product data from the repository
        /// and returns data to the view. Category and
        /// page is used to subset the data retrieved.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
                },
                
                CurrentCategory = category
            };

            return View(model);
        }
    }
}