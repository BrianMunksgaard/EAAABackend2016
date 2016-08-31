using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public ActionResult TimeCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TimeCalculator(FormCollection formCollection)
        {
            int hours = Convert.ToInt32(formCollection["Hours"]);
            int minutes = Convert.ToInt32(formCollection["Minutes"]);
            int seconds = Convert.ToInt32(formCollection["Seconds"]);

            TimeSpan ts = new TimeSpan(0, hours, minutes, seconds);
            double total = ts.TotalSeconds;

            ViewBag.Hours = hours;
            ViewBag.Minutes = minutes;
            ViewBag.Seconds = seconds;

            ViewBag.Result = string.Format("{0} hours + {1} minutes + {2} seconds = {3} seconds in total.", hours, minutes, seconds, total);

            //return View("TimeCalculatorResult");
            return View();
        }
    }
}