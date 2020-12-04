namespace Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            List<string> allNames =
                Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            var fixedNames = new Dictionary<int, string>();
            string input = Console.ReadLine();
            while (input != "generate")
            {
                string[] inputArgs =
                    input
                        .Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                fixedNames.Add(int.Parse(inputArgs[1]), inputArgs[0]);
                input = Console.ReadLine();
            }
            var solutions = new List<List<string>>();
            var currentSolution = new List<string>();
            Generate(currentSolution, solutions, allNames, fixedNames, 1);
            Console.WriteLine(string.Join(Environment.NewLine, solutions.Select(s => string.Join(" ", s))));
        }

        static void Generate(List<string> currentSolution, List<List<string>> solutions, List<string> allNames, Dictionary<int, string> fixedNames, int currentIndex)
        {
            if (currentSolution.Count == allNames.Count)
            {
                solutions.Add(currentSolution.ToList());
                return;
            }

            if (fixedNames.ContainsKey(currentIndex))
            {
                currentSolution.Add(fixedNames[currentIndex]);
                Generate(currentSolution, solutions, allNames, fixedNames, currentIndex + 1);
                currentSolution.Remove(fixedNames[currentIndex]);
                return;
            }

            foreach (var name in allNames.Where(x => !fixedNames.ContainsValue(x) && !currentSolution.Contains(x)))
            {
                currentSolution.Add(name);
                Generate(currentSolution, solutions, allNames, fixedNames, currentIndex + 1);
                currentSolution.Remove(name);
            }
        }
    }
}
