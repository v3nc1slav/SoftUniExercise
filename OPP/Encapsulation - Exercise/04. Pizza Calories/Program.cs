namespace AnimalFarm
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int counter = 1;
            double calories = 0;

            var namePizza = Console.ReadLine().Split(" ").ToArray();
            var inputDough = Console.ReadLine().Split(" ").ToArray();
            var inputTopping = Console.ReadLine().Split(" ").ToArray();
            Pizza pizza = new Pizza();

            string name = namePizza[1];
            string dough = inputDough[1];
            string bakingTechnique = inputDough[2];
            double gramsDough = double.Parse(inputDough[3]);

            try
            {
                pizza = new Pizza(name, dough, bakingTechnique, gramsDough);
                calories += pizza.result;
                while (inputTopping[0] != "END" && counter < 10)
                {

                    string topping = inputTopping[1];
                    double gramsTopping = double.Parse(inputTopping[2]);
                    pizza = new Pizza(topping, gramsTopping);
                    calories += pizza.result;
                    inputTopping = Console.ReadLine().Split(" ").ToArray();
                    counter++;
                }
                if (counter == 10)
                {
                    Console.WriteLine("Number of toppings should be in range [0..10].");
                    return;
                }
                Console.WriteLine($"{name} - {calories:f2} Calories.");

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                
            }
        }
           
    }
}
