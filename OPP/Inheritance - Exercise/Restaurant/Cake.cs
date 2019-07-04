﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake: Dessert
    {
        public const double Grams = 250;
        public const double Calories = 1000;
        public const decimal Price = 5;

        public Cake(string name )
            : base(name, Price, Grams, Calories)
        {

        }
    }
}
