using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5Excercises.Controllers
{
    public class Exercise03Controller : Controller
    {
        // GET: Exercise03
        public ActionResult Index()
        {
            ViewModel vm = new ViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string fullName = fc["fullname"];
            string roomNumber = fc["roomnumber"];
            string selectedItemsStr = fc["sli.Selected"];
            string time = fc["time"];

            ViewModel vm = new ViewModel();
            List<string> selectedItems = selectedItemsStr.Split(',').ToList();
            int cnt = 0;
            foreach(string s in selectedItems)
            {
                if(s.Equals("True"))
                {
                    vm.AllItems.ElementAt(cnt++).Selected = true;
                }
            }
            
            

            return View("Reciept");
        }
    }

    public class ViewModel
    {
        public List<SelectListItem> AllItems { get; set; }
        //public List<SelectListItem> SelectedItems { get; set; } = new List<SelectListItem>();

        public ViewModel()
        {
            List<SelectListItem> breakfastItems = new List<SelectListItem>();
            breakfastItems.Add(new SelectListItem() { Text = "Cornflakes" });
            breakfastItems.Add(new SelectListItem() { Text = "Egg" });
            breakfastItems.Add(new SelectListItem() { Text = "Toast" });
            breakfastItems.Add(new SelectListItem() { Text = "Juice" });
            breakfastItems.Add(new SelectListItem() { Text = "Milk" });
            breakfastItems.Add(new SelectListItem() { Text = "Coffe" });
            breakfastItems.Add(new SelectListItem() { Text = "Tea" });
            breakfastItems.ForEach(item => item.Value = item.Text);
            AllItems = breakfastItems;
        }
    }
}