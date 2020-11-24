namespace Find_All_Paths_in_a_Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static List<char> path = new List<char>();
        private static int height, width;
        private static char[,] matrix;
        private static bool[,] used;

        static void Main()
        {
            height = int.Parse(Console.ReadLine());
            width = int.Parse(Console.ReadLine());
            matrix = new char[height, width];
            used = new bool[height, width];
            for (int i = 0; i < height; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col)) return;
            if (direction != 'S') path.Add(direction);
            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                Unmark(row, col);
            }

            try
            {
                path.RemoveAt(path.Count - 1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return;
            }

        }

        private static void Unmark(int row, int col) => used[row, col] = false;

        private static void Mark(int row, int col) => used[row, col] = true;

        private static bool IsVisited(int row, int col) => used[row, col];

        private static bool IsFree(int row, int col) => matrix[row, col] != '*';

        private static void PrintPath() => Console.WriteLine(string.Join("", path));

        private static bool IsExit(int row, int col) => matrix[row, col] == 'e';

        private static bool IsInBounds(int row, int col) => row < height && row >= 0 && col < width && col >= 0;
    }
}
