namespace AnimalFarm
{
    using System;

    public class Topping
    {
        public double meat { get; set; } = 1.2;
        public double veggies { get; set; } = 0.8;
        public double cheese { get; set; } = 1.1;
        public double sauce { get; set; } = 0.9;

        public Topping(string topping)
        {
            string toppings = topping.ToLower();
            if (toppings != "meat"
                && toppings != "veggies"
                && toppings != "cheese"
                && toppings != "sauce")
            {
                throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
            }
        }

        public double CalcoleitTopping(string topping)
        {
            topping = topping.ToLower();
            if (topping == "meat")
            {
                return meat;
            }
            else if (topping == "veggies")
            {
                return veggies;
            }
            else if (topping == "cheese")
            {
                return cheese;
            }
            else
            {
                return sauce;
            }
        }
    }
}
