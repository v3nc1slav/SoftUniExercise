using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Matrix_shuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            PrintMatrixShuffling();
        }

        private static void PrintMatrixShuffling()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new string[input[0], input[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var matrixValues = Console.ReadLine().Split();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrixValues[j];
                }
            }
            while (true)
            {
                var commanda = Console.ReadLine().Split();
                if (commanda[0] == "END")
                {
                    return;
                }
                else if (commanda[0] != "swap"
                    ||commanda.Length != 5
                    ||int.Parse(commanda[1]) > matrix.GetLength(0)
                    ||int.Parse(commanda[2]) > matrix.GetLength(1)
                    ||int.Parse(commanda[3]) > matrix.GetLength(0)
                    ||int.Parse(commanda[4]) > matrix.GetLength(1)
                    )
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    var values = matrix[int.Parse(commanda[1]), int.Parse(commanda[2])];
                    matrix[int.Parse(commanda[1]), int.Parse(commanda[2])] = matrix[int.Parse(commanda[3]), int.Parse(commanda[4])];
                    matrix[int.Parse(commanda[3]), int.Parse(commanda[4])] = values;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
