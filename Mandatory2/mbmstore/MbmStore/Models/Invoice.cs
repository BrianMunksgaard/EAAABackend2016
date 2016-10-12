using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    /// <summary>
    /// An MbmStore invoice.
    /// </summary>
    public class Invoice
    {
        #region PrivateFields

        private List<OrderItem> orderItems;
        private int invoiceId;
        private DateTime orderDate;
        private Customer customer;

        #endregion

        #region Properties

        /// <summary>
        /// Total invoice amount.
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal d = OrderItems.Sum(item => item.TotalPrice);
                return d;
            }
        }

        /// <summary>
        /// The items on the invoice.
        /// </summary>
        public List<OrderItem> OrderItems
        {
            get { return orderItems == null ? orderItems = new List<OrderItem>() : orderItems; }
        }

        /// <summary>
        /// Unique invoice identification.
        /// </summary>
        public int InvoiceId
        {
            get { return invoiceId; }
            set { invoiceId = value; }
        }

        /// <summary>
        /// Order date.
        /// </summary>
        public DateTime OrderDate
        {
            get { return orderDate == null ? orderDate = DateTime.Now : orderDate; }
            set { orderDate = value; }
        }

        /// <summary>
        /// Invoice customer.
        /// </summary>
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        #endregion

        /// <summary>
        /// Initialize invoice.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="orderDate"></param>
        /// <param name="customer"></param>
        public Invoice(int invoiceId, DateTime orderDate, Customer customer)
        {
            this.invoiceId = invoiceId;
            this.orderDate = orderDate;
            this.customer = customer;
        }

        /// <summary>
        /// Adds an item to the invoice/order.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddOrderItem(Product product, int quantity)
        {
            OrderItem oi = OrderItems.SingleOrDefault(item => item.Product.Title == product.Title);
            if(oi == null)
            {
                OrderItems.Add(new OrderItem(product, quantity));
            }
            else
            {
                oi.Quantity += quantity;
            }
        }
    }
}