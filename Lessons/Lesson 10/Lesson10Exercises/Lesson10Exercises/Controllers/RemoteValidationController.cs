using Lesson10Exercises.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson10Exercises.Controllers
{
    public class RemoteValidationController : Controller
    {
        // GET: RemoteValidation
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UniqueUserName(string username)
        {
            UserRepository up = new UserRepository();
            if(up.UsernameIsUnique(username))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("The specified username is already in use.", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(Date, out parsedDate))
            {
                return Json("Please enter a valid date (dd-mm-yyyy)", JsonRequestBehavior.AllowGet);
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Please enter a date in the future", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}