using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish:MainDish
    {
        public const double Grams = 22.00; 

        public Fish(string name, decimal price)
            : base(name, price, Grams)
        {

        }
    }
}
