using Hydac;
using System.ComponentModel.DataAnnotations;

namespace Hydac
{
    public class Program
    {
        static void Main(string[] args)
        {
            int options;
            int adminOptions;
            int staffOptions;
            int id;
            int mood;
            string password;
            bool programRunningNormally;

            Staff staff = new Staff();
            var logger = new Logger();
            var admin = new Admin(logger);
            admin.AdminInit();
            staff.StaffInit();
            MeetingRoom room = new MeetingRoom();
                 string s = @"                                                                                                              
 /$$   /$$ /$$     /$$ /$$$$$$$   /$$$$$$   /$$$$$$ 
| $$  | $$|  $$   /$$/| $$__  $$ /$$__  $$ /$$__  $$
| $$  | $$ \  $$ /$$/ | $$  \ $$| $$  \ $$| $$  \__/
| $$$$$$$$  \  $$$$/  | $$  | $$| $$$$$$$$| $$      
| $$__  $$   \  $$/   | $$  | $$| $$__  $$| $$      
| $$  | $$    | $$    | $$  | $$| $$  | $$| $$    $$
| $$  | $$    | $$    | $$$$$$$/| $$  | $$|  $$$$$$/
|__/  |__/    |__/    |_______/ |__/  |__/ \______/                                                                                                                                                                                                                                                                                                                   
"; 
            
            do
            {
                Console.Clear();
                Console.WriteLine(s);
                Console.WriteLine("Welcome! Pick whats relevant for you\n");
                Console.WriteLine(" 1. Staff");
                Console.WriteLine(" 2. Guest");
                Console.WriteLine(" 3. Admin");
                Console.WriteLine(" 4. Exit");
                Console.Write("\n\nSelected: ");
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
                                Console.Write("\n\nSelected: ");
                                programRunningNormally = int.TryParse(Console.ReadLine(), out mood);
                            } while (programRunningNormally != true || mood >= 4 || mood < 1);

                            staff.SetStaffMood(Convert.ToString(user.Name), (Mood)(mood - 1));
                            Console.Clear();

                            do
                            {
                                Console.WriteLine($"You are now registered {user.Name}, have a good day :D\n");
                                Console.WriteLine("1. Book room");
                                Console.WriteLine("2. Go back");
                                Console.Write("\n\nSelected: ");
                                programRunningNormally = int.TryParse(Console.ReadLine(), out staffOptions);
                                Console.Clear();

                            } while (programRunningNormally != true || staffOptions >= 3 || staffOptions < 1);
                            switch (staffOptions)
                            {
                                case 1:
                                    int roomOption;
                                    int day;
                                    int month;
                                    int Houres = 0;
                                    int Minutes = 0;
                                    string timeInput;

                                    DateTime startTime;
                                    DateTime endTime = DateTime.MinValue;

                                    programRunningNormally = false;

                                    Console.WriteLine("Current bookings:");
                                    room.ShowRooms();
                                    Console.Write("\n\nWhised room to book: ");
                                    int.TryParse(Console.ReadLine(), out roomOption);
                                    Console.Write("\n\nWished day for the booking: ");
                                    int.TryParse(Console.ReadLine(), out day);
                                    Console.Write("\n\nWished month for the booking: ");
                                    int.TryParse(Console.ReadLine(), out month);

                                    do
                                    {
                                        Console.Write("\n\nWished time for the booking (HH:mm): ");
                                        timeInput = Console.ReadLine();

                                        string[] time = timeInput.Split(':');
                                        if (time.Length == 2)
                                        {
                                            int.TryParse(time[0], out Houres);
                                            int.TryParse(time[1], out Minutes);

                                            programRunningNormally = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong time format, try again!");
                                            Console.Clear();
                                            Console.WriteLine("Rooms:");
                                            room.ShowRooms();
                                        }
                                    } while (programRunningNormally != true);
                                    startTime = new DateTime(DateTime.Now.Year, month, day, Houres, Minutes, 00);

                                    programRunningNormally = false;
                                    do
                                    {
                                        Console.Write("\n\nWished time for the booking to stop (HH:mm): ");
                                        timeInput = Console.ReadLine();

                                        string[] time = timeInput.Split(':');
                                        if (time.Length == 2)
                                        {
                                            int.TryParse(time[0], out Houres);
                                            int.TryParse(time[1], out Minutes);
                                            endTime = new DateTime(DateTime.Now.Year, month, day, Houres, Minutes, 00);

                                            if (endTime > startTime)
                                            {
                                                programRunningNormally = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("End time must be after start time, try again");
                                                Console.Clear();
                                                Console.WriteLine("Current bookings:");
                                                room.ShowRooms();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong time format, try again!");
                                            Console.Clear();
                                            Console.WriteLine("Current bookings:");
                                            room.ShowRooms();
                                        }
                                    } while (programRunningNormally != true);

                                    room.BookRoom(roomOption - 1, startTime, endTime);
                                    Console.Clear();
                                    room.ShowRooms();
                                    Console.WriteLine("\nYour room has been booked press Enter to go back");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    break;
                            }
                            staff.LogOut(id, password);
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
                        Console.Write("\nGuesID: ");
                        string guestId = Console.ReadLine();
                        admin.CheckGuestById(guestId);
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Type your adminID: ");
                        string adminId = Console.ReadLine();

                        Console.Clear();
                        Console.Write("Admin password: ");
                        password = Console.ReadLine();

                        var adminMember = admin.LogIn(adminId, password);
                        if (adminMember != null)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(" 1. Add staff\n 2. Delete staff\n 3. Add guest\n 4. Delete guest\n 5. Show logs \n 6. Show Staff \n 7. Show Guest \n 8. Exit");
                                Console.Write("\n\nSelected: ");
                                int.TryParse(Console.ReadLine(), out adminOptions);
                                switch (adminOptions)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Type in the name of the staff member");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("Type in the ID of the staff member");
                                        int.TryParse(Console.ReadLine(), out id);
                                        Console.WriteLine("Type in the Password of the staff member");
                                        if (admin.AddStaff(name, id, Console.ReadLine()))
                                            Console.WriteLine($"Added {name} as a staffmember");
                                        else
                                            Console.WriteLine($"Failed to Add {name}");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Type in the ID of the staff member you want to delete");
                                        int.TryParse(Console.ReadLine(), out int removeId);
                                        Console.WriteLine("Type Name Of Staff Member : ");
                                        string name32 = Console.ReadLine();
                                        Console.WriteLine("Type Password Of Staffmember");
                                        string passwwwwwww = Console.ReadLine();
                                        admin.RemoveStaff(name32, removeId, passwwwwwww);
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
                                        staff.ShowStaff();
                                  
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 7:
                                        Console.Clear();
                                   
                                        admin.ShowGuests();

                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 8:
                                        Console.Clear();
                                        Console.WriteLine("You have exited the admin menu");
                                        System.Threading.Thread.Sleep(1000);
                                        admin.LogOut(adminId, password);
                                        break;
                                }
                            } while (adminOptions != 8);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Admin password is incorrect.");
                            Console.WriteLine("Press Enter to go back");
                            Console.ReadKey();
                        }
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
