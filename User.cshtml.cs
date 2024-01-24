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

            // Tu bi morali preveriti uporabniško ime in geslo proti vaši shrambi uporabnikov
            // Zaenkrat bomo ustvarili testnega uporabnika
            var user = new User(Username, Password);

            // Preverite, ali je geslo pravilno
            if (user.CheckPassword(Password))
            {
                // Prijavite uporabnika in preusmerite na varno stran
                // Opomba: Tukaj bi morali nastaviti varnostno sejo ali piškotek
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
