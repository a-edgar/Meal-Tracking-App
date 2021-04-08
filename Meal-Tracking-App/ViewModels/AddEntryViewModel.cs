using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Meal_Tracking_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Meal_Tracking_App.ViewModels
{
    public class AddEntryViewModel
    {
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        [DataType(DataType.Time)]
        public string Time { get; set; }
        
        [Required(ErrorMessage = "Type is required.")]
        public EntryType Type { get; set; }

        public List<SelectListItem> EntryTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(EntryType.Breakfast.ToString(), ((int)EntryType.Breakfast).ToString()),
            new SelectListItem(EntryType.Lunch.ToString(), ((int)EntryType.Lunch).ToString()),
            new SelectListItem(EntryType.Dinner.ToString(), ((int)EntryType.Dinner).ToString()),
            new SelectListItem(EntryType.Snack.ToString(), ((int)EntryType.Snack).ToString())
        };

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public string Feelings { get; set; }
    }
}
