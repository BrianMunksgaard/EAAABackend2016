using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MbmStore.Models;

namespace MbmStore.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            
            // create a new Movie object with instance name jungleBook
            Movie jungleBook = new Movie("Jungle Book", 160.50m, "junglebook.jpg");
            Movie forrestGump = new Movie("Forrest Gump", 125.00m, "forrest-gump.jpg");
            Movie gladiator = new Movie("Gladiator", 149.75m, "gladiator.jpg");

            // assign a viewbag property to the new Movie object
            ViewBag.JungleBook = jungleBook;
            ViewBag.ForrestGump = forrestGump;
            ViewBag.Gladiator = gladiator;

            return View();
        }
    }
}