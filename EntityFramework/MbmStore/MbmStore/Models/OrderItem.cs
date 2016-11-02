﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get { return Quantity * Product.Price; } }

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