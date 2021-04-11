using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Meal_Tracking_App.Models
{
    public class Entry
    {

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public string Time { get; set; }
        public EntryType Type { get; set; }
        public string Description { get; set; }
        public string Feelings { get; set; }

        public int Id { get; set; }

        public string UserId { get; set; }


        public Entry()
        {
        }

        public Entry(DateTime date, string time, string description, string feelings)
        {
            Date = date;
            Time = time;
            Description = description;
            Feelings = feelings;
        }

        public override string ToString()
        {
            return Date.ToShortDateString();
        }

        public override bool Equals(object obj)
        {
            return obj is Entry entry &&
                Id == entry.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
