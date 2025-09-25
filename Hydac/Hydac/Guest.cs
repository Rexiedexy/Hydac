using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class Guest
    {
        private List<string> guestList = new List<string>();
        public void AddGuest(string name) => guestList.Add(name);

        public void RemoveGuest(string name) => guestList.Remove(name);
        public string name;
        public string Firmanavn;
        public string TimeOfArrival;
        public string guestId;

        public void ShowGuests()
        {
            if(guestList.Count == 0)
            {
                Console.WriteLine("No guests available.");
                return;
            }
            else
                foreach (var guest in guestList)
                {
                    Console.WriteLine(guest);
                }
        }
        public void safetyFolder()
        {
            Console.WriteLine("Safety folder has been handed out to the guest.");
        }
    }
}
