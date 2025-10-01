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
            ("Small living room", 5, null, null),
            ("Canteen", 50, null, null),
            ("Aquarium", 30, null, null),
            ("Small room", 8, null, null),
            ("Big room", 20, null, null)
        };

        public (string name, int size, DateTime? start, DateTime? end)[] Rooms
        {
            get { return rooms; }
        }

        public bool BookRoom(int userInput, DateTime start, DateTime end)
        {
            Logger logger = new Logger();

            if (userInput < 0 || userInput >= rooms.Length)
            {
                Console.WriteLine("Invalid room choice");
                logger.Log("Invalid room choice");
                return false;
            }

            if (rooms[userInput].start == null || rooms[userInput].end <= start)
            {
                rooms[userInput].start = start;
                rooms[userInput].end = end;
                Console.WriteLine($"{rooms[userInput].name} is now booked from {start} to {end}");

                logger.Log($"{rooms[userInput].name} is now booked from {start} to {end}");
                return true;
            }

            else
            {
                Console.WriteLine($"{rooms[userInput].name} is not available at the requested time");
                logger.Log($"{rooms[userInput].name} is not available at the requested time");
                return false;
            }
        }

        public void ShowRooms()
        {
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room: {room.name} - Room Size: {room.size} - Booked from: {room.start} - Booked to: {room.end}");
            }
        }
    }
}
