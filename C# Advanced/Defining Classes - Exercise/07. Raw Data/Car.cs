using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; } = new Engine();
        public Cargo Cargo { get; set; } = new Cargo();
        public Tire Tire { get; set; } = new Tire();

        public void inspection(string command, List<Car> cars)
        {
            if (command=="fragile")
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Cargo.cargoType==command)
                    {
                        if (cars[i].Tire.tire1Pressure<1
                            || cars[i].Tire.tire2Pressure < 1
                            || cars[i].Tire.tire3Pressure < 1
                            || cars[i].Tire.tire4Pressure < 1
                            )
                        {
                            Console.WriteLine(cars[i].Model);
                        }
                    }
                }

            }
            else if(command== "flamable")
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Cargo.cargoType == command)
                    {
                        if (cars[i].Engine.enginePower>250)
                        {
                            Console.WriteLine(cars[i].Model);
                        }
                    }
                }
            }
        }

    }
}
