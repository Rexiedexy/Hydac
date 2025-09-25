namespace Hydac
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            MeetingRoom mr = new MeetingRoom();
            mr.BookRoom(16, 00);

            foreach (var room in rooms)
            {
                Console.WriteLine($"{room.name} (Størrelse: {room.size}) - Booket: {room.start} til {room.end}");
            }
        }
    }
}
