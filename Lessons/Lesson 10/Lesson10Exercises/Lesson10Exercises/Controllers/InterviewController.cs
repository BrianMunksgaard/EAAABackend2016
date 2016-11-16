using Lesson10Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson10Exercises.Controllers
{
    public class InterviewController : Controller
    {
        // GET: Interview
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Interviewee i)
        {
            {
                if (ModelState.IsValid)
                {
                    return View("RegisterInterviewCompleted", i);
                }
                else
                {
                    return View(i);
                }
            }
        }
    }
}