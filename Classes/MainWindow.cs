using System;
using Fitness.Classes; // Za dostop do razredov v namespace-u Fitness.Classes
using Fitness.Control; // Predpostavimo, da imate kontrolni sloj z imenom Fitness.Control

namespace Fitness.Gui
{
    public class MainWindow
    {
        private User loggedInUser;
        private LoginWindow loginWindow;
        private FitnessController fitnessController;

        // Konstruktor
        public MainWindow()
        {
            // Inicializacija komponent in priprava vmesnika
            InitializeComponents();
        }

        // Metoda za nastavitev prijavljenega uporabnika
        public void SetLoggedInUser(User user)
        {
            loggedInUser = user;
            // Osvežite vmesnik ali prikažite pozdravno sporočilo
            UpdateUIWithUserDetails();
        }

        // Metoda za inicializacijo komponent
        private void InitializeComponents()
        {
            loginWindow = new LoginWindow();
            loginWindow.LoginSuccessful += OnLoginSuccessful;

            fitnessController = new FitnessController();
            // Dodatne inicializacije, če so potrebne
        }

        // Metoda, ki se sproži, ko uporabnik uspešno opravi prijavo
        private void OnLoginSuccessful(object sender, User user)
        {
            SetLoggedInUser(user);
        }

        // Metoda za osvežitev uporabniškega vmesnika
        private void UpdateUIWithUserDetails()
        {
            // Tukaj bi lahko prikazali ime uporabnika, njegove prihajajoče termine itd.
            Console.WriteLine($"Welcome {loggedInUser.Username}");
            // Prikazati bi morali tudi ustrezne kontrolnike ali panele glede na tip uporabnika (npr. trener, član itd.)
        }

        // Metode za upravljanje glavnega okna, kot so prikaz različnih pogledov, obdelava dogodkov itd.

        // Dodatne metode...
    }
}
