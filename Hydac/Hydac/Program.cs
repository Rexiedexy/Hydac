using Hydac;
using System.ComponentModel.DataAnnotations;

namespace Hydac
{
    public class Program
    {

        static DateTime GetDate(string date, string year, string atWhichHour) // Usage => Eks: DateTime s = GetDate("22-10", "2025", "18:00");
        {
            int parsedYear = int.Parse(year);
            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM", null);
            TimeSpan parsedTime = TimeSpan.Parse(atWhichHour);
            DateTime finalDate = new DateTime(
                parsedYear,
                parsedDate.Month,
                parsedDate.Day,
                parsedTime.Hours,
                parsedTime.Minutes,
                0
            );

            return finalDate;
        }

        static void Main(string[] args)
        {
            int options;
            int adminOptions;
            int id;
            bool programRunningNormally;
            int userinput;
            string password;

            Staff staff = new Staff();
            var logger = new Logger();
            var admin = new Admin(logger);
            admin.AdminInit();
            staff.StaffInit();
            MeetingRoom room = new MeetingRoom();

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome! Pick whats relevant for you\n");
                Console.WriteLine(" 1. Staff");
                Console.WriteLine(" 2. Guest");
                Console.WriteLine(" 3. Admin");
                Console.WriteLine(" 4. Exit");

                int.TryParse(Console.ReadLine(), out options);

                switch (options)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.Write("Type your staffID: ");
                            programRunningNormally = int.TryParse(Console.ReadLine(), out id);
                        } while (programRunningNormally != true);

                        Console.Clear();
                        Console.Write("Password: ");
                        password = Console.ReadLine();

                        var user = staff.LogIn(id, password);

                        if (user != null)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"Hello {user.Name}");
                                Console.WriteLine("How is your mood?\n");
                                Console.WriteLine(" 1. If you feel Green\n 2. If you feel Yellow\n 3. If you feel Red");
                                programRunningNormally = int.TryParse(Console.ReadLine(), out userinput);
                            } while (programRunningNormally != true || userinput >= 4 || userinput < 1);
                            Console.Clear();
                            Console.WriteLine("You are now registered, have a good day :D(sex)");
                            Console.ReadLine();
                            staff.SetStaffMood(Convert.ToString(user.Name), (Mood)(userinput - 1));
                            Console.Clear();

                            staff.LogOut(id, password);
                            DateTime bookning = new DateTime(30, 09, 2002, 3, 30, 01);
                            room.BookRoom(1,DateTime.Now, DateTime.Now);
                            room.ShowRooms();
                            Console.ReadKey();
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Staff id and password dosen't match");
                            Console.WriteLine("Press Enter to go back");
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Type in your guestID and take a seat in the lobby");
                        string guestId = Console.ReadLine();
                        admin.CheckGuestById(guestId);
                        break;

                    case 3:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(" 1. Add staff\n 2. Delete staff\n 3. Add guest\n 4. Delete guest\n 5. Show logs \n 6. Exit");
                            int.TryParse(Console.ReadLine(), out adminOptions);
                            switch (adminOptions)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Type in the name of the staff member");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Type in the ID of the staff member");
                                    int.TryParse(Console.ReadLine(), out id);
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Type in the ID of the staff member you want to delete");
                                    int.TryParse(Console.ReadLine(), out int removeId);
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.Write("Enter new Guest ID: ");
                                    string newGuestId = Console.ReadLine();

                                    Console.Write("Enter Guest Name: ");
                                    string newName = Console.ReadLine();

                                    Console.Write("Enter Company: ");
                                    string newCompany = Console.ReadLine();

                                    admin.AddGuest(newGuestId, newName, newCompany);
                                    Console.WriteLine("Guest added successfully.");
                                    Console.WriteLine("Press Enter to continue...");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Type in the ID of the guest you want to delete");
                                    string removeGuestId = Console.ReadLine();
                                    if (admin.RemoveGuest(removeGuestId))
                                    {
                                        Console.WriteLine("Guest removed successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Guest with ID {removeGuestId} not found.");
                                    }
                                    Console.WriteLine("Press Enter to continue...");
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Console.Clear();
                                    logger.ShowLogs();
                                    Console.WriteLine("Press Enter to continue...");
                                    Console.ReadKey();
                                    break;
                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("You have exited the admin menu");
                                    break;
                            }
                        } while (adminOptions != 6);
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("You have closed the program");
                        break;
                }
            } while (options != 4);

        }

    }
}

