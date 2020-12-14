namespace BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarUp
    {
        public static Dictionary<int, List<int>> graph;
        public static List<KeyValuePair<int, int>> edges;
        public static List<int> visitedNodes;
        public static List<KeyValuePair<int, int>> visitedEdges;
        public static int buildings, streets;
        
        public static void Main(string[] args)
        {
            ReadGraph();
            Console.WriteLine("Important streets:");
            foreach (var edge in edges.ToList())
            {
                visitedNodes = new List<int>();
                visitedEdges = new List<KeyValuePair<int, int>>();
                visitedNodes.Add(0);
                visitedEdges.Add(edge);
                if (!TraverseGraph(0))
                {
                    Console.WriteLine(edge.Key + " " + edge.Value);
                }
            }
        }

        static bool TraverseGraph(int currentNode)
        {
            if (visitedNodes.Count == buildings)
            {
                return true;
            }


            else
            {
                foreach (var child in graph[currentNode])
                {


                    if (!visitedEdges.Contains(new KeyValuePair<int, int>(Math.Min(child, currentNode),
                        Math.Max(child, currentNode))))
                    {
                        visitedEdges.Add(new KeyValuePair<int, int>(Math.Min(child, currentNode),
                            Math.Max(child, currentNode)));
                        if (!visitedNodes.Contains(child)) visitedNodes.Add(child);
                    }
                    else
                    {
                        continue;
                    }
                    if (TraverseGraph(child)) return true;

                }
            }

            return false;
        }

        private static void ReadGraph()
        {
            buildings = int.Parse(Console.ReadLine());
            streets = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, List<int>>();
            edges = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < streets; i++)
            {
                var inputParameters = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                int begin = inputParameters[0];
                int end = inputParameters[1];
                if (graph.ContainsKey(begin))
                {
                    graph[begin].Add(end);
                }
                else
                {
                    graph.Add(begin, new List<int> { end });
                }
                if (graph.ContainsKey(end))
                {
                    graph[end].Add(begin);
                }
                else
                {
                    graph.Add(end, new List<int> { begin });
                }
                if (begin > end) edges.Add(new KeyValuePair<int, int>(end, begin));
                else edges.Add(new KeyValuePair<int, int>(begin, end));
            }

            graph = new Dictionary<int, List<int>>(graph.OrderBy(a => a.Key));
        }
    }
}
