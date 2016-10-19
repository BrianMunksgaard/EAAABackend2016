using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.ViewModels
{
    /// <summary>
    /// The Cart class is used to represent a shopping cart.
    /// </summary>
    public class Cart
    {
        #region PrivateFields
        private List<CartLine> lines;
        #endregion

        #region Properties

        /// <summary>
        /// Cart items.
        /// </summary>
        public List<CartLine> Lines
        {
            get { return lines == null ? lines = new List<CartLine>() : Lines; }
        }

        /// <summary>
        /// Returns the total price of the items in the cart.
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal d = Lines.Sum(item => item.LineTotal);
                return d;
            }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Cart() { }

        /// <summary>
        /// Add product to the cart.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(Product product, int quantity)
        {
            CartLine cl = Lines.SingleOrDefault(item => item.Product.ProductId == product.ProductId);
            if (cl == null)
            {
                Lines.Add(new CartLine(product, quantity));
            }
            else
            {
                cl.Quantity += quantity;
            }
        }

        /// <summary>
        /// Remove product from the cart.
        /// </summary>
        /// <param name="product"></param>
        public void RemoveItem(Product product)
        {
            Lines.RemoveAll(item => item.Product.ProductId == product.ProductId);
        }

        /// <summary>
        /// Remove all items from the cart.
        /// </summary>
        public void Clear()
        {
            Lines.Clear();
        }
    }
}