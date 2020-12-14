namespace DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarUp
    {
        public static Dictionary<int, List<int>> graph;
        private static int n, p;
        private static Queue<int> queue;
        private static List<int> visited;
        
        public static void Main(string[] args)
        {
            ReadGraph();
            ReadPairs();
        }

        private static void ReadPairs()
        {
            for (int i = 0; i < p; i++)
            {
                string input = Console.ReadLine();
                int start = input.Split("-", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray()[0];
                int end = input.Split("-", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray()[1];
                printShortestDistance(graph, start, end);
            }
        }

        private static void printShortestDistance(Dictionary<int, List<int>> adj,
                                          int s, int dest)
        {

            Dictionary<int, int> parents = new Dictionary<int, int>();
            Dictionary<int, int> distances = new Dictionary<int, int>();

            if (BFS(adj, s, dest,
                    parents, distances) == false)
            {
                Console.WriteLine($"{{{s}, {dest}}} -> -1");
                return;
            }

            List<int> path = new List<int>();
            int crawl = dest;
            path.Add(crawl);

            while (parents[crawl] != -1)
            {
                path.Add(parents[crawl]);
                crawl = parents[crawl];
            }


            Console.WriteLine($"{{{s}, {dest}}} -> " + distances[dest]);
        }

        private static bool BFS(Dictionary<int, List<int>> adj,
                                int src, int dest, Dictionary<int, int> pred,
                                Dictionary<int, int> dist)
        {
            Queue<int> queue = new Queue<int>();

            List<int> visited = new List<int>();

            foreach (var node in adj)
            {
                dist.Add(node.Key, int.MaxValue);
                pred.Add(node.Key, -1);
            }


            visited.Add(src);
            dist[src] = 0;
            queue.Enqueue(src);


            while (queue.Count != 0)
            {
                int u = queue.Dequeue();

                foreach (var child in adj[u])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        dist[child] = dist[u] + 1;
                        pred[child] = u;
                        queue.Enqueue(child);

                        if (child == dest)
                            return true;
                    }

                }
            }
            return false;
        }

        private static void ReadGraph()
        {
            n = int.Parse(Console.ReadLine());
            p = int.Parse(Console.ReadLine());
            visited = new List<int>();
            graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!graph.ContainsKey(int.Parse(elements[0])))
                {
                    if (elements.Length > 1) graph.Add(int.Parse(elements[0]), elements[1].Split().Select(int.Parse).ToList());
                    else graph.Add(int.Parse(elements[0]), new List<int>());
                }
                else
                {
                    if (elements.Length > 1) graph[int.Parse(elements[0])] = elements[1].Split().Select(int.Parse).ToList();
                }
            }
        }
    }
}

