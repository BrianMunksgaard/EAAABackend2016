using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5Excercises.Controllers
{
    public class Exercise01Controller : Controller
    {
        // GET: Excercise01
        public ActionResult Index()
        {
            List<SelectListItem> countryList = new List<SelectListItem>();
            countryList.Add(new SelectListItem { Text = "China", Value = "CN" });
            countryList.Add(new SelectListItem { Text = "Denmark", Value = "DK" });
            countryList.Add(new SelectListItem { Text = "United Kingdom", Value = "UK" });
            countryList.Add(new SelectListItem { Text = "Spain", Value = "ES" });

            SessionState sessionState = new SessionState();
            sessionState.CountryList = countryList;
            Session["SessionState"] = sessionState;

            ViewBag.CountryList = countryList;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string countryList)
        {
            ViewBag.CountryCode = countryList;

            SessionState currentSession = Session["SessionState"] as SessionState;
            currentSession.CurrentCountryCode = countryList;

            ViewBag.CountryList = currentSession.CountryList;
            ViewBag.CurrentCountryCode = countryList;

            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(FormCollection fc)
        {
            string country = fc["Country"];
            string code = fc["Code"];

            SessionState currentSession = Session["SessionState"] as SessionState;
            currentSession.CountryList.Add(new SelectListItem()
            {
                Text = country,
                Value = code
            });

            currentSession.CurrentCountryCode = code;
            Session["SessionState"] = currentSession;
            
            ViewBag.CountryList = currentSession.CountryList;
            ViewBag.CurrentCountryCode = code;

            return View("Index");
        }
    }

    public class SessionState
    {
        private List<SelectListItem> countryList;

        public List<SelectListItem> CountryList
        {
            get
            {
                countryList.Sort((a, b) => a.Text.CompareTo(b.Text));
                countryList.Where(c => c.Value == CurrentCountryCode).Single().Selected = true;
                return countryList;
            }
            set
            {
                countryList = value;
            }
        }


        public string CurrentCountryCode { get; set; } = string.Empty;

        public SessionState() { }
    }
}