using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sets_of_Elements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            PrintSetsOfElements();
        }

        private static void PrintSetsOfElements()
        {
            var numbers = Console.ReadLine().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var first = numbers[0];
            var second = numbers[1];
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var finalSet = new HashSet<int>();
            for (int i = 0; i < first; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < second; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }
            foreach (var item in firstSet)
            {
                foreach (var kpv in secondSet)
                {
                    if (item==kpv)
                    {
                        finalSet.Add(item);
                    }
                }
            }
            foreach (var item in finalSet)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
