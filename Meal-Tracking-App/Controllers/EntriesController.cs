﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meal_Tracking_App.Controllers
{
    public class EntriesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string html = "<h1>" + "Hello World!" + "<h1>";
            return Content(html, "text/html");
        }
    }
}
