namespace AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        private static int n, m;
        private static char[,] matrix;
        private static Dictionary<char, int> areas;
        private static bool[,] visited;

        public static void Main(string[] args)
        {
            ReadMatrix();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!visited[i, j])
                    {
                        if (!areas.ContainsKey(matrix[i, j]))
                        {
                            areas.Add(matrix[i, j], 1);
                        }
                        else
                        {
                            areas[matrix[i, j]]++;
                        }
                        Solve(i, j, matrix[i, j]);
                    }


                }
            }

            Console.WriteLine($"Areas: {areas.Sum(a => a.Value)}");
            foreach (var symbol in areas.OrderBy(a => a.Key))
            {
                Console.WriteLine($"Letter '{symbol.Key}' -> {symbol.Value}");
            }
        }

        private static void Solve(int x, int y, char currentSymbol)
        {
            if (x >= n || x < 0 || y < 0 || y >= m)
            {
                return;
            }
            if (visited[x, y]) return;
            if (matrix[x, y] != currentSymbol) return;
            visited[x, y] = true;

            Solve(x + 1, y, currentSymbol);
            Solve(x, y + 1, currentSymbol);
            Solve(x, y - 1, currentSymbol);
            Solve(x - 1, y, currentSymbol);
        }

        private static void ReadMatrix()
        {
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            matrix = new char[n, m];
            visited = new bool[n, m];
            areas = new Dictionary<char, int>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}