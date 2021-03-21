using System;
namespace Meal_Tracking_App.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public int Id { get; set; }

        public Recipe()
        {
        }

        public Recipe(string name, string description, string link)
        {
            Name = name;
            Description = description;
            Link = link;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Recipe recipe &&
                Id == recipe.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
