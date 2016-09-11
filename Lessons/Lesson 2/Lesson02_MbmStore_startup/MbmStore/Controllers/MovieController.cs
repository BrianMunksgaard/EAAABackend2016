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
        private List<Movie> movies = new List<Movie>();

        // GET: Movie
        public ActionResult Index()
        {
            
            // create a new Movie object with instance name jungleBook
            movies.Add(new Movie("Jungle Book", 160.50m, "junglebook.jpg", "Jon Favreau"));
            movies.Add(new Movie("Forrest Gump", 125.00m, "forrest-gump.jpg", "Robert Zemeckis"));
            movies.Add(new Movie("Gladiator", 149.75m, "gladiator.jpg", "Ridley Scott"));

            // assign a viewbag property to the new Movie object
            ViewBag.Movies = movies;
  
            return View();
        }
    }
}