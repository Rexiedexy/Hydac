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
    }
}
