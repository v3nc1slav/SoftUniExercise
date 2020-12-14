namespace BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static Dictionary<string, List<string>> graph;
        public static List<KeyValuePair<string, string>> removed;
        public static List<KeyValuePair<string, string>> edges;
        public static HashSet<string> visited;
        public static bool isCyclic;

        public static void Main(string[] args)
        {
            ReadGraph();
            edges.OrderBy(a => a.Key).ThenBy(a => a.Value);
            foreach (var edge in edges.OrderBy(a => a.Value).ThenBy(a => a.Key))
            {
                if (!graph[edge.Key].Contains(edge.Value) || !graph[edge.Value].Contains(edge.Key))
                {
                    continue;
                }

                graph[edge.Key].Remove(edge.Value);
                graph[edge.Value].Remove(edge.Key);

                visited = new HashSet<string>();
                isCyclic = false;
                TraverseGraph(edge.Key, edge.Value);

                if (isCyclic)
                {
                    removed.Add(edge);
                }
                else
                {
                    graph[edge.Key].Add(edge.Value);
                    graph[edge.Value].Add(edge.Key);
                }
            }
            Console.WriteLine($"Edges to remove: {removed.Count}");
            foreach (var curr in removed.ToList())
            {
                char temp;
                if (curr.Key[0] > curr.Value[0])
                {
                    temp = curr.Key[0];
                    removed.Remove(curr);
                    removed.Add(new KeyValuePair<string, string>(curr.Value, temp.ToString()));
                }
            }
            foreach (var curr in removed.OrderBy(a => a.Key).ThenBy(a => a.Value))
            {
                if (curr.Key[0] > curr.Value[0]) Console.WriteLine($"{curr.Value} - {curr.Key}");
                else Console.WriteLine($"{curr.Key} - {curr.Value}");
            }
        }

        static bool TraverseGraph(string startNode, string endNode)
        {
            if (!visited.Contains(startNode))
            {
                if (startNode == endNode)
                {
                    isCyclic = true;
                    return true;
                }

                visited.Add(startNode);

                for (int i = 0; i < graph[startNode].Count; i++)
                {
                    if (TraverseGraph(graph[startNode][i], endNode)) return true;
                }
            }

            return false;
        }

        private static void ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            string input;
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            edges = new List<KeyValuePair<string, string>>();
            removed = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < n; ++i)
            {
                input = Console.ReadLine();
                string start = input.Split(" ->", StringSplitOptions.RemoveEmptyEntries)[0];
                string end = input.Split(" ->", StringSplitOptions.RemoveEmptyEntries)[1];
                if (!graph.ContainsKey(start))
                {
                    graph.Add(start, end.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
                }
                else
                {
                    graph[start] = end.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                foreach (var ends in end.Split(" ", StringSplitOptions.RemoveEmptyEntries).OrderBy(a => a).ToList())
                {
                    if (!graph.ContainsKey(ends))
                    {
                        graph.Add(ends, new List<string>());
                    }
                    if (!edges.Contains(new KeyValuePair<string, string>(ends, start))) edges.Add(new KeyValuePair<string, string>(start, ends));

                }
            }
        }
    }
}