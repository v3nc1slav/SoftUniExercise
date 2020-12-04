namespace Connected_Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarUp
    {
            private static char[,] matrix;
            private static int rows, cols;
            private static bool[,] used;
            public static void Main(string[] args)
            {
                int rows = int.Parse(Console.ReadLine());
                int cols = int.Parse(Console.ReadLine());
                used = new bool[rows, cols];
                matrix = new char[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    string input = Console.ReadLine();
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = input[j];
                    }
                }
                FindAreas();
            }

            private static void FindAreas()
            {
                rows = matrix.GetLength(0);
                cols = matrix.GetLength(1);
                List<Area> allAreas = new List<Area>();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] == '-')
                        {
                            int size = 0;
                            TraverseArea(i, j, ref size);
                            allAreas.Add(new Area(i, j, size));
                        }
                    }
                }

                allAreas = allAreas.Where(a => a.size != 0).ToList();
                allAreas = allAreas.OrderByDescending(a => a.size)
                    .ThenBy(a => a.x)
                    .ThenBy(a => a.y).ToList();
                PrintAreas(allAreas);
            }

            private static void PrintAreas(List<Area> allAreas)
            {
                Console.WriteLine($"Total areas found: {allAreas.Count}");
                for (int i = 0; i < allAreas.Count; i++)
                {
                    Console.WriteLine($"Area #{i + 1} at ({allAreas[i].x}, {allAreas[i].y}), size: {allAreas[i].size}");
                }
            }

            private static void TraverseArea(int x, int y, ref int size)
            {
                if (!IsInside(x, y) || matrix[x, y] == '*' || used[x, y])
                {
                    return;
                }
                size = size + 1;
                used[x, y] = true;
                TraverseArea(x, y + 1, ref size);
                TraverseArea(x + 1, y, ref size);
                TraverseArea(x - 1, y, ref size);
                TraverseArea(x, y - 1, ref size);
            }

            private static bool IsInside(int x, int y)
            {
                if (x >= rows || x < 0) return false;
                if (y >= cols || y < 0) return false;
                return true;
            }
            public class Area
            {
                public int x;
                public int y;
                public int size;

                public Area(int x, int y, int size)
                {
                    this.x = x;
                    this.y = y;
                    this.size = size;
                }
            }
    }
}
