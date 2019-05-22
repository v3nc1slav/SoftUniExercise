using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Diagonal_Difference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            PrintDiagonalDifference();
        }

        private static void PrintDiagonalDifference()
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int[,] cub = new int[sizeMatrix, sizeMatrix];
            for (int j = 0; j < cub.GetLength(0); j++)
            {
                int[] commanda = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int k = 0; k < cub.GetLength(1); k++)
                {
                    cub[j, k] = commanda[k];
                }
            }
            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;
            var number = 0;
            var row = 0;
            var col = 0;
            while (number < sizeMatrix)
            {
                primaryDiagonal += cub[row, col];
                row++;
                col++;
                number++;
            }
            number = 0;
            row = 0;
            col = sizeMatrix-1;
            while (number < sizeMatrix)
            {
                secondaryDiagonal += cub[row, col];
                row++;
                col--;
                number++;
            }
            var difference = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(difference);
        }
    }
}
