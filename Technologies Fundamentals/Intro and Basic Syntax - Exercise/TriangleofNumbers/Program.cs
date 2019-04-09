using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Triangle_of_Numbers
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= counter; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                counter++;
            }
        }
    }
}