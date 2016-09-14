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
        public ActionResult DiceRoller()
        {
            // Load dices.
            Dictionary<string, Dice> dices = LoadDices();
            ViewBag.Dices = dices;
            return View();
        }

        [HttpPost]
        public ActionResult DiceRoller(FormCollection fc)
        {
            // Load dices.
            Dictionary<string, Dice> dices = LoadDices();

            // Roll specified dice.
            string diceId = fc["diceId"];
            Dice dice;
            if (dices.TryGetValue(diceId, out dice))
            {
                dice.Roll();
            }

            // Store dices.
            StoreDices(dices);

            // Return data to view;
            ViewBag.Dices = dices;

            //return View("DiceRollerView");
            return View();
        }

        private Dictionary<string, Dice> LoadDices()
        {
            Dictionary<string, Dice> dices;

            if (Session["dice"] == null)
            {
                dices = new Dictionary<string, Dice>();
                dices.Add("dice1", new Dice("dice1"));
                dices.Add("dice2", new Dice("dice2"));
            }
            else
            {
                dices = (Dictionary<string, Dice>)Session["dice"];
            }

            return dices;
        }

        private void StoreDices(Dictionary<string, Dice> dices)
        {
            Session["dice"] = dices;
        }
    }
}