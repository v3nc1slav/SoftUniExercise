using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = Char.Parse(Console.ReadLine());
            char b = Char.Parse(Console.ReadLine());
            char c = Char.Parse(Console.ReadLine());
            Console.WriteLine($"{a}{b}{c}");
        }
    }
}
