using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Maximal_Sum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            PrintMaximalSum();
        }

        private static void PrintMaximalSum()
        {
            var commanda = Console.ReadLine().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries).ToArray();
            var row = int.Parse(commanda[0]);
            var col = int.Parse(commanda[1]);
            var matrix = new int[row, col];
            var maxSum = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var matrixValues = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrixValues[j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var sum = 0;
                    sum += matrix[i, j] +
                             matrix[i + 1, j] +
                             matrix[i, j + 1] +
                             matrix[i + 1, j + 1] +
                             matrix[i, j + 2] +
                             matrix[i + 1, j + 2] +
                             matrix[i + 2, j] +
                             matrix[i + 2, j + 1] +
                             matrix[i + 2, j + 2];
                    if (sum>maxSum)
                    {
                        maxSum = sum;
                        row = i;
                        col = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = row; i <row+ 3; i++)
            {
                for (int j = col; j <col+ 3; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
