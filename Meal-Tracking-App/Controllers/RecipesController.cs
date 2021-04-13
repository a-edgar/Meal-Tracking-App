using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meal_Tracking_App.Data;
using Meal_Tracking_App.Models;
using Meal_Tracking_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meal_Tracking_App.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {

        private EntryDbContext context;

        private IAuthorizationService authorizationService;
        private UserManager<IdentityUser> userManager;

        public RecipesController(EntryDbContext dbContext, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base()
        {
            context = dbContext;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var currentUserId = userManager.GetUserId(User);

            List<Recipe> recipes = context.Recipes
                .Where(e => e.UserId == currentUserId)
                .ToList();

            return View(recipes);
        }

        public IActionResult Add()
        {
            AddRecipeViewModel addRecipeViewModel = new AddRecipeViewModel();

            return View(addRecipeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddRecipeViewModel addRecipeViewModel)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = userManager.GetUserId(User);

                Recipe newRecipe = new Recipe
                {
                    Name = addRecipeViewModel.Name,
                    Description = addRecipeViewModel.Description,
                    Link = addRecipeViewModel.Link,
                    Image = addRecipeViewModel.Image,
                    UserId = currentUserId
                };

                context.Recipes.Add(newRecipe);
                context.SaveChanges();

                return Redirect("/Recipes");
            }

            return View(addRecipeViewModel);
        }

        public IActionResult Delete()
        {
            var currentUserId = userManager.GetUserId(User);

            ViewBag.recipes = context.Recipes
                .Where(e => e.UserId == currentUserId)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] recipeIds)
        {
            foreach(int recipeId in recipeIds)
            {
                Recipe recipe = context.Recipes.Find(recipeId);
                context.Recipes.Remove(recipe);
            }

            context.SaveChanges();

            return Redirect("/Recipes");
        }

        public IActionResult Detail(int id)
        {
            Recipe recipe = context.Recipes.Single(e => e.Id == id);

            RecipeDetailViewModel viewModel = new RecipeDetailViewModel(recipe);

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            Recipe recipe = context.Recipes.Find(id);

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if(ModelState.IsValid)
            {
                context.Entry(recipe).State = EntityState.Modified;
                context.SaveChanges();

                return Redirect("/Recipes/Detail/" + recipe.Id);
            }

            return View(recipe);
        }
    }
}
