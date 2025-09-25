using System.ComponentModel.DataAnnotations;

namespace Hydac
{
    public class Program
    {
        static void Main()
        {
            var logger = new Logger();
            var admin = new Admin(logger);

            // Tilføj nogle test-gæster
            admin.AddGuest("G1", "Anders", "Hydac");
            admin.AddGuest("G2", "Maria", "Siemens");

            while (true)
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("1. I am a Guest");
                Console.WriteLine("2. Show All Guests (Admin)");
                Console.WriteLine("3. Add Guest (Admin)");
                Console.WriteLine("4. Remove Guest (Admin)");
                Console.WriteLine("5. Show Logs");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Guest login
                        Console.Write("Enter your Guest ID: ");
                        string guestId = Console.ReadLine();
                        admin.CheckGuestById(guestId);
                        break;

                    case "2": // Show all guests
                        admin.ShowAllGuests();
                        break;

                    case "3": // Add guest
                        Console.Write("Enter new Guest ID: ");
                        string newId = Console.ReadLine();

                        Console.Write("Enter Guest Name: ");
                        string newName = Console.ReadLine();

                        Console.Write("Enter Company: ");
                        string newCompany = Console.ReadLine();

                        admin.AddGuest(newId, newName, newCompany);
                        Console.WriteLine("Guest added successfully.");
                        break;

                    case "4": // Remove guest
                        Console.Write("Enter Guest ID to remove: ");
                        string removeId = Console.ReadLine();
                        admin.RemoveGuest(removeId);
                        break;

                    case "5": // Show logs
                        logger.ShowLogs();
                        break;

                    case "6": // Exit
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    
}
}
