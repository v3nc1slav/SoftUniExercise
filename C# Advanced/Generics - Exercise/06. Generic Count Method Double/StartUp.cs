namespace _06._Generic_Count_Method_Double
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<double> items = new List<double>();
            double n = double.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                items.Add(input);
            }
            double compareTo = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>(items, compareTo);
            Console.WriteLine(box.GetCount());
        }
    }
}
