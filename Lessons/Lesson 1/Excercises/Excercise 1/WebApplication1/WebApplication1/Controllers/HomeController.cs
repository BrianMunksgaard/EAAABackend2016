using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string name = "Peter";
            int age = 26;
            DateTime birthday = new DateTime(1990, 06, 01);

            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Birthday = birthday;

            return View();
        }
    }
}