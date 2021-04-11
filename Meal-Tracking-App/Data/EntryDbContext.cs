using System;
using Meal_Tracking_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meal_Tracking_App.Data
{
    public class EntryDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public EntryDbContext(DbContextOptions<EntryDbContext> options)
            : base(options)
        {
        }

    }
}
