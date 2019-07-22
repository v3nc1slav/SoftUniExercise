namespace Vehicles.Models
{
    using System;
    using Vehicles.Interface;

    public class Car : IVehicle
    {
        public double Fuel { get;  set; }

        public double CostNorm { get; set; }

        public Car(double fuel, double costNorm)
        {
            Fuel = fuel;
            CostNorm = costNorm;
        }

        public Car()
        {

        }

        public void Drive(double distance)
        {
            double costNorm = CostNorm + 0.9;

            if (distance* costNorm <= Fuel)
            {
                Fuel -= distance * costNorm;
                Console.WriteLine($"Car travelled {distance} km");
                return;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }

        }

        public void Refuel(double liters)
        {
            Fuel += liters;
        }
    }
}
