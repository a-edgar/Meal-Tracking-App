using System;
using Meal_Tracking_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Meal_Tracking_App.Data
{
    public class EntryDbContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }

        public EntryDbContext(DbContextOptions<EntryDbContext> options)
            : base(options)
        {
        }
    }
}
