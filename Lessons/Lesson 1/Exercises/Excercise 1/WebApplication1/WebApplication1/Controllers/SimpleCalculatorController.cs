using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class SimpleCalculatorController : Controller
    {
        [HttpGet]
        public ActionResult SimpleCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SimpleCalculator(FormCollection formCollection)
        {
            int number1 = 0;
            int number2 = 0;
            int.TryParse(formCollection["Number1"], out number1);
            int.TryParse(formCollection["Number2"], out number2);

            decimal result = 0;

            string op = formCollection["Operator"];
            switch(op)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    if(number2 != 0)
                    {
                        result = decimal.Divide(number1, number2);
                    }
                    break;
            }

            ViewBag.Number1 = number1;
            ViewBag.Number2 = number2;

            ViewBag.Result = result.ToString();

            return View();
        }
    }
}