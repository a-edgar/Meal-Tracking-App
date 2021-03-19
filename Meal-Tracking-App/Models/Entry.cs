using System;
namespace Meal_Tracking_App.Models
{
    public class Entry
    {
        public int Date { get; set; }
        public int Time { get; set; }
        public string Description { get; set; }
        public string Feelings { get; set; }

        public int Id { get; }
        static private int nextId = 1;

        public Entry()
        {
            Id = nextId;
            nextId++;
        }

        public Entry(int date, int time, string description, string feelings) : this()
        {
            Date = date;
            Time = time;
            Description = description;
            Feelings = feelings;
        }

        public override string ToString()
        {
            //return base.ToString();
            return Date.ToString();
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
