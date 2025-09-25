namespace Hydac
{
    public class Program
    {
        static void Main(string[] args)
        {
            string valgMuligheder;

            do
            {
                Console.Clear();
                Console.WriteLine("Velkommen! Vælg hvad der er relevant for dig\n");
                Console.WriteLine(" 1. Personale");
                Console.WriteLine(" 2. Gæster");
                Console.WriteLine(" 3. Booking af mødelokale");
                Console.WriteLine(" 4. Administrator");

                valgMuligheder = Console.ReadLine();

                switch (valgMuligheder)
                {
                    case "1": Staff; break;

                    case "2": Guest; break;

                    case "3": MeetingRoom; break;

                    case "4": Admin; break;
                }
            }
        }
    }
}
