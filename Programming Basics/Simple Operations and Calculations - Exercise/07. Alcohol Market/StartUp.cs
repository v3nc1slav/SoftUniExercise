namespace _07._Alcohol_Market
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            double beer = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double rakiq = double.Parse(Console.ReadLine());
            double whiskey = double.Parse(Console.ReadLine());
            double crakiq = price - (0.5 * price);
            Double cbeer = crakiq - (0.8 * crakiq);
            Double cwine = crakiq - (0.4 * crakiq);
            double sum = (beer * cbeer) + (wine * cwine) + (rakiq * crakiq) + (whiskey * price);
            Console.WriteLine("{0:F2}", sum);

        }
    }
}
