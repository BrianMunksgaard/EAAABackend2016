using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class RockbandsController : Controller
    {
        // GET: Rockbands
        public ActionResult Index()
        {
            List<string> rockbands = new List<string>
            {
                "Led Zeppelin",
                "Pink Floyd",
                "Van Halen",
                "Queen",
                "The Beatles",
                "Metallica",
                "U2",
                "Red Hot Chille Peppers",
                "Jimi Hendrix",
                "The Eagles"
            };

            ViewBag.Rockbands = rockbands;
            
            return View();
        }
    }
}