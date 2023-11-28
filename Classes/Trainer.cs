using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Classes
{
    public class Trainer
    {
        public string Name { get; private set; }
        public string Specialty { get; private set; }
        public int YearsOfExperience { get; private set; }
        public List<string> Certifications { get; private set; }
        public Schedule Schedule { get; private set; }

        public Trainer(string name, string specialty, int yearsOfExperience)
        {
            Name = name;
            Specialty = specialty;
            YearsOfExperience = yearsOfExperience;
            Certifications = new List<string>();
            Schedule = new Schedule();
        }

        // Metoda za dodajanje certifikatov
        public void AddCertification(string certification)
        {
            Certifications.Add(certification);
        }

        // Metoda za načrtovanje termina z trenerjem
        public void ScheduleAppointment(Appointment appointment)
        {
            // Preverjanje za morebitne konflikte s trenutnim urnikom
            if (Schedule.Appointments.Any(a => a.ConflictsWith(appointment)))
            {
                throw new InvalidOperationException("The appointment conflicts with an existing appointment.");
            }

            Schedule.AddAppointment(appointment);
        }

        // Pridobivanje podrobnosti o trenerju
        public string GetTrainerDetails()
        {
            var details = new StringBuilder();
            details.AppendLine($"Trainer: {Name}");
            details.AppendLine($"Specialty: {Specialty}");
            details.AppendLine($"Years of Experience: {YearsOfExperience}");
            details.AppendLine("Certifications:");
            foreach (var cert in Certifications)
            {
                details.AppendLine($"- {cert}");
            }
            // Podrobnosti urnika lahko dodate tukaj, če je potrebno
            return details.ToString();
        }

        // Dodatne metode za nadaljnje upravljanje...
    }
}
