
namespace Fitness.Classes
{
    // Razred za termin vadbe
    public class Appointment
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Description { get; private set; }

        // Konstruktor
        public Appointment(DateTime startDate, DateTime endDate, string description)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("EndDate must be greater than StartDate.");
            }

            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

        // Metoda za preverjanje, ali se dva termina prekrivata
        public bool ConflictsWith(Appointment otherAppointment)
        {
            return StartDate < otherAppointment.EndDate && EndDate > otherAppointment.StartDate;
        }

        // Metoda za posodobitev termina
        public void Reschedule(DateTime newStartDate, DateTime newEndDate)
        {
            if (newEndDate <= newStartDate)
            {
                throw new ArgumentException("New EndDate must be greater than new StartDate.");
            }

            StartDate = newStartDate;
            EndDate = newEndDate;
        }

        // Metoda za podaljšanje trajanja termina
        public void ExtendDuration(TimeSpan additionalTime)
        {
            if (additionalTime <= TimeSpan.Zero)
            {
                throw new ArgumentException("Additional time must be greater than zero.");
            }

            EndDate = EndDate.Add(additionalTime);
        }

        // Metoda za skrajšanje trajanja termina
        public void ShortenDuration(TimeSpan reductionTime)
        {
            if (reductionTime <= TimeSpan.Zero || reductionTime >= EndDate - StartDate)
            {
                throw new ArgumentException("Reduction time must be greater than zero and less than the current duration of the appointment.");
            }

            EndDate = EndDate.Subtract(reductionTime);
        }

        // ... dodajte še ostale metode in logiko po potrebi
    }
}


