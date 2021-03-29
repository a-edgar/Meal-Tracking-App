using System;
using System.ComponentModel.DataAnnotations;

namespace Meal_Tracking_App.ViewModels
{
    public class AddRecipeViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Please enter a valid web address.")]
        public string Link { get; set; }

        public string Image { get; set; }
    }
}
