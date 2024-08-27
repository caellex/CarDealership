using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    internal class Garage
    {
        public static List<Car> myCars = new List<Car>(); // static garage as we only need one.
        public void Visit()
        {
            Console.Clear();
            if (myCars.Count > 0) // if garage isn't empty, ->
            {
                Console.WriteLine($"({myCars.Count}) Garage: \n");
                foreach (Car car in myCars) // print each car
                {
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"License Plate: {car.Licenseplate}");
                    Console.WriteLine($"KM: {car.Km}\n");
                }

                Console.WriteLine("Press any key to go back..");
                Console.ReadKey(true);
                return;
            }
            else // if garage is empty, tell user to buy one.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No cars! Go buy one.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(2000);
                return;
            }

        }
    }
}
