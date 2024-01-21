using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fitness.Classes;
using System;

namespace Fitness.Pages
{
    public class DietItemModel : PageModel
    {
        [BindProperty]
        public DietItem NewDietItem { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
                var itemName = Request.Form["ItemName"];
                var calories = int.Parse(Request.Form["Calories"]);
                var proteins = float.Parse(Request.Form["Proteins"]);
                var carbohydrates = float.Parse(Request.Form["Carbohydrates"]);
                var fats = float.Parse(Request.Form["Fats"]);
                var mealTime = DateTime.Parse(Request.Form["MealTime"]);

                NewDietItem = new DietItem(itemName, calories, proteins, carbohydrates, fats, mealTime);

                // Tu lahko shranite NewDietItem v bazo podatkov ali drugam
                // Za zdaj samo preusmerimo nazaj na isto stran
                return Page();
            }
            catch (FormatException)
            {
                // Handle format exception if the input is not in the correct format
                ModelState.AddModelError("", "Invalid input format.");
                return Page();
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
