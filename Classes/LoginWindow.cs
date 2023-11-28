using System;
using Fitness.Classes;
using Fitness.Control;

namespace Fitness.Gui
{
    // Razred za prijavno okno
    public class LoginWindow
    {
        public event Action<object, User> LoginSuccessful;

        private FitnessController fitnessController;

        public LoginWindow(FitnessController controller)
        {
            fitnessController = controller;
        }

        public LoginWindow()
        {
        }

        public void Show()
        {
            // Logika za prikaz prijavnega okna
            Console.WriteLine("Login Window Opened");

            // Za demonstracijo - v praksi bi tu zbirali uporabniško ime in geslo
            string username = "demoUser";
            string password = "demoPass";

            if (fitnessController.Login(username, password))
            {
                // Za demonstracijo - v praksi bi tu ustvarili in vrnili pravi objekt User
                User user = new User(username, password);
                LoginSuccessful?.Invoke(this, user);
            }
        }

       
    }

   
}
