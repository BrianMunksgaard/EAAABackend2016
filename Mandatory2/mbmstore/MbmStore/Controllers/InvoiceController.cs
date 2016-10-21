using MbmStore.Infrastructure;
using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class InvoiceController : SessionController
    {
        /// <summary>
        /// Reference to the repository.
        /// </summary>
        private Repository repository = Repository.Instance;

        /// <summary>
        /// Retrieve all invoices in the repository
        /// and return the data to the view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            //SessionState sessionState = LoadSessionState();
            //repository = sessionState.Repository;
            UpdateViewBag(null);
            return View();
        }

        /// <summary>
        /// Retrieve all invoices for the specified customer
        /// and return the data to the view.
        /// </summary>
        /// <param name="Customers"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(int? Customers)
        {
            //SessionState sessionState = LoadSessionState();
            //repository = sessionState.Repository;
            int? customerId = Customers;

            if (customerId == null)
            {
                UpdateViewBag(null);
            }
            else
            {
                Customer customer = repository.GetCustomers().Single(c => c.CustomerId == customerId);
                UpdateViewBag(customer);
            }

            return View();
        }

        /// <summary>
        /// This method is used to retrieve and store the
        /// relevant customer and invoice information in 
        /// the ViewBag. If a customer is specified all
        /// invoices regarding that customer is retrieved.
        /// If a customer is not specified (null value) all
        /// invoices in the repository are retrived.
        /// </summary>
        /// <param name="selectedCustomer"></param>
        public void UpdateViewBag(Customer selectedCustomer)
        {
            List<Invoice> allInvoices = repository.Invoices;
            List<Customer> customers = repository.GetCustomers(allInvoices);

            List<Invoice> currentInvoices = null;
            if(selectedCustomer == null)
            {
                currentInvoices = allInvoices;
            }
            else
            {
                currentInvoices = repository.GetCustomerInvoices(selectedCustomer, allInvoices);
            }

            ViewBag.Invoices = currentInvoices;
            ViewBag.Customers = repository.GetSelectList(customers);
        }
    }
}