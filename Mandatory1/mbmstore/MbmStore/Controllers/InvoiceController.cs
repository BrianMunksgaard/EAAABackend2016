using MbmStore.Infrastructure;
using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class InvoiceController : Controller
    {
        /// <summary>
        /// Reference to the repository.
        /// </summary>
        private Repository repository = new Repository();

        // GET: Invoice
        public ActionResult Index()
        {
            List<Invoice> invoices = repository.Invoices;

            ViewBag.Invoices = invoices;
            return View();
        }
    }
}