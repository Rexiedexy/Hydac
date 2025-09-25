using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class Guest
    {
        public string GuestId { get; set; }
        public string Name { get; set; }
        public string Firmanavn { get; set; }
        public bool IsCheckedIn { get; set; }

        private Logger logger;

        public Guest(string id, string name, string firmanavn, Logger loggerInstance)
        {
            GuestId = id;
            Name = name;
            Firmanavn = firmanavn;
            IsCheckedIn = false;
            logger = loggerInstance;
        }

        public void CheckIn()
        {
            if (!IsCheckedIn)
            {
                IsCheckedIn = true;
                logger.Log($"{Name} ({Firmanavn}) [ID: {GuestId}] has checked in.");
                Console.WriteLine($"{Name} from {Firmanavn} has checked in.");
            }
            else
            {
                Console.WriteLine($"{Name} is already checked in.");
            }
        }

        public void CheckOut()
        {
            if (IsCheckedIn)
            {
                IsCheckedIn = false;
                logger.Log($"{Name} ({Firmanavn}) [ID: {GuestId}] has checked out.");
                Console.WriteLine($"{Name} from {Firmanavn} has checked out.");
            }
            else
            {
                Console.WriteLine($"{Name} is not checked in.");
            }
        }
        
        public void safetyFolder()
        {
            Console.WriteLine("Safety folder has been handed out to the guest.");
        }
    }
}
