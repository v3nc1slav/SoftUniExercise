namespace _04._Tailoring_Workshop
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            Double masses = Double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double tablecloths = masses * (length + 2 * 0.30) * (width + 2 * 0.3);
            double coach = masses * (length / 2) * (length / 2);
            double priceInUSD = tablecloths * 7 + coach * 9;
            Double priceInBGN = priceInUSD * 1.85;
            Console.WriteLine("{0:F2} USD", priceInUSD);
            Console.WriteLine("{0:F2} BGN", priceInBGN);
        }
    }
}
