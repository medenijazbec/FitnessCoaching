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

            // Tu preverimo uporabniško ime in geslo proti shrambi uporabnikov
            // Zaenkrat bomo ustvarili testnega uporabnika
            var user = new User(Username, Password);

            // Preverimo, ali je geslo pravilno
            if (user.CheckPassword(Password))
            {
                // Prijavljenega uporabnika preusmerimo na varno stran
                // Opomba: Tukaj bi morali nastaviti varnostno sejo ali piškotek
                return RedirectToPage("/LoginIndex");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}
