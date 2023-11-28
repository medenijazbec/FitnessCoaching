using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.Classes
{
    public class MuscleGroup
    {
        public string Name { get; private set; }
        public List<Exercise> Exercises { get; private set; }

        public MuscleGroup(string name)
        {
            Name = name;
            Exercises = new List<Exercise>();
        }

        public void AddExercise(Exercise exercise)
        {
            if (exercise.TargetMuscleGroup == this)
            {
                Exercises.Add(exercise);
            }
            else
            {
                throw new InvalidOperationException("Exercise targets a different muscle group.");
            }
        }

        public bool RemoveExercise(Exercise exercise)
        {
            return Exercises.Remove(exercise);
        }

        public Exercise FindExerciseByName(string exerciseName)
        {
            return Exercises.FirstOrDefault(e => e.Name.Equals(exerciseName, StringComparison.OrdinalIgnoreCase));
        }

        public string GetMuscleGroupDetails()
        {
            var details = new StringBuilder();
            details.AppendLine($"Muscle Group: {Name}");
            details.AppendLine("Exercises:");
            foreach (var exercise in Exercises)
            {
                details.AppendLine($"- {exercise.Name}");
            }
            return details.ToString();
        }

    }
}
