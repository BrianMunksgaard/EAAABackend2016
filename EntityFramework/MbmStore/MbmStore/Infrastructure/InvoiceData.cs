using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Infrastructure
{
    /// <summary>
    /// This class is used to simulate some kind of data storage
    /// so it is possible to hide the ugly object creation and
    /// initializtion.
    /// </summary>
    public class InvoiceData
    {
        /// <summary>
        /// Randomizer.
        /// </summary>
        private static Random r = new Random();

        /// <summary>
        /// Return books.
        /// </summary>
        /// <returns></returns>
        public static List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();
            int invoiceId = 1;
            {
                Customer c = CustomerData.GetRandomCustomer();
                Invoice i = new Invoice(invoiceId++, DateTime.Now, c);
                i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));
                i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));
                i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));

                invoices.Add(i);
            }

            {
                Customer c = CustomerData.GetRandomCustomer();
                Invoice i = new Invoice(invoiceId++, DateTime.Now, c);
                i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));
                i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));
                i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));

                invoices.Add(i);
            }

            {
                Customer c = CustomerData.GetRandomCustomer();
                Invoice i = new Invoice(invoiceId++, DateTime.Now, c);
                
                for(int cnt = 1; cnt <= 8; cnt++)
                {
                    i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));
                }
                
                invoices.Add(i);
            }

            {
                Customer c = CustomerData.GetRandomCustomer();
                Invoice i = new Invoice(invoiceId++, DateTime.Now, c);

                for (int cnt = 1; cnt <= 8; cnt++)
                {
                    i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));
                }

                invoices.Add(i);
            }

            {
                Customer c = CustomerData.GetRandomCustomer();
                Invoice i = new Invoice(invoiceId++, DateTime.Now, c);

                for (int cnt = 1; cnt <= 8; cnt++)
                {
                    i.AddOrderItem(ProductData.GetRandomProduct(), r.Next(1, 12));
                }

                invoices.Add(i);
            }

            return invoices;
        }
    }
}