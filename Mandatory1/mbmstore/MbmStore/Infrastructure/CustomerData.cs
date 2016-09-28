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
    public class CustomerData
    {
        /// <summary>
        /// Randomizer.
        /// </summary>
        private static Random r = new Random();

        /// <summary>
        /// Return books.
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer("Anders", "And", "Paradis Æblevej 1", "1234", "Andeby"));
            customers.Add(new Customer("Rip", "And", "Paradis Æblevej 1", "1234", "Andeby"));
            customers.Add(new Customer("Rap", "And", "Paradis Æblevej 1", "1234", "Andeby"));
            customers.Add(new Customer("Rup", "And", "Paradis Æblevej 1", "1234", "Andeby"));
            customers.Add(new Customer("Mickey", "Mouse", "Paradis Æblevej 12", "1234", "Andeby"));
            customers.Add(new Customer("Fætter", "Højben", "Heldigvej 24", "2223", "Gåseby"));

            return customers;
        }

        /// <summary>
        /// Get Random customer.
        /// </summary>
        /// <returns></returns>
        public static Customer GetRandomCustomer()
        {
            int min = 0;
            int max = GetCustomers().Count;
            int num = r.Next(min, max);
            return GetCustomers()[num];
        }
    }
}