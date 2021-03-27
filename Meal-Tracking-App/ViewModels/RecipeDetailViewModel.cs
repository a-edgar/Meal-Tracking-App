using System;
using Meal_Tracking_App.Models;

namespace Meal_Tracking_App.ViewModels
{
    public class RecipeDetailViewModel
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public RecipeDetailViewModel(Recipe recipe)
        {
            RecipeId = recipe.Id;
            Name = recipe.Name;
            Description = recipe.Description;
            Link = recipe.Link;
        }
    }
}
