using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Fitness.Pages
{
    public class ReservationModel : PageModel
    {
        // Predpostavimo, da imate razred Facility
        public class Facility
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public List<Facility> Facilities { get; set; } = new List<Facility>
        {
            new Facility { Id = 1, Name = "Gym" },
            new Facility { Id = 2, Name = "Pool" },
            new Facility { Id = 3, Name = "Tennis Court" }
            // Dodajte veè objektov po potrebi
        };

        [BindProperty]
        public int SelectedFacilityId { get; set; }

        [BindProperty]
        public DateTime AppointmentDate { get; set; }

        [BindProperty]
        public TimeSpan AppointmentTime { get; set; }

        public void OnPost()
        {
            // Tukaj ustvarite rezervacijo z uporabo SelectedFacilityId, AppointmentDate in AppointmentTime
            // Tukaj bi bila logika za shranjevanje rezervacije, èe ne uporabljate podatkovne baze
        }
    }
}


/*
using Fitness.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Fitness.Pages
{
    public class ReservationModel : PageModel
    {
        // Predpostavimo, da imate razred Facility in seznam objektov, ki jih je mogoèe rezervirati
        
        //public List<Facility> Facilities { get; set; }

        [BindProperty]
        public int SelectedFacilityId { get; set; }

        [BindProperty]
        public DateTime AppointmentDate { get; set; }

        [BindProperty]
        public TimeSpan AppointmentTime { get; set; }

        public void OnGet()
        {
            // Napolnimo Facilities s podatki iz nase baze
        }

        public void OnPost()
        {
            // Tukaj ustvarimo rezervacijo z uporabo SelectedFacilityId, AppointmentDate in AppointmentTime
            // Shranimo podatke v podatkovno bazo
        }
    }
}
*/