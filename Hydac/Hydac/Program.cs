namespace Hydac
{
    public class Program
    {
        static void Main(string[] args)
        {
            MeetingRoom mr = new MeetingRoom();
            mr.BookRoom(1, DateTime.Now, DateTime.Now.AddHours(2));

            foreach (var room in mr.Rooms)
            {
                Console.WriteLine($"\n\n\n{room.name} (Size: {room.size}) - Booked: {room.start} to {room.end}");
            }
        }
    }
}
