using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.ViewModels
{
    /// <summary>
    /// CartLine represents an item and the quantity in a shopping cart.
    /// </summary>
    public class CartLine
    {
        #region Properties

        /// <summary>
        /// The product.
        /// </summary>
        public Product Product { get; set; } = new Product();

        /// <summary>
        /// The current quantity of 'Product'.
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Return total line price.
        /// </summary>
        public decimal LineTotal
        {
            get
            {
                return Product.Price * Quantity;
            }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CartLine() { }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public CartLine(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}