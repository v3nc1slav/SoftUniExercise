namespace Word_Cruncher
{
    using System;
    using System.Collections.Generic;

    public class StarUp
    {
        private static string target;
        private static Dictionary<int, List<string>> wordsByLen;
        private static string current;
        private static Dictionary<string, int> occurances;
        private static List<string> selectedWords;
        private static HashSet<string> results;
        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            target = Console.ReadLine();
            occurances = new Dictionary<string, int>();
            selectedWords = new List<string>();
            wordsByLen = new Dictionary<int, List<string>>();
            results = new HashSet<string>();
            foreach (var word in words)
            {
                if (!target.Contains(word))
                {
                    continue;
                }

                var len = word.Length;
                if (!wordsByLen.ContainsKey(len))
                {
                    wordsByLen.Add(len, new List<string>());
                }

                if (occurances.ContainsKey(word))
                {
                    occurances[word] += 1;
                }
                else
                {
                    occurances.Add(word, 1);
                }
                wordsByLen[len].Add(word);
            }

            current = string.Empty;
            GenSolutions(target.Length);
            Console.WriteLine(string.Join(Environment.NewLine, results));
        }

        private static void GenSolutions(int targetLength)
        {
            if (targetLength == 0)
            {
                if (current == target)
                {
                    results.Add(string.Join(" ", selectedWords));
                }
                return;
            }

            foreach (var kvp in wordsByLen)
            {

                if (kvp.Key > targetLength)
                {
                    continue;
                }

                foreach (var word in kvp.Value)
                {
                    if (occurances[word] > 0)
                    {
                        current += word;

                        if (IsMatchingSoFar(target, current))
                        {
                            occurances[word] -= 1;
                            selectedWords.Add(word);
                            GenSolutions(targetLength - word.Length);
                            occurances[word]++;
                            selectedWords.RemoveAt(selectedWords.Count - 1);
                        }

                        current = current.Remove(current.Length - word.Length, word.Length);
                    }

                }
            }
        }

        private static bool IsMatchingSoFar(string target, string current) =>
            target.Substring(0, current.Length) == current;
    }
}