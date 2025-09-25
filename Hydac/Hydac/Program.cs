namespace Hydac
{
    public class Program
    {
        static void Main(string[] args)
        {
            string options;

            do
            {
                Console.Clear();
                Console.WriteLine("Velkommen! Vælg hvad der er relevant for dig\n");
                Console.WriteLine(" 1. Personale");
                Console.WriteLine(" 2. Gæster");
                Console.WriteLine(" 3. Booking af mødelokale");
                Console.WriteLine(" 4. Administrator");

                options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Indtast din personaleid");

                        Console.WriteLine("Hvad er dit humør?\n");
                        Console.WriteLine(" Tryk 1. for Grøn\n Tryk 2. for Gul\n Tryk 3. for Rød");
                       
                        Console.WriteLine("Du er nu regisreret, god arbejdslyst :)");

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Indtast dit tilsendte gæsteid og tag derefter plads i lobbyen");
                        
                    case "3": 
                        Console.Clear();
                        Console.WriteLine("Hvilket mødelokale kunne du tænke dig at booke?\n");
                        Console.WriteLine(" 1. Small living room\n 2. Canteen\n 3. Aquarium\n 4. Small room\n 5. Big room");

                    case "4":
                        Console.Clear();
                        Console.WriteLine(" 1. Tilføj personale\n 2. Slet personale\n 3. Tilføj gæst\n 4. Slet gæst");
            }
        }
    }
}
