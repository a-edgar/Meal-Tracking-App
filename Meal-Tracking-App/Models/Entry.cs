using System;
namespace Meal_Tracking_App.Models
{
    public class Entry
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public EntryType Type { get; set; }
        public string Description { get; set; }
        public string Feelings { get; set; }

        public int Id { get; set; }


        public Entry()
        {
        }

        public Entry(string date, string time, string description, string feelings)
        {
            Date = date;
            Time = time;
            Description = description;
            Feelings = feelings;
        }

        public override string ToString()
        {
            //return base.ToString();
            return Date;
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
