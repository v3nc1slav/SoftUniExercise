using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Word_Count
{
    class WordCount
    {
        static void Main(string[] args)
        {
            string input = "words.txt";
            string text = "text.txt";
            string outputName = "actualResults.txt";
            string sortOutputName = "expectedResult.txt";

            var inputWords = File.ReadAllLines(input);
            var findText = File.ReadAllLines(text);
            var dictionary = new Dictionary<string, int>();
            var list = findText.ToList();
            var finalList = new List<string>();
            for (int i = 0; i < findText.Length; i++)
            {
                finalList = list[i].ToLower().Split(new char[] {' ','-','.', ','}).ToList();
                foreach (var kvp in inputWords)
                {
                    var number = finalList.Count(x => x == kvp);
                    {
                        if (dictionary.ContainsKey(kvp))
                        {
                            dictionary[kvp] += number;
                        }
                        else
                        {
                            dictionary.Add(kvp, number);
                        }
                    }
                }
            }
            foreach (var item in dictionary)
            {
                File.AppendAllText(outputName,$"{item.Key} - {item.Value}" +
                    $"{Environment.NewLine}");
            }
            foreach (var item in dictionary.OrderByDescending(x=>x.Value))
            {
                File.AppendAllText(sortOutputName, $"{item.Key} - {item.Value}" +
                    $"{Environment.NewLine}");
            }
        }
    }
}
