namespace WildFarm.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WildFarm.Models;

    public class Engine
    {
        public Engine()
        {
            List<Animal> animals = new List<Animal>();

            string[] input = Console.ReadLine().Split().ToArray();
            while (input[0] != "End")
            {
                string type = input[0];
                string name = input[1];
                double weight = double.Parse(input[2]);

                if (type == "Cat")
                {
                    string livingRegion = input[3];
                    string breed = input[4];
                    Cat cat = new Cat(name, weight, livingRegion, breed);
                    string[] foods = Console.ReadLine().Split().ToArray();
                    string typeFoods = foods[0];
                    int quantity = int.Parse(foods[1]);
                    Console.WriteLine(cat.Speaks());
                    if (cat.foods.Contains(typeFoods))
                    {
                        cat.Eaten(quantity);
                    }
                    else
                    {
                        cat.FoodEaten = 0;
                        Console.WriteLine($"{type} does not eat { typeFoods}!");
                    }
                    animals.Add(cat);
                }
                else if (type == "Tiger")
                {
                    string livingRegion = input[3];
                    string breed = input[4];
                    Tiger tiger = new Tiger(name, weight, livingRegion, breed);
                    string[] foods = Console.ReadLine().Split().ToArray();
                    string typeFoods = foods[0];
                    int quantity = int.Parse(foods[1]);
                    Console.WriteLine(tiger.Speaks());
                    if (tiger.foods.Contains(typeFoods))
                    {
                        tiger.Eaten(quantity);
                    }
                    else
                    {
                        tiger.FoodEaten = 0;
                        Console.WriteLine($"{type} does not eat { typeFoods}!");
                    }
                    animals.Add(tiger);
                }
                else if (type == "Dog")
                {
                    string livingRegion = input[3];
                    Dog dog = new Dog(name, weight, livingRegion);
                    string[] foods = Console.ReadLine().Split().ToArray();
                    string typeFoods = foods[0];
                    int quantity = int.Parse(foods[1]);
                    Console.WriteLine(dog.Speaks());
                    if (dog.foods.Contains(typeFoods))
                    {
                        dog.Eaten(quantity);
                    }
                    else
                    {
                        dog.FoodEaten = 0;
                        Console.WriteLine($"{type} does not eat { typeFoods}!");
                    }
                    animals.Add(dog);
                }
                else if (type == "Mouse")
                {
                    string livingRegion = input[3];
                    Mouse mouse = new Mouse(name, weight, livingRegion);
                    string[] foods = Console.ReadLine().Split().ToArray();
                    string typeFoods = foods[0];
                    int quantity = int.Parse(foods[1]);
                    Console.WriteLine(mouse.Speaks());
                    if (mouse.foods.Contains(typeFoods))
                    {
                        mouse.Eaten(quantity);
                    }
                    else
                    {
                        mouse.FoodEaten = 0;
                        Console.WriteLine($"{type} does not eat { typeFoods}!");
                    }

                    animals.Add(mouse);
                }
                else if (type == "Owl")
                {
                    double wingSize = double.Parse(input[3]);
                    Owl owl = new Owl(name, weight, wingSize);
                    string[] foods = Console.ReadLine().Split().ToArray();
                    string typeFoods = foods[0];
                    int quantity = int.Parse(foods[1]);
                    Console.WriteLine(owl.Speaks());
                    if (owl.foods.Contains(typeFoods))
                    {
                        owl.Eaten(quantity);
                    }
                    else
                    {
                        owl.FoodEaten = 0;
                        Console.WriteLine($"{type} does not eat { typeFoods}!");
                    }

                    animals.Add(owl);
                }
                else if (type == "Hen")
                {
                    double wingSize = double.Parse(input[3]);
                    Hen hen = new Hen (name, weight, wingSize);
                    string[] foods = Console.ReadLine().Split().ToArray();
                    string typeFoods = foods[0];
                    int quantity = int.Parse(foods[1]);
                    Console.WriteLine(hen.Speaks());
                    if (hen.foods.Contains(typeFoods))
                    {
                        hen.Eaten(quantity);
                    }
                    else
                    {
                        hen.FoodEaten = 0;
                        Console.WriteLine($"{type} does not eat { typeFoods}!");
                    }

                    animals.Add(hen);
                }

                input = Console.ReadLine().Split().ToArray();
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }

    }
}
