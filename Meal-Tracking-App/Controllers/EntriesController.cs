using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meal_Tracking_App.Data;
using Meal_Tracking_App.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meal_Tracking_App.Controllers
{
    public class EntriesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.entries = EntryData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Entries/Add")]
        public IActionResult NewEntry(Entry newEntry)
        {
            EntryData.Add(newEntry);

            return Redirect("/Entries");
        }

        public IActionResult Delete()
        {
            ViewBag.entries = EntryData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] entryIds)
        {
            foreach (int entryId in entryIds)
            {
                EntryData.Remove(entryId);
            }

            return Redirect("/Entries");
        }


    }
}
