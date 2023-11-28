using System;

namespace Fitness.Classes
{
    public class Payment
    {
        public User Payer { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string PaymentMethod { get; private set; }

        public Payment(User payer, decimal amount, DateTime paymentDate, string paymentMethod)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            Payer = payer;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
        }

        // Metoda za validacijo plačila
        public bool ValidatePayment()
        {
            //dodatna logika
            return true; 
        }

        // Metoda za zapisovanje transakcije
        public string RecordTransaction()
        {
           //dodatna logika
           return $"Payment recorded: {Amount} paid on {PaymentDate} via {PaymentMethod}.";
        }

        // Metoda za generiranje poročila o plačilu
        public string GeneratePaymentReport()
        {
            // Generiranje poročila o plačilu
            return $"Payment Report -- Payer: {Payer.Username}, Amount: {Amount}, Date: {PaymentDate}, Method: {PaymentMethod}";
        }

        // Additional methods for further payment processing...
    }
}
