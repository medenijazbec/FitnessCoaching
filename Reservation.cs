namespace Fitness.Classes
{
    public class Reservation
    {
        public int Id { get; private set; }
        public User Member { get; private set; }
        public Appointment Appointment { get; private set; }
        public bool IsConfirmed { get; private set; }

        public Reservation(User member, Appointment appointment)
        {
            Member = member;
            Appointment = appointment;
            IsConfirmed = false;
        }

        // Metoda za potrditev rezervacije
        public void Confirm()
        {
            IsConfirmed = true;
        }

        // Metoda za preklic rezervacije
        public void Cancel()
        {
            IsConfirmed = false;
            // Dodatna logika, kot je obveščanje uporabnika in trenerja o preklicu, če je potrebno.
        }

        // Metoda za spremembo termina
        public void Reschedule(Appointment newAppointment)
        {
            if (IsConfirmed)
            {
                throw new InvalidOperationException("Cannot reschedule a confirmed appointment. Please cancel and create a new reservation.");
            }

            Appointment = newAppointment;
        }

        // Metoda za pridobivanje podrobnosti rezervacije
        public string GetReservationDetails()
        {
            return $"Reservation for {Member.Username} on {Appointment.StartDate} - Confirmed: {IsConfirmed}";
        }

        // Dodatne metode za nadaljnje upravljanje...
    }
}
