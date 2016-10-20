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
    public class CartController : SessionController
    {
        #region PrivateFields

        private Repository repository;

        #endregion

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CartController()
        {
            repository = new Repository();
        }

        /// <summary>
        /// Add product to the shopping cart.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new
            {
                controller = returnUrl.Substring(1)
            });
        }

        /// <summary>
        /// Remove product from the shopping cart.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                GetCart().RemoveItem(product);
            }
            return RedirectToAction("Index", new
            {
                controller = returnUrl.Substring(1)
            });
        }

        /// <summary>
        /// Retrieve the current shopping cart.
        /// </summary>
        /// <returns></returns>
        private Cart GetCart()
        {
            return CurrentSessionState.ShoppingCart;
        }
    }
}