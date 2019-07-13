using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm
{
    public class Product
    {
        private string name;
        private decimal cost;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal  Cost {
            get => cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }


        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public Product()
        {

        }
    }
}
