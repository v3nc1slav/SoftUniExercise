using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Count_Symbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            PrintCountSymbols();
        }

        private static void PrintCountSymbols()
        {
            var dictionary = new SortedDictionary<char, int>();
            var input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (dictionary.ContainsKey(input[i]))
                {
                    dictionary[input[i]] += 1;
                }
                else
                {
                    dictionary.Add(input[i], 1);
                }
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
            return;
        }
    }
}
