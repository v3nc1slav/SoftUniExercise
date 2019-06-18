using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();
            int number = int.Parse(Console.ReadLine());
            Car car = new Car();
            for (int i = 0; i < number; i++)
            {
                car = new Car();
                var input = Console.ReadLine().Split().ToArray();
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);
                car.Model = model;
                car.Engine.enginePower = enginePower;
                car.Engine.engineSpeed = engineSpeed;
                car.Cargo.cargoWeight = cargoWeight;
                car.Cargo.cargoType = cargoType;
                car.Tire.tire1Pressure = tire1Pressure;
                car.Tire.tire1Age = tire1Age;
                car.Tire.tire2Pressure = tire2Pressure;
                car.Tire.tire2Age = tire2Age;
                car.Tire.tire3Pressure = tire3Pressure;
                car.Tire.tire3Age = tire3Age;
                car.Tire.tire4Pressure = tire4Pressure;
                car.Tire.tire4Age = tire4Age;
                cars.Add(car);
            }
            string comman = Console.ReadLine();
             car.inspection(comman, cars);
        }
    }
}
