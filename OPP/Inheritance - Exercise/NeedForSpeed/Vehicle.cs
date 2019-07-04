using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public double DefaultFuelConsumption { get; set; } = 1.25;

        public Vehicle(int horsePower , double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            var FuelNeeded = FuelConsumption * kilometers ;
            if (Fuel>= FuelNeeded)
            {
                Fuel -= FuelNeeded;
            }
            
        }

    }
}
