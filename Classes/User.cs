using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fitness.Classes
{
    public class User
    {
        private string username;
        private string passwordHash;
        private List<Appointment> appointments;
        private List<ProgressRecord> progressRecords;

        public string Username { get { return username; } }

        // Password je sedaj privatno in ni dostopno direktno
        private string Password { set { passwordHash = HashPassword(value); } }

        public User(string username, string password)
        {
            this.username = username;
            this.Password = password; // Shranitev zgoščene vrednosti gesla
            appointments = new List<Appointment>();
            progressRecords = new List<ProgressRecord>();
        }

        // Metoda za dodajanje termina
        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        // Metoda za odstranjevanje termina
        public bool CancelAppointment(Appointment appointment)
        {
            return appointments.Remove(appointment);
        }

        // Metoda za iskanje napredka
        public ProgressRecord FindProgressRecordByDate(DateTime date)
        {
            return progressRecords.FirstOrDefault(p => p.Date.Date == date.Date);
        }

        // Metoda za spremembo gesla
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        // Metoda za preverjanje gesla
        public bool CheckPassword(string password)
        {
            return passwordHash == HashPassword(password);
        }

        // Metoda za hashiranje gesla
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Dodatne metode...
    }
}
