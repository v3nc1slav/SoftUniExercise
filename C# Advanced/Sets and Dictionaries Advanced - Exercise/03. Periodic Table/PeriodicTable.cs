using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Periodic_Table
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            PrintPeriodicTable();
        }

        private static void PrintPeriodicTable()
        {
            var number = int.Parse(Console.ReadLine());
            var PeriodicTableSet = new SortedSet<string>();
            for (int i = 0; i < number; i++)
            {
                var elelements = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < elelements.Length; j++)
                {
                    PeriodicTableSet.Add(elelements[j]);
                }
            }
            foreach (var item in PeriodicTableSet)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
