using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Squares_in_Matrix
{
    class SquaresInMatrix 
    {
        static void Main(string[] args)
        {
            PrintSquaresInMatrix();
        }

        private static void PrintSquaresInMatrix()
        {
            var commanda = Console.ReadLine().Split().ToArray();
            var row = int.Parse(commanda[0]);
            var col = int.Parse(commanda[1]);
            var matrix = new string[row, col];
            var counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var matrixValues = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrixValues[j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    if (matrix[i,j]==matrix[i+1,j]&&
                        matrix[i,j]==matrix[i,j+1]&&
                        matrix[i,j]==matrix[i+1,j+1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
