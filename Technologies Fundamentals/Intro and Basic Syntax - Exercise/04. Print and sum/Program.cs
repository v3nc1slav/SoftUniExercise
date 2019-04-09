using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Print_and_sum
{
    public class Program
    {
        public static void Main()
        {
            int Frist = int.Parse(Console.ReadLine());
            int Second = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = Frist; i <= Second; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}