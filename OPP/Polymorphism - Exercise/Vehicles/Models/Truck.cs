namespace Vehicles.Models
{
    using System;
    using Vehicles.Interface;

    public class Truck : IVehicle
    {
        public double Fuel {get; set;}

        public double CostNorm { get; set; }

        public Truck(double fuel, double costNorm)
        {
            Fuel = fuel;
            CostNorm = costNorm;
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
            Fuel += liters*0.95;
        }
    }
}
