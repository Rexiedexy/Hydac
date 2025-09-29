using System.ComponentModel.DataAnnotations;

namespace Hydac
{
    public class Program
    {
        static void Main(string[] args)
        {
            string options;

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome! Pick whats relevant for you\n");
                Console.WriteLine(" 1. Staff");
                Console.WriteLine(" 2. Guest");
                Console.WriteLine(" 3. Booking of meeting rooms");
                Console.WriteLine(" 4. Admin");

                options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Type you'r staffID");

                        Console.WriteLine("How is your mood?\n");
                        Console.WriteLine(" 1. for Green\n 2. for yellow\n 3. for Red");
                       
                        Console.WriteLine("You are now registe, have a good day :)");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Type in your guestID and take a seat in the lobby");
                        break;
                        
                    case "3": 
                        Console.Clear();
                        Console.WriteLine("What room would you like too book?\n");
                        Console.WriteLine(" 1. Small living room\n 2. Canteen\n 3. Aquarium\n 4. Small room\n 5. Big room");
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine(" 1. Add staff\n 2. Delete staff\n 3. Add guest\n 4. Delete guest");
                        break;
            }
        }
    }
}
