namespace Fitness.Classes
{
    public class DietItem
    {
        public int Id { get; private set; }
        public string ItemName { get; private set; }
        public int Calories { get; private set; }
        public float Proteins { get; private set; } // Grams
        public float Carbohydrates { get; private set; } // Grams
        public float Fats { get; private set; } // Grams
        public DateTime MealTime { get; private set; }
        public DietItem() { }
        public DietItem(string itemName, int calories, float proteins, float carbohydrates, float fats, DateTime mealTime)
        {
            if (calories < 0)
                throw new ArgumentOutOfRangeException(nameof(calories), "Calories cannot be negative.");
            if (proteins < 0)
                throw new ArgumentOutOfRangeException(nameof(proteins), "Proteins cannot be negative.");
            if (carbohydrates < 0)
                throw new ArgumentOutOfRangeException(nameof(carbohydrates), "Carbohydrates cannot be negative.");
            if (fats < 0)
                throw new ArgumentOutOfRangeException(nameof(fats), "Fats cannot be negative.");

            ItemName = itemName;
            Calories = calories;
            Proteins = proteins;
            Carbohydrates = carbohydrates;
            Fats = fats;
            MealTime = mealTime;
        }

        // Metoda za izračun energijske vrednosti na podlagi makrohranil
        public static int CalculateCalories(float proteins, float carbohydrates, float fats)
        {
            // Calories calculation based on macronutrients
            // Approximate values: 1g Protein = 4 kcal, 1g Carbohydrates = 4 kcal, 1g Fat = 9 kcal
            return (int)((proteins * 4) + (carbohydrates * 4) + (fats * 9));
        }
    }
}
