using System;

namespace _08._Fish_Tank
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine()) * 0.01;
            double volume = length * width * height * 0.001 * (1 - percentage);
            Console.WriteLine("{0:F3}", volume);
        }
    }
}
