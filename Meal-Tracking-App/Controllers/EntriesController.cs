using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meal_Tracking_App.Data;
using Meal_Tracking_App.Models;
using Meal_Tracking_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meal_Tracking_App.Controllers
{
    [Authorize]
    public class EntriesController : Controller
    {

        private EntryDbContext context;

        private IAuthorizationService authorizationService;

        private UserManager<IdentityUser> userManager;

        public EntriesController(EntryDbContext dbContext, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base()
        {
            context = dbContext;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var currentUserId = userManager.GetUserId(User);

            List<Entry> entries = context.Entries
                .Where(e => e.UserId == currentUserId)
                .OrderBy(e => e.Date)
                .ThenBy(e => e.Time.TimeOfDay)
                .ToList();
                

            return View(entries);
                //.ThenBy(e => DateTime.Parse(e.Time)));
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
                var currentUserId = userManager.GetUserId(User);

                Entry newEntry = new Entry
                {
                    Date = addEntryViewModel.Date,
                    Time = addEntryViewModel.Time,
                    Type = addEntryViewModel.Type,
                    Description = addEntryViewModel.Description,
                    Feelings = addEntryViewModel.Feelings,
                    UserId = currentUserId
                };

                context.Entries.Add(newEntry);
                context.SaveChanges();

                return Redirect("/Entries");
            }

            return View(addEntryViewModel);

        }

        public IActionResult Delete()
        {
            var currentUserId = userManager.GetUserId(User);

            ViewBag.entries = context.Entries
                .Where(e => e.UserId == currentUserId)
                .OrderBy(e => e.Date)
                .ThenBy(e => e.Time.TimeOfDay)
                .ToList();
                //.ThenBy(e => DateTime.Parse(e.Time));

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

        public IActionResult Edit(int id)
        {
            Entry entry = context.Entries.Find(id);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Edit(Entry entry)
        //public async Task<IActionResult> Edit(Entry entry)
        {
            if(ModelState.IsValid)
            {
                context.Entry(entry).State = EntityState.Modified;
                context.SaveChanges();

                return Redirect("/Entries/Detail/" + entry.Id);
                //return RedirectToAction("index", "Entries");
            }

            return View(entry);
        }
    }
}
