namespace CarDealership
{
    internal class Program
    {
        
        static void Main()
        {
            Shop dealership = new Shop();
            Garage garage = new Garage();
            dealership.LoadCars();

            while (true) // loop to remember the menu
            {
                SimulatorStartMenu(dealership, garage); // starts menu
            }
        }

        public static void SimulatorStartMenu(Shop dealership, Garage garage)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Welcome to CarDealership Simulator!\n");
            Console.ResetColor();
            Console.WriteLine("1) Visit Dealership");
            Console.WriteLine("2) Garage");
            Console.WriteLine("3) Exit");

            char choice = Console.ReadKey(true).KeyChar;

            if (Int32.TryParse(choice.ToString(), out int menuChoice))
            {
                switch (menuChoice)
                {
                    case 1: // visits the dealership + fake fancy load
                        Console.Clear();
                        Console.WriteLine("Traveling to dealership..");
                        Thread.Sleep(300);
                        Console.Clear();
                        Console.WriteLine("Traveling to dealership...");
                        Thread.Sleep(300);
                        Console.Clear();
                        Console.WriteLine("Traveling to dealership....");
                        Thread.Sleep(300);
                        Console.Clear();
                        Console.WriteLine("Traveling to dealership.....");
                        dealership.Visit();
                        break;
                    case 2: // enters your garage.. you have to open the door so it takes some time...
                        Console.WriteLine("Entering garage..");
                        Thread.Sleep(600);
                        garage.Visit();
                        break;
                    case 3:
                        Environment.Exit(5252);
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"'{choice}' is not a valid input, please choose from 1 - 3.");
                Thread.Sleep(2500);
                Console.ResetColor();
                Main();
            }
        }
    }

}
// Hør med Marie hvordan hun bruker while løkker, både hvor og hvorfor. 