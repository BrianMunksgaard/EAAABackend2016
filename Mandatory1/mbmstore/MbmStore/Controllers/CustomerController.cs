using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbmStore.Models;

namespace MbmStore.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> customers = new List<Models.Customer>();

        // GET: Customer
        public ActionResult Customer()
        {
            Customer c1 = new Customer("Anders", "And", "Paradis Æblevej 1", "1234", "Andeby");
            c1.AddPhoneNumber("+45 1234 5678");
            c1.AddPhoneNumber("+45 4567 8901");
            c1.BirthDay = new DateTime(2000, 12, 24);
            customers.Add(c1);

            Customer c2 = new Customer("Mickey", "Mouse", "Paradis Æblevej 12", "1234", "Andeby");
            c2.AddPhoneNumber("+45 1234 5678");
            c2.AddPhoneNumber("+45 4567 8901");
            c2.BirthDay = new DateTime(1969, 9, 18);
            customers.Add(c2);

            customers.Add(new Customer("Rip", "And", "Paradis Æblevej 1", "1234", "Andeby"));

            ViewBag.Customers = customers;

            //return View("Customer");
            return View();
        }
    }
}