namespace CyclesInGraph
{
    using System;
    using System.Collections.Generic;

    public class StarUp
    {
        public static Dictionary<string, List<string>> graph;
        public static List<string> visited;

        public static void Main(string[] args)
        {
            ReadGraph();
            foreach (var node in graph)
            {
                if (CheckCycle(node.Key, node.Key, true))
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }
            }

            Console.WriteLine("Acyclic: Yes");
        }

        private static bool CheckCycle(string start, string current, bool isFirst)
        {
            if (start == current && !isFirst) return true;
            if (isFirst) isFirst = false;
            foreach (var child in graph[current])
            {
                if (CheckCycle(start, child, isFirst)) return true;
            }

            return false;
        }

        private static void ReadGraph()
        {
            string input;
            graph = new Dictionary<string, List<string>>();
            visited = new List<string>();
            while ((input = Console.ReadLine()) != "End")
            {
                string start = input.Split("-", StringSplitOptions.RemoveEmptyEntries)[0];
                string end = input.Split("-", StringSplitOptions.RemoveEmptyEntries)[1];
                if (!graph.ContainsKey(start))
                {
                    graph.Add(start, new List<string>() { end });
                }
                else
                {
                    graph[start].Add(end);
                }

                if (!graph.ContainsKey(end))
                {
                    graph.Add(end, new List<string>());
                }
            }
        }
    }
}
