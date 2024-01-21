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

        public int CalculatedCalories { get; set; }

        public void OnGet()
        {
            // Initialization if needed
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If there is a validation error, re-display the page with the validation messages
                return Page();
            }

            // Calculate calories if the user has not entered them
            if (NewDietItem.Calories == 0)
            {
                CalculatedCalories = DietItem.CalculateCalories(
                    NewDietItem.Proteins, NewDietItem.Carbohydrates, NewDietItem.Fats);
            }
            else
            {
                CalculatedCalories = NewDietItem.Calories;
            }


            // Re-display the page with the new calculated values
            return Page();
        }
    }
}
