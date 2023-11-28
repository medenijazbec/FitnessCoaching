using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Classes
{
    public class ProgressRecord
    {
        public DateTime Date { get; private set; }
        public string Notes { get; private set; }
        public Dictionary<string, double> Measurements { get; private set; } // Ključi so lahko 'Teža', 'Telesna maščoba', itd.

        public ProgressRecord(DateTime date, string notes)
        {
            Date = date;
            Notes = notes;
            Measurements = new Dictionary<string, double>();
        }

        // Dodajanje meritev (npr. teža, obseg pasu, itd.)
        public void AddMeasurement(string key, double value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Measurement key cannot be empty.");
            }

            Measurements[key] = value; // Dodaj ali posodobi meritev
        }

        // Pridobivanje meritev
        public double GetMeasurement(string key)
        {
            if (Measurements.TryGetValue(key, out double value))
            {
                return value;
            }

            throw new KeyNotFoundException($"Measurement key '{key}' not found.");
        }

        // Pridobivanje podrobnosti o napredku
        public string GetProgressDetails()
        {
            var details = new StringBuilder();
            details.AppendLine($"Date: {Date.ToShortDateString()}");
            details.AppendLine($"Notes: {Notes}");
            details.AppendLine("Measurements:");
            foreach (var measurement in Measurements)
            {
                details.AppendLine($"- {measurement.Key}: {measurement.Value}");
            }
            return details.ToString();
        }

       
    }
}
