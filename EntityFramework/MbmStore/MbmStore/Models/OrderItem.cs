using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }

        /// <summary>
        /// Lazy loaded navigation property.
        /// </summary>
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get { return Quantity * Price; } }
        public decimal Price { get; set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

		public OrderItem() {}
		 
        public OrderItem(int orderItemID, Product product, int quantity)
        {
            OrderItemId = orderItemID;
            Product = product;
            Quantity = quantity;
        }
    }
}