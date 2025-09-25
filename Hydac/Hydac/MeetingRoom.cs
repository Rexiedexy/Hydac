using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    public class MeetingRoom
    {
        private int userInput;
        private (string name, int size, DateTime? start, DateTime? end)[] rooms =
            {
                ("Small living room", 5, null, null),
                ("Canteen", 50, null, null),
                ("Aquarium", 30, null, null),
                ("Small room", 8, null, null),
                ("Big room", 20, null, null)
            };
        public bool BookRoom(string roomName, DateTime start, DateTime end)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].name == roomName)
                {
                    if (rooms[i].start == null || rooms[i].end <= start)
                    {
                        rooms[i].start = start;
                        rooms[i].end = end;
                        Console.WriteLine($"{roomName} er nu booket fra {start} til {end}");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine($"{roomName} er ikke ledigt i det ønskede tidsrum");
                    return false;
                }
            }
        }
    }
}
