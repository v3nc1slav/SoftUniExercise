namespace Vehicles.Engin
{
    using System;
    using System.Linq;
    using Vehicles.Models;

    public class Engin
    {
        private Car car = new Car();
        private Truck truck = new Truck();


        public Engin()
        {
            for (int i = 0; i < 2; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string type = input[0].ToLower();
                double fuel = double.Parse(input[1]);
                double costNorm = double.Parse(input[2]);
                if (type == "car")
                {
                    car = new Car(fuel, costNorm);
                }
                else if (type == "truck")
                {
                    truck = new Truck(fuel, costNorm);
                }
            }
        }

        public void Command(int number)
        {
            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string action = input[0];
                string type = input[1];
                double distance = double.Parse(input[2]);
                action = action.ToLower();
                type = type.ToLower();
                if (action == "drive")
                {
                    if (type == "car")
                    {
                        car.Drive(distance);
                    }
                    else if (type == "truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if (action == "refuel")
                {
                    double liters = distance;
                    if (type == "car")
                    {
                        car.Refuel(liters);
                    }
                    else if (type == "truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"Car: {car.Fuel:F2}");
            Console.WriteLine($"Truck: {truck.Fuel:F2}");
        }
    }
}
