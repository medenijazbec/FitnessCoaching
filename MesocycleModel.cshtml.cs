using Fitness.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Fitness.Pages
{
    public class MesocycleModel : PageModel
    {
        public List<WorkoutSession> WeeklyWorkoutSessions { get; set; }
        public DateTime StartOfWeek { get; set; }

        public MesocycleModel()
        {
            WeeklyWorkoutSessions = new List<WorkoutSession>();

            // Nastavite zaèetek tedna na ponedeljek trenutnega tedna
            StartOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            // Ustvarite testne seje vadbe za teden
            for (int i = 0; i < 7; i++) // 7 dni
            {
                DateTime sessionDate = StartOfWeek.AddDays(i);
                WeeklyWorkoutSessions.Add(new WorkoutSession(
                    $"Training Day {i + 1}",
                    "Full body workout",
                    TimeSpan.FromHours(1.5),
                    (DifficultyLevel)(i % 3), // Nakljuèno dodeljena težavnostna stopnja
                    sessionDate.AddHours(9), // Zaèetek ob 9:00
                    sessionDate.AddHours(10.5) // Konec ob 10:30
                ));
            }
        }

        public void OnGet()
        {
            // V tem primeru ni dodatne logike potrebne, saj so podatki že inicializirani v konstruktorju
        }
    }
}

