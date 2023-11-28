namespace Fitness.Classes
{
    public class Exercise
    {
        public string Name { get; private set; }
        public MuscleGroup TargetMuscleGroup { get; private set; }
        public int Repetitions { get; private set; }
        public int Sets { get; private set; }
        public int RestInterval { get; private set; } // Rest interval in seconds
        public double Intensity { get; internal set; }

        public Exercise(string name, MuscleGroup muscleGroup, int repetitions, int sets, int restInterval)
        {
            if (repetitions <= 0 || sets <= 0 || restInterval < 0)
            {
                throw new ArgumentException("Invalid exercise parameters.");
            }

            Name = name;
            TargetMuscleGroup = muscleGroup;
            Repetitions = repetitions;
            Sets = sets;
            RestInterval = restInterval;
        }

        // Method to update the number of repetitions
        public void UpdateRepetitions(int newRepetitions)
        {
            if (newRepetitions <= 0)
            {
                throw new ArgumentException("Repetitions must be greater than zero.");
            }
            Repetitions = newRepetitions;
        }

        // Method to update the number of sets
        public void UpdateSets(int newSets)
        {
            if (newSets <= 0)
            {
                throw new ArgumentException("Sets must be greater than zero.");
            }
            Sets = newSets;
        }

        // Method to update the rest interval
        public void UpdateRestInterval(int newRestInterval)
        {
            if (newRestInterval < 0)
            {
                throw new ArgumentException("Rest interval must not be negative.");
            }
            RestInterval = newRestInterval;
        }

        // Method to display exercise details
        public string GetExerciseDetails()
        {
            return $"{Name}: {Sets} sets of {Repetitions} reps with {RestInterval} seconds rest. Target muscle group: {TargetMuscleGroup.Name}";
        }

        
    }
}
