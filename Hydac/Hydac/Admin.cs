using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hydac
{
    public class Admin
    {
        private List<Guest> guests = new List<Guest>();
        private Logger logger;

        public Admin(Logger log)
        {
            logger = log;
        }

        public void AddGuest(string id, string name, string firmanavn)
        {
            if (!IsValidName(name))
            {
                Console.WriteLine("Invalid name! Name cannot contain numbers or special characters.");
                return;
            }

            guests.Add(new Guest(id, name, firmanavn, logger));
            Console.WriteLine($"Guest {name} ({firmanavn}) added successfully.");
        }
        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }


        public void CheckGuestById(string id)
        {
            var guest = guests.Find(g => g.GuestId == id);
            if (guest == null)
            {
                Console.WriteLine("Guest not found!");
                return;
            }

            Console.WriteLine("1. Check In");
            Console.WriteLine("2. Check Out");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            if (choice == "1")
                guest.CheckIn();
            else if (choice == "2")
                guest.CheckOut();
            else
                Console.WriteLine("Invalid choice.");
        }

        public void ShowAllGuests()
        {
            foreach (var g in guests)
            {
                Console.WriteLine($"{g.Name} ({g.Firmanavn}) [ID: {g.GuestId}] - {(g.IsCheckedIn ? "Checked In" : "Checked Out")}");
            }
        }
        public void RemoveGuest(string id)
        {
            var guest = guests.Find(g => g.GuestId == id);
            if (guest != null)
            {
                guests.Remove(guest);
                Console.WriteLine($"{guest.Name} ({guest.Firmanavn}) [ID: {guest.GuestId}] has been removed.");
            }
            else
            {
                Console.WriteLine($"Guest with ID {id} not found.");
            }
        }
    }
}

