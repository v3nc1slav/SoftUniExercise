using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double paunds = double.Parse(Console.ReadLine());
            double dollars = paunds * 1.31;
            Console.WriteLine($"{dollars:F3}");
        }
    }
}
