using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_and_Minimum_Element
{
    class MaximumAndMinimumElement
    {
        static void Main(string[] args)
        {
            PrintMaximumAndMinimumElement();
        }

        private static void PrintMaximumAndMinimumElement()
        {
            var stak = new Stack<int>();
            var N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var command = Console.ReadLine().Split().Select(int.Parse).ToList();
                if (command[0] == 1)
                {
                    stak.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    if (stak.Count > 0)
                    {
                        stak.Pop();

                    }
                }
                else if (command[0] == 3)
                {
                    if (stak.Count > 0)
                    {
                        Console.WriteLine(stak.Max());
                    }
                }
                else if (command[0] == 4)
                {
                    if (stak.Count > 0)
                    {
                        Console.WriteLine(stak.Min());
                    }
                }
            }

            Console.Write(string.Join(", ", stak));

        }
    }
}
