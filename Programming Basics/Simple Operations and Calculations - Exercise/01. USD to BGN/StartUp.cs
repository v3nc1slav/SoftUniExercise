namespace _01._USD_to_BGN
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            Double a = Double.Parse(Console.ReadLine());
            double b = (a * 1.79549);
            Console.WriteLine(Math.Round(b, 2) + " BGN");
        }
    }
}
