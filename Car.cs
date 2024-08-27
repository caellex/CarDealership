namespace CarDealership
{
    internal class Car
    {
        public string Make { get; private set; }
        public int Year { get; private set; }
        public string Licenseplate { get; private set; }
        public int Km { get; private set; }


        public Car(string make, int year, string licenseplate, int km) // Don't really need a comment here but hey! fun fun
        {
            Make = make;
            Year = year;
            Licenseplate = licenseplate;
            Km = km;
        }
    }

}