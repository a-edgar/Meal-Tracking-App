using System;
namespace Meal_Tracking_App.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }

        public int Id { get; set; }

        public string UserId { get; set; }

        public Recipe()
        {
        }

        public Recipe(string name, string description)
        {
            Name = name;
            Description = description;
            //Link = link;
            //Image = image;
        }

        public Recipe(string name, string description, string link, string image) : this(name, description)
        {
            Link = link;
            Image = image;
        }

        //public Recipe(string name, string description, string image) : this(name, description)
        //{
        //    Image = image;
        //}

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
