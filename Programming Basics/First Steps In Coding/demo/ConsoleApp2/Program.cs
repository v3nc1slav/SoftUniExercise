using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrintDeciphering();
        }

        private static void PrintDeciphering()
        {
            var command1 = Console.ReadLine();
            for (int i = 0; i < command1.Length; i++)
            {
                if (command1[i]=='a' || command1[i] == 'b'|| command1[i] == 'c')
                {
                    Console.WriteLine("This is not the book you are looking for.") ;
                    return;
                }
            }
            string input = string.Empty;
            for (int i = 0; i < command1.Length; i++)
            {
                input += (char)(command1[i] - 3);
            }
            var command2 = Console.ReadLine().Split(' ');
            string final = input.Replace(command2[0],command2[1]);
            Console.WriteLine(final);
        }
    }
}
