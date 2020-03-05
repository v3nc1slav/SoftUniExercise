namespace _06._Charity_Campaign
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double people = double.Parse(Console.ReadLine());
            double cake = double.Parse(Console.ReadLine());
            double corrugations = double.Parse(Console.ReadLine());
            double pancakes = double.Parse(Console.ReadLine());
            double sum = (((cake * 45) + (corrugations * 5.8) + (pancakes * 3.20))
                * people) * days;
            double costs = sum * 1 / 8;
            double profit = sum - costs;
            Console.WriteLine("{0:F2}", profit);
        }
    }
}
