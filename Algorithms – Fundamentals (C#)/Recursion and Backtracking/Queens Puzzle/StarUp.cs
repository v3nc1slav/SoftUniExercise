namespace Queens_Puzzle
{
    using System;

    public class StarUp
    {
        private const int length = 8;
        private static bool[,] board;
        private static bool[] used;
        private static int solutionsCounter = 0;

        static void Main()
        {
            board = new bool[length, length];
            used = new bool[46];
            PlaceQueen(0);
            //Console.WriteLine(solutionsCounter);
        }

        private static void PlaceQueen(int row)
        {
            if (row == length) PrintSolution();
            else for (int col = 0; col < length; col++)
                {
                    if (IsFree(row, col))
                    {
                        Mark(row, col);
                        PlaceQueen(row + 1);
                        Unmark(row, col);
                    }
                }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    Console.Write((board[row, col] ? '*' : '-') + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            solutionsCounter++;
        }

        private static void Unmark(int row, int col)
        {
            board[row, col] = false;
            used[row] = false;
            used[col + 8] = false;
            used[(col - row) + 23] = false;
            used[(row + col) + 31] = false;
        }

        private static void Mark(int row, int col)
        {
            board[row, col] = true;
            used[row] = true;
            used[col + 8] = true;
            used[(col - row) + 23] = true;
            used[(row + col) + 31] = true;
        }

        private static bool IsFree(int row, int col)
        {
            if (used[row]) return false;
            if (used[col + 8]) return false;
            if (used[(col - row) + 23]) return false;
            if (used[(row + col) + 31]) return false;
            return true;
        }
    }
}
