using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; } = new Engine();
        public string Weight { get; set; } 
        public string Color { get; set; } 

        public void PrintCar(List<Car>cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{cars[i].Model}:");
                Console.WriteLine($"    {cars[i].Engine.ModelEngine}:");
                Console.WriteLine($"        Power: {cars[i].Engine.Power}");
                Console.WriteLine($"        Displacement: {cars[i].Engine.Displacement}");
                Console.WriteLine($"        Efficiency: {cars[i].Engine.Efficiency}");
                Console.WriteLine($"    Weight: {cars[i].Weight}");
                Console.WriteLine($"    Color: {cars[i].Color}");
            }
        }
    }
}
