using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char sinvol = char.Parse(Console.ReadLine());
            if (sinvol < 94)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
