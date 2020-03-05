namespace _03._2D_Rectangle_Area
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double d = Math.Abs(x1 - x2);
            double v = Math.Abs(y1 - y2);
            double area = d * v;
            double perimeter = 2 * (d + v);
            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}
