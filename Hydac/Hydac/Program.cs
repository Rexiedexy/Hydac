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
            Staff staff = new Staff();
            staff.StaffInit();

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
                        Console.Clear();
                        Console.WriteLine("Type you'r staffID");

                        Console.WriteLine("How is your mood?\n");
                        Console.WriteLine(" 1. for Green\n 2. for yellow\n 3. for Red");

                        Console.WriteLine("You are now registe, have a good day :)");

                        DateTime.TryParse(Console.ReadLine(), out DateTime result);
                        Console.WriteLine(result);
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Type in your guestID and take a seat in the lobby");
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("What room would you like too book?\n");
                        Console.WriteLine(" 1. Small living room\n 2. Canteen\n 3. Aquarium\n 4. Small room\n 5. Big room");
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine(" 1. Add staff\n 2. Delete staff\n 3. Add guest\n 4. Delete guest");
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine(" Du har afsluttet programmet!");
                        break;
                }
            }while (options!= 5);
        }
    }
}
