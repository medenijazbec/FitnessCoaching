using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.Classes
{
    public class TrainingProgram
    {
        public int Id { get; private set; }
        public string ProgramName { get; private set; }
        public List<WorkoutSession> WorkoutSessions { get; private set; }

        public TrainingProgram(string programName)
        {
            ProgramName = programName;
            WorkoutSessions = new List<WorkoutSession>();
        }

        // Dodajanje vadbenih sej v program
        public void AddWorkoutSession(WorkoutSession session)
        {
            WorkoutSessions.Add(session);
        }

        // Odstranjevanje vadbenih sej iz programa
        public bool RemoveWorkoutSession(WorkoutSession session)
        {
            return WorkoutSessions.Remove(session);
        }

        // Iskanje vadbenih sej po kriterijih
        public IEnumerable<WorkoutSession> FindWorkoutSessions(Func<WorkoutSession, bool> predicate)
        {
            return WorkoutSessions.Where(predicate);
        }

        // Pridobivanje podrobnosti o trenirnem programu
        public string GetTrainingProgramDetails()
        {
            var details = new StringBuilder();
            details.AppendLine($"Training Program: {ProgramName}");
            details.AppendLine("Workout Sessions:");
            foreach (var session in WorkoutSessions)
            {
                details.AppendLine($"- {session.GetSessionDetails()}");
            }
            return details.ToString();
        }

        // Analiza trenirnega programa
        public string AnalyzeProgram()
        {
            // Tukaj lahko dodate bolj specifično analizo, na primer povprečno trajanje seje, raznolikost vaj, itd.
            var analysis = new StringBuilder();
            analysis.AppendLine($"Analysis of Training Program: {ProgramName}");

            if (WorkoutSessions.Any())
            {
                var averageDuration = WorkoutSessions.Average(session => (session.EndTime - session.StartTime).TotalMinutes);
                analysis.AppendLine($"Average Session Duration: {averageDuration} minutes");
                // Dodajte še druge analize
            }
            else
            {
                analysis.AppendLine("No sessions to analyze.");
            }

            return analysis.ToString();
        }

        // Dodatne metode za nadaljnje upravljanje...
    }
}
