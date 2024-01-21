using System.Text;

namespace Fitness.Classes
{
    public enum DifficultyLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public class WorkoutSession
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<Exercise> Exercises { get; private set; }
        public TimeSpan Duration { get; private set; }
        public DifficultyLevel Difficulty { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        
        public WorkoutSession(string title, string description, TimeSpan duration, DifficultyLevel difficulty, DateTime startTime, DateTime endTime)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Duration = duration;
            Difficulty = difficulty;
            Exercises = new List<Exercise>();
            StartTime = startTime;
            EndTime = endTime;
        }
        public string GetSessionDetails()
        {
            return $"Session: {Description}, Starts at: {StartTime}, Ends at: {EndTime}";
        }
        public bool ConflictsWith(WorkoutSession otherSession)
        {
            // Preverite, ali se časovni intervali prekrivajo
            return StartTime < otherSession.EndTime && EndTime > otherSession.StartTime;
        }
        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
        }
        public void RemoveExercise(Exercise exercise)
        {
            Exercises.Remove(exercise);
        }

        public double CalculateTotalIntensity()
        {
            // Ta metoda predpostavlja, da ima vsaka vaja neko oceno intenzivnosti
            if (!Exercises.Any())
            {
                return 0;
            }

            return Exercises.Average(exercise => exercise.Intensity);
        }

        public void AdjustDuration(TimeSpan newDuration)
        {
            Duration = newDuration;
            // Prilagodite tudi EndTime, če je potrebno
            EndTime = StartTime + newDuration;
        }

        public string GetFullSessionDetails()
        {
            var details = new StringBuilder(GetSessionDetails());
            details.AppendLine($"Duration: {Duration.TotalMinutes} minutes");
            details.AppendLine($"Difficulty: {Difficulty}");
            details.AppendLine("Exercises:");
            foreach (var exercise in Exercises)
            {
                details.AppendLine($"- {exercise.Name}");
            }
            return details.ToString();
        }

    }
}
