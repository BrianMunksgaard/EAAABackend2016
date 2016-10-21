using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Infrastructure
{
    /// <summary>
    /// The repository class is used as a data storage controller.
    /// With the repository class, we can retrieve the various data
    /// (that is normally stored in a database) that the appliaction
    /// needs.
    /// Currently, the repository class is implemented as a singleton.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Singleton repository reference,
        /// </summary>
        private static Repository instance;

        /// <summary>
        /// Dummy object used as lock.
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// The list of all products.
        /// </summary>
        public List<Product> Products = new List<Product>();

        /// <summary>
        /// The list of all invoices.
        /// </summary>
        public List<Invoice> Invoices = new List<Invoice>();

        /// <summary>
        /// Returns all books in the repository.
        /// </summary>
        public List<Book> Books
        {
            get
            {
                return Products.OfType<Book>().ToList();
            }
        }
        
        /// <summary>
        /// Return all CDs in the repository.
        /// </summary>
        public List<MusicCD> MusicCDs
        {
            get
            {
                return Products.OfType<MusicCD>().ToList();
            }
        }

        /// <summary>
        /// Return all movies in the repository.
        /// </summary>
        public List<Movie> Movies
        {
            get
            {
                return Products.OfType<Movie>().ToList();
            }
        }

        /// <summary>
        /// Returns a list of unique customers from the list
        /// of invoices.
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public List<Customer> GetCustomers(List<Invoice> invoices)
        {
            List<Customer> customerList = new List<Customer>();

            foreach (Invoice i in invoices)
            {
                Customer c = customerList.SingleOrDefault(item => item.CustomerId == i.Customer.CustomerId);
                if (c == null) // Customer not already in the list.
                {
                    customerList.Add(i.Customer);
                }
            }

            return customerList;
        }

        /// <summary>
        /// Returns a list of all customers in
        /// the repository.
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            List<Customer> customerList = CustomerData.GetCustomers();
            return customerList;
        }

        /// <summary>
        /// Returns a list of invoices regarding the specified
        /// customer.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="allInvoices"></param>
        /// <returns></returns>
        public List<Invoice> GetCustomerInvoices(Customer c, List<Invoice> allInvoices)
        {
            if (allInvoices == null)
            {
                allInvoices = new List<Invoice>();
            }

            List<Invoice> invoices = allInvoices.Where(r => r.Customer.CustomerId == c.CustomerId).ToList();

            return invoices;
        }

        /// <summary>
        /// Returns all customers from the specified customer list
        /// as a list of SelectListItems.
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public List<SelectListItem> GetSelectList(List<Customer> customers)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (Customer c in customers)
            {
                items.Add(new SelectListItem()
                {
                    Text = string.Format("{0} {1}", c.FirstName, c.LastName),
                    Value = c.CustomerId.ToString()
                });
            }

            return items;
        }

        /// <summary>
        /// Returns an instance reference of the repository.
        /// </summary>
        public static Repository Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Repository();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Initialize the repository.
        /// </summary>
        public Repository()
        {
            RefreshRepository();
        }

        /// <summary>
        /// Refresh the repository. Currently, this means
        /// that a new set of random data is generated.
        /// </summary>
        public void RefreshRepository()
        {
            Products.Clear();
            Invoices.Clear();

            Products.AddRange(ProductData.GetBooks());
            Products.AddRange(ProductData.GetMusicCDs());
            Products.AddRange(ProductData.GetMovies());
            Invoices.AddRange(InvoiceData.GetInvoices());
        }
    }
}