using System.Text;

namespace Fitness.Classes
{
    public class Schedule
    {
        public int Id { get; private set; }
        public List<Appointment> Appointments { get; private set; }

        public Schedule()
        {
            Appointments = new List<Appointment>();
        }

        // Dodajanje novega termina
        public void AddAppointment(Appointment appointment)
        {
            if (Appointments.Any(a => a.ConflictsWith(appointment)))
            {
                throw new InvalidOperationException("Appointment conflicts with an existing appointment.");
            }
            Appointments.Add(appointment);
        }

        // Odstranjevanje termina
        public bool RemoveAppointment(Appointment appointment)
        {
            return Appointments.Remove(appointment);
        }

        // Iskanje termina po datumu
        public IEnumerable<Appointment> FindAppointmentsByDate(DateTime date)
        {
            return Appointments.Where(a => a.StartDate.Date == date.Date);
        }

        // Pridobivanje urnika za določen časovni okvir
        public IEnumerable<Appointment> GetAppointmentsInRange(DateTime startDate, DateTime endDate)
        {
            return Appointments.Where(a => a.StartDate >= startDate && a.EndDate <= endDate);
        }

        // Pridobivanje podrobnosti urnika
        public string GetScheduleDetails()
        {
            var details = new StringBuilder();
            foreach (var appointment in Appointments)
            {
                details.AppendLine($"Appointment: {appointment.Description}, Start: {appointment.StartDate}, End: {appointment.EndDate}");
            }
            return details.ToString();
        }
    }
}
