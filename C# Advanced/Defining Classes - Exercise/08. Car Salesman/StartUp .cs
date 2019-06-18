using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();
            var engines = new List<Engine>();
            var cars = new List<Car>();
            int numberN = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberN; i++)
            {
                Engine engine = new Engine();
                var inputEngine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (inputEngine.Count()==2)
                {
                    two( inputEngine, engine,  engines);
                }
                else if (inputEngine.Count() == 3)
                {
                    three(inputEngine, engine, engines);
                }
                else if (inputEngine.Count() == 4)
                {
                    four(inputEngine, engine, engines);
                }
            }
            int numberM = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberM; i++)
            {
                car = new Car();
                var inputCar = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
                string model = inputCar[0];
                car.Model = model;
                string engine = inputCar[1];
                for (int j = 0; j < engines.Count; j++)
                {
                    if (engines[j].ModelEngine==(engine))
                    {
                        car.Engine = engines[j];
                    }
                }
                if (inputCar.Count()==3)
                {
                    int weight = 0;
                    bool bol = int.TryParse(inputCar[2], out weight);
                    if (bol)
                    {
                        car.Weight = weight.ToString();
                        car.Color = "n/a";
                    }
                    else
                    {
                        car.Weight = "n/a";
                        car.Color = inputCar[2];
                    }
                }
                else if(inputCar.Count() == 4)
                {
                    car.Weight = inputCar[2];
                    car.Color = inputCar[3];
                }
                else
                {
                    car.Weight = "n/a";
                    car.Color = "n/a";
                }
                cars.Add(car);
            }
            car.PrintCar(cars);
        }

        private static void four(List<string> inputEngine, Engine engine, List<Engine> engines)
        {
            string modelEngine = inputEngine[0];
            string power = inputEngine[1];
            string displacement = inputEngine[2];
            string efficiency = inputEngine[3];
            engine.ModelEngine = modelEngine;
            engine.Power = power;
            engine.Displacement = displacement;
            engine.Efficiency = efficiency;
            engines.Add(engine);
        }

        private static void three(List<string> inputEngine, Engine engine, List<Engine> engines)
        {
            string modelEngine = inputEngine[0];
            string power = inputEngine[1];
            int displacement = 0;
            bool bol = int.TryParse(inputEngine[2], out displacement);
            engine.ModelEngine = modelEngine;
            engine.Power = power;
            if (bol)
            {
                engine.Displacement = displacement.ToString();
                engine.Efficiency = "n/a";
            }
            else
            {
                engine.Displacement = "n/a";
                engine.Efficiency = inputEngine[2];
            }
            engines.Add(engine);
        }

        private static void two(List<string> inputEngine, Engine engine, List<Engine> engines)
        {
            string modelEngine = inputEngine[0];
            string power = inputEngine[1];
            engine.ModelEngine = modelEngine;
            engine.Power = power;
            engine.Displacement = "n/a";
            engine.Efficiency = "n/a";
            engines.Add(engine);
        }
    }
}
