using System;

namespace Fitness.Classes
{
    public class Membership
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public User Member { get; private set; }
        public bool IsActive { get { return DateTime.Now >= StartDate && DateTime.Now <= EndDate; } }

        public Membership(DateTime startDate, DateTime endDate, User member)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("EndDate must be greater than StartDate.");
            }

            StartDate = startDate;
            EndDate = endDate;
            Member = member;
        }

        // Metoda za obnovitev članstva
        public void RenewMembership(int extensionMonths)
        {
            if (extensionMonths <= 0)
            {
                throw new ArgumentException("Extension months must be greater than zero.");
            }

            // Predvidevamo, da se obnovitev izvede pred iztekom trenutnega članstva
            if (IsActive)
            {
                EndDate = EndDate.AddMonths(extensionMonths);
            }
            else
            {
                throw new InvalidOperationException("Membership is not active and cannot be renewed.");
            }
        }

        // Metoda za prekinitev članstva
        public void CancelMembership()
        {
            //še za dopolnit
            EndDate = DateTime.Now;
        }

        // Metoda za pridobivanje statusa članstva
        public string GetMembershipStatus()
        {
            return IsActive ? "Active" : "Inactive";
        }

        // Metoda za prilagajanje datuma začetka (v primeru napake ali posebne promocije)
        public void AdjustStartDate(DateTime newStartDate)
        {
            if (newStartDate >= EndDate)
            {
                throw new ArgumentException("New start date must be before the end date.");
            }

            StartDate = newStartDate;
        }

        // Metoda za prilagajanje datuma konca (v primeru podaljšanja ali skrajšanja članstva)
        public void AdjustEndDate(DateTime newEndDate)
        {
            if (newEndDate <= StartDate)
            {
                throw new ArgumentException("New end date must be after the start date.");
            }

            EndDate = newEndDate;
        }

        
    }
}
