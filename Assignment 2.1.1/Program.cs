using System.Xml.Serialization;

namespace Assignment_2._1._1
{
    internal class Program
    {
    
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Appointment Portal");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1)Make New Appointment");
            Console.WriteLine("2)View Appointments");
            Console.WriteLine("3)Update Existing Appointment");
            Console.WriteLine("4)Delete Appointment");

        

        }
        void MainMenu()
        {
            Console.WriteLine("Welcome to the Appointment Portal");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1)Make New Appointment");
            Console.WriteLine("2)View Appointments");
            Console.WriteLine("3)Update Existing Appointment");
            Console.WriteLine("4)Delete Appointment");
            int mainMenuChoice;

            switch (mainMenuChoice)
            {
                case 1:
                    // Call method to make new appointment
                    break;
                case 2:
                    // Call method to view appointments
                    break;
                case 3:
                    // Call method to update existing appointment
                    break;
                case 4:
                    // Call method to delete appointment
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    MainMenu();
                    break;
            }



        }
    }
}
