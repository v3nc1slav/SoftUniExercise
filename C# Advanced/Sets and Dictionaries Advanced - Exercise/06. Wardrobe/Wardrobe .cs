using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Wardrobe
{
    class Wardrobe 
    {
        static void Main(string[] args)
        {
            PrintWardrobe();
        }

        private static void PrintWardrobe()
        {
            var number = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, Dictionary<string,int>>();
            for (int i = 0; i < number; i++)
            {
                var commanda = Console.ReadLine().Split(new string[] { " -> ","," },StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j < commanda.Length; j++)
                {
                    if (dictionary.ContainsKey(commanda[0]))
                    {
                        if (dictionary[commanda[0]].ContainsKey(commanda[j]))
                        {
                            dictionary[commanda[0]][commanda[j]] += 1; 
                        }
                        else
                        {
                            dictionary[commanda[0]].Add(commanda[j], 1);
                        }
                    }
                    else
                    {
                        dictionary.Add(commanda[0], new Dictionary<string, int>{ { commanda[j], 1 } });
                    }
                }
            }
            var found = Console.ReadLine().Split();
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var kvp in item.Value)
                {
                    if (item.Key==found[0]&&kvp.Key==found[1])
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
