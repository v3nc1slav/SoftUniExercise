using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Radioactive_Mutant_Vampire_Bunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            PrintRadioactiveMutantVampireBunnies();
        }

        private static void PrintRadioactiveMutantVampireBunnies()
        {
            var numberOfRowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = numberOfRowAndCol[0];
            int col = numberOfRowAndCol[1];
            var matrix = new char[row, col];
            int playerRow = 0;
            int playerCol = 0;
            var thereARabbit = new List<string>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
            string commanda = Console.ReadLine();
            for (int i = 0; i < commanda.Length; i++)
            {
                string player = string.Empty;
                char move = commanda[i];
                if (move == 'U')
                {
                    matrix[playerRow, playerCol] = '.';
                    if (Outside(matrix, playerRow - 1, playerCol))
                    {
                        player = "won";
                    }
                    else if (IsThereARabbit(matrix, playerRow - 1, playerCol))
                    {
                        player = "dead";
                        playerRow--;
                    }
                    else
                    {
                        matrix[playerRow - 1, playerCol] = 'P';
                        playerRow--;
                    }
                }
                else if (move == 'D')
                {
                    matrix[playerRow, playerCol] = '.';
                    if (Outside(matrix, playerRow + 1, playerCol))
                    {
                        player = "won";
                    }
                    else if (IsThereARabbit(matrix, playerRow + 1, playerCol))
                    {
                        player = "dead";
                        playerRow++;
                    }
                    else
                    {
                        matrix[playerRow + 1, playerCol] = 'P';
                        playerRow++;
                    }
                }
                else if (move == 'L')
                {
                    matrix[playerRow, playerCol] = '.';
                    if (Outside(matrix, playerRow, playerCol - 1))
                    {
                        player = "won";
                    }
                    else if (IsThereARabbit(matrix, playerRow, playerCol - 1))
                    {
                        player = "dead";
                        playerCol--;
                    }
                    else
                    {
                        matrix[playerRow, playerCol - 1] = 'P';
                        playerCol--;
                    }
                }
                else if (move == 'R')
                {
                    matrix[playerRow, playerCol] = '.';
                    if (Outside(matrix, playerRow, playerCol + 1))
                    {
                        player = "won";
                    }
                    else if (IsThereARabbit(matrix, playerRow, playerCol + 1))
                    {
                        player = "dead";
                        playerCol++;
                    }
                    else
                    {
                        matrix[playerRow, playerCol + 1] = 'P';
                        playerCol++;
                    }
                }

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        if (IsThereARabbit(matrix, j, k))
                        {
                            thereARabbit.Add(j + " " + k);
                        }
                    }
                }
                int numbersRabbit = thereARabbit.Count;
                for (int l = 0; l < numbersRabbit; l++)
                {
                    var rabbit = thereARabbit[l].Split().ToArray();
                    row = int.Parse(rabbit[0]);
                    col = int.Parse(rabbit[1]);

                    if (Inside(matrix, row + 1, col))
                    {
                       if (IsThereAPlayer(matrix, row + 1, col))
                       {
                            player = "dead";
                            matrix[row, col + 1] = 'B';
                        }
                       else
                        {
                            matrix[row + 1, col] = 'B';

                        }
                    }
                    if (Inside(matrix, row - 1, col))
                    {
                        if (IsThereAPlayer(matrix, row - 1, col))
                        {
                            player = "dead";
                            matrix[row, col + 1] = 'B';
                        }
                        else
                        {
                            matrix[row - 1, col] = 'B';
                        }
                    }
                    if (Inside(matrix, row, col + 1))
                    {
                       if (IsThereAPlayer(matrix, row, col + 1))
                       {
                            player = "dead";
                            matrix[row, col + 1] = 'B';
                        }
                        else 
                        {
                            matrix[row, col + 1] = 'B';
                        }
                    }
                    if (Inside(matrix, row, col - 1))
                    {
                        if (IsThereAPlayer(matrix, row, col - 1))
                        {
                            player = "dead";
                            matrix[row, col + 1] = 'B';
                        }
                        else
                        {
                            matrix[row, col - 1] = 'B';
                        }
                    }
                }
                if (player == "won")
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }
                else if (player == "dead")
                {
                    PlayerDead(matrix, playerRow, playerCol);
                    return;
                }
         }
        }

        private static bool Inside(char[,] matrix, int row, int col)
        {
            return row < matrix.GetLength(0) && row >= 0
              && col < matrix.GetLength(1) && col >= 0;
        }

        private static bool IsThereAPlayer(char[,] matrix, int j, int k)
        {
            return matrix[j, k] == 'P';
        }

        private static void PlayerDead(char[,] matrix, int row, int col)
        {
            PrintMatrix(matrix);
            Console.WriteLine($"dead: {row} {col}");
        }

        private static bool IsThereARabbit(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'B';
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool Outside(char[,] matrix, int row, int col)
        {
            return row > matrix.GetLength(0)-1 || row < 0
               || col > matrix.GetLength(1)-1 || col < 0;
        }
    }
}
