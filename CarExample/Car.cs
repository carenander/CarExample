using System;

namespace CarExample
{
    class Car
    {
        public string RegNo { get; set; }

        private readonly double fuelConsumtion = 0.1;

        private double fuelLevel;
        
        public Car(string regNo)
        {
            RegNo = regNo;
        }

        public double FuelLevel
        {
            get { return fuelLevel; }
            set {
                double newLevel = Math.Max(0, value);
                fuelLevel = Math.Min(newLevel, FuelCapacity);
            }
        }

        public double FuelCapacity {
            get;
            private set;
        } = 105;

        public double Mileage { get; set; }
        public static double GlobalMileage { get; private set; }


        public void Drive(double distanceKm)
        {
            Console.WriteLine(RegNo + " vill köra " + distanceKm + " km." );
            if (distanceKm < 0)
            {
                distanceKm = 0;
                Console.WriteLine("Negativt avstånd tolkas som noll");
            }

            double maxDistance = fuelLevel / fuelConsumtion;
            if (distanceKm > maxDistance)
            {
                distanceKm = maxDistance;
                Console.WriteLine("Bränslet räcker inte så långt.");
            }

            fuelLevel -= distanceKm * fuelConsumtion;
            Mileage += distanceKm;
            GlobalMileage += distanceKm;

            Console.WriteLine(RegNo + " körde " + distanceKm + " km.");
            Console.WriteLine();            
        }

        public void StatusReport() {            
            Console.WriteLine("RegNo:   " + RegNo);
            Console.WriteLine("Fuel:    " + FuelLevel + "/" + FuelCapacity);
            Console.WriteLine("Mileage: " + Mileage);
            Console.WriteLine();
        }
    }
}