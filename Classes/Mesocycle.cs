using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.Classes
{
    // Razred za mesocikle
    public class Mesocycle
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<WorkoutSession> WorkoutSessions { get; private set; }

        public Mesocycle(string name, DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("EndDate must be greater than StartDate.");
            }

            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            WorkoutSessions = new List<WorkoutSession>();
        }

        // Dodajanje vadbenih sej v mesocikel
        public void AddWorkoutSession(WorkoutSession session)
        {
            // Preverite, ali se vadbeni termini ne prekrivajo
            if (WorkoutSessions.Any(ws => ws.ConflictsWith(session)))
            {
                throw new InvalidOperationException("Workout session conflicts with an existing session.");
            }

            WorkoutSessions.Add(session);
        }

        // Odstranjevanje vadbenih sej iz mesocikla
        public bool RemoveWorkoutSession(WorkoutSession session)
        {
            return WorkoutSessions.Remove(session);
        }

        // Pridobivanje podrobnosti o mesociklu
        public string GetMesocycleDetails()
        {
            var details = new StringBuilder();
            details.AppendLine($"Mesocycle: {Name}");
            details.AppendLine($"Start Date: {StartDate.ToShortDateString()}");
            details.AppendLine($"End Date: {EndDate.ToShortDateString()}");
            details.AppendLine("Workout Sessions:");
            foreach (var session in WorkoutSessions)
            {
                details.AppendLine($"- {session.GetSessionDetails()}");
            }
            return details.ToString();
        }

        // Prilagajanje datuma začetka in konca mesocikla
        public void AdjustCycleDates(DateTime newStartDate, DateTime newEndDate)
        {
            if (newStartDate >= newEndDate)
            {
                throw new ArgumentException("New start date must be before the new end date.");
            }

            StartDate = newStartDate;
            EndDate = newEndDate;
        }

        // Additional methods for further management...
    }
}
