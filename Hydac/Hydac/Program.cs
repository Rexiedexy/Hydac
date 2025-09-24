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

                valgMuligheder = Console.ReadKey();

                switch (valgMuligheder)
                {
                    case "1": 
                    
                    case "2": 

                    case "3": 

                    case "4": 
                }
             }    
            Console.WriteLine("Hello, World!");
        }
    }
}
