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
    /// (Shopping) Cart controller.
    /// </summary>
    public class CartController : SessionController
    {
        #region PrivateFields

        private Repository repository;

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CartController()
        {
            repository = Repository.Instance;
        }

        /// <summary>
        /// Return shopping cart information to the 
        /// index view.
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
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