using System;

namespace _7.Knight_Game
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            PrintKnightGame();
        }

        private static void PrintKnightGame()
        {
            var number = int.Parse(Console.ReadLine());
            var matrix = new char[number, number];
            var finalCounter = 0;
            var counter = 0;
            var maxCounter = 0;
            var maxRow = 0;
            var maxCol = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var commanda = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = commanda[j];
                }
            }
            while (true)
            {
                maxCounter = 0;
                maxRow = 0;
                maxCol = 0;
                for (int i = 0; i < matrix.GetLength(0) ; i++)
                {
                    for (int j = 0; j < matrix.GetLength(1) ; j++)
                    {
                        counter = 0;
                        if (matrix[i, j] == 'K')
                        {
                            if (Inside(matrix, i + 2, j + 1) && matrix[i + 2, j + 1] == 'K')
                            {
                                counter++;
                            }
                            if (Inside(matrix, i + 2, j - 1) && matrix[i + 2, j - 1] == 'K')
                            {
                                counter++;
                            }
                            if (Inside(matrix, i - 2, j + 1) && matrix[i - 2, j + 1] == 'K')
                            {
                                counter++;
                            }
                            if (Inside(matrix, i - 2, j - 1) && matrix[i - 2, j - 1] == 'K')
                            {
                                counter++;
                            }
                            if (Inside(matrix, i + 1, j + 2) && matrix[i + 1, j + 2] == 'K')
                            {
                                counter++;
                            }
                            if (Inside(matrix, i + 1, j - 2) && matrix[i + 1, j - 2] == 'K')
                            {
                                counter++;
                            }
                            if (Inside(matrix, i - 1, j + 2) && matrix[i - 1, j + 2] == 'K')
                            {
                                counter++;
                            }
                            if (Inside(matrix, i - 1, j - 2) && matrix[i - 1, j - 2] == 'K')
                            {
                                counter++;
                            }
                            if (counter > maxCounter)
                            {
                                maxCounter = counter;
                                maxRow = i;
                                maxCol = j;
                            }
                        }
                    }
                }
                if (maxCounter==0)
                {
                    break;
                }
                matrix[maxRow, maxCol] = 'O';
                finalCounter++;
            }
            Console.WriteLine(finalCounter);
        }

        private static bool Inside(char[,] matrix, int row, int col)
        {
            return row < matrix.GetLength(0) && row >= 0
                && col < matrix.GetLength(1) && col >= 0;
        }
    }
}
