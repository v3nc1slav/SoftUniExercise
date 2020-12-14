namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarUp
    {
        public static int nodes;
        public static List<List<int>> graph;
        public static bool[] visited;
        public static int[] sum;
        
        public static void Main(string[] args)
        {
            ReadGraph();
            for (int i = 0; i < nodes; i++)
            {
                if (!visited[i]) DFS(i);
            }

            Console.WriteLine(sum.Sum());
        }

        private static int DFS(int i)
        {
            if (graph[i].Count == 0) return 1;
            if (visited[i]) return sum[i];
            visited[i] = true;
            foreach (var child in graph[i])
            {
                if (!visited[child]) sum[i] += DFS(child);
                else sum[i] += sum[child];
                visited[child] = true;
            }

            return sum[i];
        }

        private static void ReadGraph()
        {
            nodes = int.Parse(Console.ReadLine());
            graph = new List<List<int>>();
            visited = new bool[nodes];
            sum = new int[nodes];
            for (int i = 0; i < nodes; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        if (graph.Count - 1 < i)
                        {
                            List<int> list = new List<int>();
                            list.Add(j);
                            graph.Add(list);
                        }
                        else
                        {
                            graph[i].Add(j);
                        }
                    }
                }

                if (graph.Count - 1 < i)
                {
                    sum[i] = 1;
                    graph.Add(new List<int>());
                }
            }
        }
    }
}