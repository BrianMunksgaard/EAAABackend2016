using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    /// <summary>
    /// This class is used to represent an item
    /// or a line on an invoice.
    /// </summary>
    public class OrderItem
    {
        #region PrivateFields

        private int orderItemId;
        private Product product;
        private int quantity;

        #endregion

        #region Properties

        /// <summary>
        /// The current order item id.
        /// </summary>
        public int OrderItemId
        {
            get { return orderItemId; }
            set { orderItemId = value; }
        }

        /// <summary>
        /// The current product id.
        /// </summary>
        public int ProductId
        {
            get { return Product.ProductId; }
        }

        /// <summary>
        /// The actual product.
        /// </summary>
        public Product Product
        {
            get { return product == null ? product = new Product() : product; }
            set { product = value; }
        }


        /// <summary>
        /// The number of item.
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// The total price for the item(s) on this line
        /// of the order.
        /// </summary>
        public decimal TotalPrice
        {
            get { return Product.Price * quantity; }
        }

        #endregion

        public OrderItem(Product product, int quantity)
        {
            if (product == null) throw new ArgumentNullException("product", "An initialized product must be specified.");
            if (quantity == 0) throw new ArgumentOutOfRangeException("quantity", "Quantity cannot be zero.");
            this.product = product;
            this.quantity = quantity;
        }

    }
}