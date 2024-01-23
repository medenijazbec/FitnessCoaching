using Fitness.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.Pages
{
    public class ScheduleModel : PageModel
    {
        public Schedule WeeklySchedule { get; set; }
        public DateTime StartOfWeek { get; set; }

        public ScheduleModel()
        {
            // Nastavite zaèetek tedna na ponedeljek trenutnega tedna
            StartOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            // Inicializacija tedenskega urnika z testnimi podatki
            WeeklySchedule = new Schedule();

            // Ustvarite testne termine in jih dodajte v urnik
            for (int i = 0; i < 7; i++) // 7 dni v tednu
            {
                DateTime day = StartOfWeek.AddDays(i);
                // Jutranji termin
                WeeklySchedule.AddAppointment(new Appointment(day.AddHours(9), day.AddHours(10), "Joga"));
                // Popoldanski termin
                WeeklySchedule.AddAppointment(new Appointment(day.AddHours(14), day.AddHours(15), "Pilates"));
                // Veèerni termin
                WeeklySchedule.AddAppointment(new Appointment(day.AddHours(18), day.AddHours(19), "Spinning"));
            }
        }

        public void OnGet()
        {
            // Ta metoda bi lahko vsebovala logiko za nalaganje podatkov, èe bi bili potrebni
        }
    }
}




/*

using Fitness.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.Pages
{
    public class ScheduleModel : PageModel
    {
        public Schedule WeeklySchedule { get; set; }
        public DateTime StartOfWeek { get; set; }
        
        // Metoda, ki se izvede ob zahtevi za stran ko imamo podatkovno bazo
        
        public void OnGet()
        {
            // Nastavite zaèetek tedna na ponedeljek trenutnega tedna
            StartOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            WeeklySchedule = new Schedule();
            // Tu bi naložili treninge iz "baze" ali kakršnegakoli drugega vira, za zdaj uporabimo zaèasne podatke
            WeeklySchedule.AddAppointment(new Appointment {  Nastavite potrebne lastnosti });
                                                                                               // Ponovite za dodajanje veè terminov
    }
        
    }
}
*/