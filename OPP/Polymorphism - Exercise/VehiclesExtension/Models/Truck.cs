namespace VehiclesExtension.Models
{
    using System;
    using VehiclesExtension.Interface;

    public class Truck : IVehicle
    {
        public double Fuel {get; set;}

        public double CostNorm { get; set; }

        public double TankCapacity { get; set; }

        public Truck(double fuel, double costNorm, double capacity)
        {
            Fuel = fuel;
            CostNorm = costNorm;
            if (fuel <= capacity)
            {
                TankCapacity = capacity;
            }
            else
            {
                Fuel = 0;
                TankCapacity = capacity;
            }
        }

        public Truck()
        {

        }

        public void Drive(double distance)
        {
            double costNorm = CostNorm + 1.6;

            if (distance * costNorm <= Fuel)
            {
                Fuel -= distance * costNorm;
                Console.WriteLine($"Truck travelled {distance} km");
                return;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void Refuel(double liters)
        {
            if (liters<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            else if (Fuel + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                Fuel += liters * 0.95;
            }
        }
    }
}
