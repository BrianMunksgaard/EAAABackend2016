using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiceRoll.Models;

namespace DiceRoll.Controllers
{
    public class DiceController : Controller
    {
         // GET: Dice
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            ViewBag.Dice = RollDice();
            return View();
        }

        private Dice RollDice()
        {
            Dice dice;
            if (Session["dice"] == null)
            {
                dice = new Dice();
                dice.Roll();
                Session["dice"] = dice;
            }
            else
            {
                dice = (Dice)Session["dice"];
                dice.Roll();
                Session["dice"] = dice;
            }
            return dice;
        }
    }
}