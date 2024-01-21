using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.Classes
{
    public class ProgressTracker
    {
        public int Id { get; private set; }
        public User User { get; private set; }
        public List<ProgressRecord> ProgressRecords { get; private set; }

        public ProgressTracker(User user)
        {
            User = user;
            ProgressRecords = new List<ProgressRecord>();
        }

        // Dodajanje zapisa o napredku
        public void AddProgressRecord(ProgressRecord record)
        {
            ProgressRecords.Add(record);
        }

        // Odstranjevanje zapisa o napredku
        public bool RemoveProgressRecord(ProgressRecord record)
        {
            return ProgressRecords.Remove(record);
        }

        // Iskanje zapisa o napredku po datumu
        public ProgressRecord FindRecordByDate(DateTime date)
        {
            return ProgressRecords.FirstOrDefault(record => record.Date.Date == date.Date);
        }

        // Pridobivanje povzetka napredka
        public string GetProgressSummary()
        {
            var summary = new StringBuilder();
            summary.AppendLine($"Progress Summary for {User.Username}:");
            foreach (var record in ProgressRecords)
            {
                summary.AppendLine($"{record.Date.ToShortDateString()}: {record.Notes}");
            }
            return summary.ToString();
        }

        // Analiza napredka (lahko dodate bolj kompleksne analize)
        public string AnalyzeProgress(string measurementKey)
        {
            if (!ProgressRecords.Any())
            {
                return "No progress records to analyze.";
            }

            if (ProgressRecords[0].Measurements.ContainsKey(measurementKey) == false)
            {
                return $"No measurement data for key '{measurementKey}'.";
            }

            var analysis = new StringBuilder();
            analysis.AppendLine($"Progress Analysis for '{measurementKey}':");

            // Izračun povprečne spremembe za določen ključ meritev
            double totalChange = 0;
            int count = 0;
            for (int i = 1; i < ProgressRecords.Count; i++)
            {
                if (ProgressRecords[i].Measurements.ContainsKey(measurementKey))
                {
                    totalChange += CalculateChange(ProgressRecords[i - 1], ProgressRecords[i], measurementKey);
                    count++;
                }
            }

            if (count > 0)
            {
                double averageChange = totalChange / count;
                analysis.AppendLine($"Average change in '{measurementKey}': {averageChange}");
            }
            else
            {
                analysis.AppendLine("Not enough data to calculate average change.");
            }

            return analysis.ToString();
        }

        private double CalculateChange(ProgressRecord previousRecord, ProgressRecord currentRecord, string measurementKey)
        {
            double previousValue = previousRecord.Measurements[measurementKey];
            double currentValue = currentRecord.Measurements[measurementKey];
            return currentValue - previousValue;
        }
    }
}
