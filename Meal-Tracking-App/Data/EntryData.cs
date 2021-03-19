using System;
using System.Collections.Generic;
using Meal_Tracking_App.Models;

namespace Meal_Tracking_App.Data
{
    public class EntryData
    {
        static private Dictionary<int, Entry> Entries = new Dictionary<int, Entry>();

        public static IEnumerable<Entry> GetAll()
        {
            return Entries.Values;
        }

        public static void Add(Entry newEntry)
        {
            Entries.Add(newEntry.Id, newEntry);
        }

        public static void Remove(int id)
        {
            Entries.Remove(id);
        }

        public static Entry GetById(int id)
        {
            return Entries[id];
        }
    }
}
