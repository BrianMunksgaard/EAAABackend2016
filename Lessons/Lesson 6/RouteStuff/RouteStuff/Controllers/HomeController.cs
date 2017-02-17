using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RouteStuff.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index(int id = 0)
        {
            return id.ToString();
            //return View();
        }
    }
}