using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm
{
    public class Person
    {
        private string name;
        private decimal money;

        public List<string> BagOfProducts; 

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

        public decimal Money
        {
            get => money;
            private set
            {
                if (value <0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        public Person()
        {

        }

        public void Purchase(string name, string purchase, List<Person> person, List<Product> product)
        {
            decimal money = 0;
            decimal cost = 0;
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i].Name==purchase)
                {
                    cost = product[i].Cost;
                }
            }
            for (int i = 0; i < person.Count; i++)
            {
                if (person[i].name==name)
                {
                    money = person[i].money;
                    if (money >= cost)
                    {
                        person[i].BagOfProducts.Add( purchase);
                        person[i].money -= cost;
                        Console.WriteLine($"{name} bought {purchase}");
                    }
                    else
                    {
                        Console.WriteLine($"{name} can't afford {purchase}");
                    }
                }
            }
        }
    }
}
