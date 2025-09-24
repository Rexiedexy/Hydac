using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class MeetingRoom
    {
        private (string name, int size, DateTime? start, DateTime? end)[] rooms =
            {
                ("Lille stue", 5, null, null),
                ("Kantine", 50, null, null),
                ("Aquarium", 30, null, null),
                ("Lille lokale", 8, null, null),
                ("Store lokale", 20, null, null)
            };
        public void BookRoom()
        {
            Console.Clear();
            Console.WriteLine(rooms[1]);

        }

    }
}
