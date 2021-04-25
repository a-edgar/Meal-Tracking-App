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
    public class SearchController : Controller
    {
        private IAuthorizationService authorizationService;

        private UserManager<IdentityUser> userManager;

        private EntryDbContext context;

        public SearchController(EntryDbContext dbContext, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base()
        {
            context = dbContext;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results(DateTime searchDate)
        {
            var currentUserId = userManager.GetUserId(User);

            List<Entry> entries = context.Entries
                .Where(e => e.UserId == currentUserId)
                .Where(e => e.Date == searchDate)
                .OrderBy(e => e.Time.TimeOfDay)
                .ToList();

            List<EntryDetailViewModel> displayEntries = new List<EntryDetailViewModel>();

            foreach (Entry entry in entries)
            {
                EntryDetailViewModel newDisplayEntry = new EntryDetailViewModel(entry);
                displayEntries.Add(newDisplayEntry);
            }

            ViewBag.title = "Entries for " + searchDate.ToShortDateString();
            ViewBag.entries = displayEntries;
            return View("Index");
        }

    }
}