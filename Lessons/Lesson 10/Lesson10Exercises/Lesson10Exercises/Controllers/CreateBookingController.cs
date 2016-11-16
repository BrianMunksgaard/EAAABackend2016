using Lesson10Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson10Exercises.Controllers
{
    public class CreateBookingController : Controller
    {
        // GET: CreateBooking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create([Bind(Include = "Name,Username,Password,ConfirmPassword,Age")] User user)
        {
            if (ModelState.IsValid)
            {
                return View("RegistrationCompleted", user);
            }
            else
            {
                return View(user);
            }
        }
    }
}