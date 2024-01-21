using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.Classes
{
    public class TrainingCycle
    {
        public int Id { get; private set; }
        public string CycleName { get; private set; }
        public List<TrainingProgram> TrainingPrograms { get; private set; }

        public TrainingCycle(string cycleName)
        {
            CycleName = cycleName;
            TrainingPrograms = new List<TrainingProgram>();
        }

        // Dodajanje usposabljanja v cikel
        public void AddTrainingProgram(TrainingProgram program)
        {
            TrainingPrograms.Add(program);
        }

        // Odstranjevanje usposabljanja iz cikla
        public bool RemoveTrainingProgram(TrainingProgram program)
        {
            return TrainingPrograms.Remove(program);
        }

        // Iskanje usposabljanja po imenu
        public TrainingProgram FindTrainingProgramByName(string programName)
        {
            return TrainingPrograms.FirstOrDefault(p => p.ProgramName.Equals(programName, StringComparison.OrdinalIgnoreCase));
        }

        // Pridobivanje podrobnosti cikla
        public string GetCycleDetails()
        {
            var details = new StringBuilder();
            details.AppendLine($"Training Cycle: {CycleName}");
            details.AppendLine("Training Programs:");
            foreach (var program in TrainingPrograms)
            {
                details.AppendLine($"- {program.ProgramName}");
            }
            return details.ToString();
        }

        // Analiza napredka v ciklu
        public string AnalyzeCycleProgress()
        {
            // Implementirajte logiko za analizo napredka v ciklu
            // Na primer, lahko izračunate povprečni napredek, dosežene cilje, itd.
            return "Cycle progress analysis not implemented yet.";
        }

        // Dodatne metode za nadaljnje upravljanje...
    }
}
