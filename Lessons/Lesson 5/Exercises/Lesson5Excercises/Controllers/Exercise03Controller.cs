using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
            ViewModel vm = new ViewModel();
            vm.FullName = fc["FullName"];
            vm.RoomNumber = fc["RoomNumber"];
            
            string time = fc["Time"];
            vm.Time = DateTime.Parse(time);

            string selectedItemsStr = fc["sli.Selected"];
            List<string> selectedItems = selectedItemsStr.Split(',').ToList();
            foreach(string s in selectedItems)
            {
                SelectListItem selectListItem = vm.AllItems.SingleOrDefault(item => item.Value == s);
                if(selectListItem != null)
                {
                    selectListItem.Selected = true;
                }
            }
            
            return View("Reciept", vm);
        }
    }

    public class ViewModel
    {
        public List<SelectListItem> AllItems { get; set; }
        public string FullName { get; set; }
        public string RoomNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        public string SelectedItems
        {
            get
            {
                string items = string.Join(", ", AllItems.Where(item => item.Selected).Select(i=>i.Text));
                return items;
            }
        }

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