using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Ages
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            if (n <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (n <= 13)
            {
                Console.WriteLine("child");
            }
            else if (n <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (n <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (n > 65)
            {
                Console.WriteLine("elder");
            }
        }
    }
}