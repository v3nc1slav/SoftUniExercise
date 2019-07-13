namespace AnimalFarm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AnimalFarm.Models;
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nameInput = Console.ReadLine()
                .Split(new char[] { ';', '=' }
                ,StringSplitOptions
                .RemoveEmptyEntries)
                .ToList();
            List<string> productInput = Console.ReadLine()
                .Split(new char[]{';', '='}
                ,StringSplitOptions
                .RemoveEmptyEntries)
                .ToList();

            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();
                Person person = new Person();
                Product product = new Product();
                Filling(nameInput, productInput, person, product, people,products);
                Aaction( person, people, products);
                Print(people);
               
            }
            catch (ArgumentException ex)
            {
            
                Console.WriteLine(ex.Message);
            }
        }

        private static void Aaction(Person person, List<Person> people, List<Product> products)
        {

            var command = Console.ReadLine().Split(" ").ToList();
            while (command[0] != "END")
            {
                string name = command[0];
                string purchase = command[1];
                person.Purchase(name, purchase, people, products);
                command = Console.ReadLine().Split(" ").ToList();
            }
        }

        private static void Filling(List<string> nameInput, List<string> productInput,
            Person person, Product product, List<Person> people, List<Product> products)
        {
            for (int i = 0; i < nameInput.Count; i += 2)
            {
                person = new Person(nameInput[i], (decimal.Parse(nameInput[i + 1])));
                people.Add(person);
            }
            for (int i = 0; i < productInput.Count; i += 2)
            {
                product = new Product(productInput[i], (decimal.Parse(productInput[i + 1])));
                products.Add(product);
            }
        }

        private static void Print(List<Person> people)
        {
            foreach (var item in people)
            {
                Console.Write($"{item.Name} - ");
                for (int i = 0; i < item.BagOfProducts.Count; i++)
                {
                    if (i == item.BagOfProducts.Count - 1)
                    {
                        Console.Write($"{item.BagOfProducts[i]}");
                    }
                    else
                    {
                        Console.Write($"{item.BagOfProducts[i]}, ");
                    }
                }
                if (item.BagOfProducts.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                Console.WriteLine();
            }
        }
    }
}
