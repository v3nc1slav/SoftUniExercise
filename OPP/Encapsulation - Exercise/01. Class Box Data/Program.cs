namespace AnimalFarm
{
    using System;
    using AnimalFarm.Models;
    class Program
    {
        static void Main(string[] args)
        {

            double length = Double.Parse(Console.ReadLine());
            double width = Double.Parse(Console.ReadLine());
            double height = Double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - { box.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            



          // string name = Console.ReadLine();
          // int age = int.Parse(Console.ReadLine());
          //
          // Chicken chicken = new Chicken(name, age);
          // Console.WriteLine(
          //     "Chicken {0} (age {1}) can produce {2} eggs per day.",
          //     chicken.Name,
          //     chicken.Age,
          //     chicken.ProductPerDay);
        }
    }
}
