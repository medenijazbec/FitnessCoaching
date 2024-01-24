using Fitness.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Fitness.Pages
{
    public class UserModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Username and password are required.";
                return Page();
            }

            // Tu bi morali preveriti uporabni�ko ime in geslo proti va�i shrambi uporabnikov
            // Zaenkrat bomo ustvarili testnega uporabnika
            var user = new User(Username, Password);

            // Preverite, ali je geslo pravilno
            if (user.CheckPassword(Password))
            {
                // Prijavite uporabnika in preusmerite na varno stran
                // Opomba: Tukaj bi morali nastaviti varnostno sejo ali pi�kotek
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}
