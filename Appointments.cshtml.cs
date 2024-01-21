using Fitness.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fitness.Pages
{
    public class AppointmentsModel : PageModel
    {
        public List<Appointment> Appointments { get; set; } // Property to hold appointments

        public void OnGet()
        {
            // Initialize the Appointments list with some example data
            Appointments = new List<Appointment>
            {
                new Appointment(new DateTime(2024, 1, 22, 9, 0, 0), new DateTime(2024, 1, 22, 10, 0, 0), "Yoga Class"),
                new Appointment(new DateTime(2024, 1, 23, 15, 0, 0), new DateTime(2024, 1, 23, 16, 30, 0), "Pilates Workshop"),
                // Add more appointments as needed
            };
        }
    }
}
