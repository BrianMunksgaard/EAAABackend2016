using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.ViewModels
{
    /// <summary>
    /// Shopping cart view model.
    /// </summary>
    public class CartIndexViewModel
    {
        /// <summary>
        /// The current cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// The URL to return to when continuing shopping.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}