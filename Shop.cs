namespace CarDealership
{
    internal class Shop
    {
        private static List<Car> _shopCars = new List<Car>();

        public void LoadCars()
        {
            Car[] cars = new Car[] // Loading cars in an array
            {
                new Car("Toyota", 2015, "ABC123", 55000),
                new Car("Honda", 2016, "DEF456", 45000),
                new Car("Ford", 2017, "GHI789", 42000),
                new Car("Chevrolet", 2018, "JKL012", 21000),
                new Car("Nissan", 2019, "MNO345", 22000),
                new Car("BMW", 2020, "PQR678", 15000),
                new Car("Audi", 2021, "STU901", 16000),
                new Car("Mercedes", 2014, "VWX234", 87000),
                new Car("Hyundai", 2013, "YZA567", 90000),
                new Car("Kia", 2012, "BCD890", 99000),
                new Car("Mazda", 2011, "EFG123", 110000),
                new Car("Subaru", 2010, "HIJ456", 117000),
                new Car("Volkswagen", 2009, "KLM789", 121000),
                new Car("Volvo", 2008, "NOP012", 140000),
                new Car("Lexus", 2007, "QRS345", 149000),
                new Car("Jaguar", 2006, "TUV678", 142000),
                new Car("Porsche", 2005, "WXY901", 125000),
                new Car("Land Rover", 2004, "ZAB234", 16000),
                new Car("Tesla", 2022, "CDE567", 5000),
                new Car("Ferrari", 2023, "FGH890", 2000)
            };

            _shopCars.AddRange(
                cars); // Loads the array into _shopCars - AddRange as it adds multiple objects, if I were to use Add only one object would be permitted per line
        }

        public void ShowCars(List<Car> cars)
        {
            Console.Clear();
            foreach (Car car in cars) // Loops through each car in the shop and prints them out.
            {
                Console.WriteLine(
                    $"Make: {car.Make}\nYear: {car.Year}\nLicense Plate: {car.Licenseplate}\nKM: {car.Km}\n");
            }

            Thread.Sleep(1000);
            BuyCarFromDealership(
                cars); // Prompts you to either buy a car by typing out the license plate, or leave by typing 'x'.

        }

        public void Visit()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Prints header
                Console.WriteLine("Welcome to GET Dealership!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Your only stop for used cars.\n"); // Prints slogan
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("1) Show Cars"); // Prints menu
                Console.WriteLine("2) Filter by KM");
                Console.WriteLine("3) Filter by Year");
                Console.WriteLine("4) Leave Dealership");


                char
                    choice = Console.ReadKey(true)
                        .KeyChar; // Takes choice and tries to parse, if it fails you get an error message, if not it follows through
                if (Int32.TryParse(choice.ToString(), out int menuChoice))
                {
                    switch (menuChoice)
                    {
                        case 1:
                            ShowCars(
                                _shopCars); // Defines what list to show, as we have filtering which uses a temporary list.(filteredCars)
                            break;
                        case 2:
                            ShowCarsSpecificToKm(); // Fetches cars which have a KM within 10.000 and -10.000 of the given value.
                            break;
                        case 3:
                            ShowCarsSpecificToYear(); // Fetches cars which have a Year value within 3 and -3 of the given value.
                            break;
                        case 4:
                            return; // Exits the Visit method and goes back to the original menu loop.
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        "Not a valid input. Try again."); // If menu input is not int parsable, give error and try again.
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    break;
                }
            }
        }

        private void ShowCarsSpecificToKm() // Filtering for KM
        {
            List<Car> filteredCars = null;

            Console.Write("\nHow many KM has your desired vehicle traveled?: ");
            string desiredKmStr = Console.ReadLine();
            if (Int32.TryParse(desiredKmStr, out int desiredKm))
            {
                filteredCars =
                    _shopCars // Filters _shopCars and looks for cars that have a km range within 10.000 of the given value and adds them to the list (filteredCars)
                        .Where(car => car.Km >= (desiredKm - 10000) && car.Km <= (desiredKm + 10000))
                        .ToList();
            }
            else // If input is not parsable to int, give an error and try again.
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid input. Try again.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            if (filteredCars != null &&
                filteredCars.Count >
                0) // If filter has content, and is greater than 0, show the cars in the newly created list.
            {
                ShowCars(filteredCars);
            }
            else if
                (filteredCars.Count <=
                 0) // tried to do a normal else, but filteredCars.Count is 0 and not null even though I set it to null.
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No cars matching the criteria were found.");
                Console.ResetColor();
                Thread.Sleep(2500);
                return;
            }
        }

        private void
            ShowCarsSpecificToYear() // Same as the above only with year and the min max value being +3 -3 instead of 10.000
        {
            List<Car> filteredCars = null;
            Console.Write("\nWhich year are you interested in?: ");
            string desiredYearStr = Console.ReadLine();
            if (Int32.TryParse(desiredYearStr, out int desiredYear))
            {
                filteredCars = _shopCars
                    .Where(car => car.Year >= (desiredYear - 3) && car.Year <= (desiredYear + 3))
                    .ToList();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid input. Try again.");
                Console.ResetColor();
                Thread.Sleep(2000);
                return;
            }

            if (filteredCars != null && filteredCars.Count > 0)
            {
                ShowCars(filteredCars);

            }
            else if (filteredCars.Count <= 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No cars matching the criteria were found.");
                Console.ResetColor();
                Thread.Sleep(2500);
                return;
            }

        }

        private void
            BuyCarFromDealership(
                List<Car> cars) // Prompts every time you open a list of cars. Either put in the license plate to buy, or press X to go back.
        {

            Console.WriteLine("Type out any license plate to purchase.");
            Console.Write($"Or press ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" to leave the dealership. \n");
            string wantedCarPlate = Console.ReadLine();

            if (wantedCarPlate.ToUpper() ==
                "X") // Makes lowercase uppercase so it doesn't matter if the user inputs 'x' or 'X'
            {
                return;
            }

            Car wantedCar =
                _shopCars.FirstOrDefault(c =>
                    c.Licenseplate == wantedCarPlate.ToUpper()); // finds the car matching the license plate
            // To.Upper() makes it so the program isn't case sensitive when buying a car.
            if (wantedCar != null)
            {
                _shopCars.Remove(wantedCar); // removes the car from the shop
                Garage.myCars.Add(wantedCar); // adds the car to my static( :) ) garage
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"{wantedCar.Make} with license plate {wantedCar.Licenseplate} has been transported to your garage."); // Prints what car and licenseplate
                Console.ResetColor();
                Thread.Sleep(2500);
                return;
            }
            else
            {
                Console.WriteLine($"'{wantedCarPlate}' is not a valid license plate. Please try again.");
                Thread.Sleep(2000);
                ShowCars(cars);
            }

        }
    }


}
