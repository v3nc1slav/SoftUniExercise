namespace _05._Dance_Hall
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());
            double room = (l * 100) * (w * 100);
            Double wardrobe = (a * 100) * (a * 100);
            Double bench = room / 10;
            Double freeSpace = room - wardrobe - bench;
            double people = freeSpace / (40 + 7000);
            Console.WriteLine(Math.Floor(people));
        }
    }
}
