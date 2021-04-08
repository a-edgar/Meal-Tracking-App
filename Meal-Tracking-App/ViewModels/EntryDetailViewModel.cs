using System;
using Meal_Tracking_App.Models;

namespace Meal_Tracking_App.ViewModels
{
    public class EntryDetailViewModel
    {
        public int EntryId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Feelings { get; set; }


        public EntryDetailViewModel(Entry entry)
        {
            EntryId = entry.Id;
            Date = entry.Date.ToShortDateString();
            Time = entry.Time;
            Type = entry.Type.ToString();
            Description = entry.Description;
            Feelings = entry.Feelings;

        }
    }
}
