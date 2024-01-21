using System.Text;

namespace Fitness.Classes
{
    public class DietPlan
    {
        public int Id { get; private set; }
        public string PlanName { get; private set; }
        public List<DietItem> DietItems { get; private set; }

        public DietPlan(string planName)
        {
            PlanName = planName;
            DietItems = new List<DietItem>();
        }

        // Dodajanje prehranske postavke v načrt
        public void AddDietItem(DietItem item)
        {
            DietItems.Add(item);
        }

        // Odstranjevanje prehranske postavke iz načrta
        public bool RemoveDietItem(DietItem item)
        {
            return DietItems.Remove(item);
        }

        // Iskanje prehranske postavke po imenu
        public DietItem FindDietItemByName(string itemName)
        {
            return DietItems.FirstOrDefault(item => item.ItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        // Izračun skupnega števila kalorij v načrtu
        public int CalculateTotalCalories()
        {
            return DietItems.Sum(item => item.Calories);
        }

        // Izračun povprečja kalorij na obrok
        public double CalculateAverageCaloriesPerMeal()
        {
            return DietItems.Any() ? DietItems.Average(item => item.Calories) : 0;
        }

        // Pridobivanje podrobnosti o prehranskem načrtu
        public string GetDietPlanDetails()
        {
            var details = new StringBuilder();
            details.AppendLine($"Diet Plan: {PlanName}");
            details.AppendLine("Items:");
            foreach (var item in DietItems)
            {
                details.AppendLine($"- {item.ItemName}: {item.Calories} calories");
            }
            details.AppendLine($"Total Calories: {CalculateTotalCalories()}");
            return details.ToString();
        }

        
    }
}
