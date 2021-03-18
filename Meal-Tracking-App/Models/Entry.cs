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

        public Entry(int date, int time, string description, string feelings)
        {
            Date = date;
            Time = time;
            Description = description;
            Feelings = feelings;
            Id = nextId;
            nextId++;
        }
    }
}
