using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meal_Tracking_App.Data;
using Meal_Tracking_App.Models;
using Meal_Tracking_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meal_Tracking_App.Controllers
{
    public class EntriesController : Controller
    {

        private EntryDbContext context;

        public EntriesController(EntryDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Entry> entries = context.Entries.ToList();

            return View(entries);
        }

        public IActionResult Add()
        {
            AddEntryViewModel addEntryViewModel = new AddEntryViewModel();

            return View(addEntryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEntryViewModel addEntryViewModel)
        {
            if (ModelState.IsValid)
            {
                Entry newEntry = new Entry
                {
                    Date = addEntryViewModel.Date,
                    Time = addEntryViewModel.Time,
                    Type = addEntryViewModel.Type,
                    Description = addEntryViewModel.Description,
                    Feelings = addEntryViewModel.Feelings
                };

                context.Entries.Add(newEntry);
                context.SaveChanges();

                return Redirect("/Entries");
            }

            return View(addEntryViewModel);

        }

        public IActionResult Delete()
        {
            ViewBag.entries = context.Entries.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] entryIds)
        {
            foreach (int entryId in entryIds)
            {
                Entry entry = context.Entries.Find(entryId);
                context.Entries.Remove(entry);
            }

            context.SaveChanges();

            return Redirect("/Entries");
        }

        public IActionResult Detail(int id)
        {
            Entry entry = context.Entries.Single(e => e.Id == id);

            EntryDetailViewModel viewModel = new EntryDetailViewModel(entry);

            return View(viewModel);

        }
    }
}
