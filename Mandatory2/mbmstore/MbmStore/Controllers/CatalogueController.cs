﻿using MbmStore.Infrastructure;
using MbmStore.Models;
using MbmStore.ViewModels;
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
        /// Products per page.
        /// </summary>
        public int PageSize = 4;

        /// <summary>
        /// Reference to the repository.
        /// </summary>
        private Repository repository = Repository.Instance;

        /// <summary>
        /// Returns a view with all the product data
        /// from the repository.
        /// </summary>
        /// <returns></returns>
        /*
        public ActionResult Index()
        {
            // Get reference to products repository. The repository
            // holds all data for the application.
            List<Product> products = repository.Products;

            // Store data in the view model.
            CatalogueViewModel vm = new CatalogueViewModel(products);

            // Return the model to the view.
            return View(vm);
        }*/

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