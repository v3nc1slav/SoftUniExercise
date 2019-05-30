using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Even_Times
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            PrintEvenTimes();
        }

        private static void PrintEvenTimes()
        {
            var number = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < number; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (dictionary.ContainsKey(input))
                {
                    dictionary[input] = dictionary[input]+1;
                }
                else
                {
                    dictionary.Add(input, 1);
                }
            }
            foreach (var item in dictionary)
            {
                if (item.Value%2==0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
