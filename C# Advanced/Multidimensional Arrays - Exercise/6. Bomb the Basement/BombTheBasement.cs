using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Bomb_the_Basement
{
    class BombTheBasement
    {
        static void Main(string[] args)
        {
            PrintBombTheBasement();
        }

        private static void PrintBombTheBasement()
        {
            var values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var row = values[0];
            var col = values[1];
            var dimensions = new int[row, col];
            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var coordinatesRow = command[0];
            var coordinatesCol = command[1];
            var radius = command[2];
            dimensions[coordinatesRow, coordinatesCol] = 1;
            if (radius != 0)
            {
                for (int i = 0; i < dimensions.GetLength(0); i++)
                {
                    for (int j = 0; j < dimensions.GetLength(1); j++)
                    {
                        if ((i-coordinatesRow)* (i - coordinatesRow) + (j-coordinatesCol)* (j - coordinatesCol) <= radius*radius)
                        {
                            dimensions[i, j] = 1;
                        }
                    }
                }
            }
            for (int i = 0; i < dimensions.GetLength(1); i++)
            {
                for (int j = dimensions.GetLength(0)-2; j >= 0; j--)
                {
                    if (dimensions[j,i]==0 &&
                        dimensions[j+1,i]==1)
                    {
                        dimensions[j,i] = 1;
                        dimensions[j+1,i] = 0;
                        j = dimensions.GetLength(0) - 1;
                    }
                }
            }
            for (int i = 0 ; i < dimensions.GetLength(0); i++)
            {
                for (int j = 0 ; j < dimensions.GetLength(1); j++)
                {
                    Console.Write(dimensions[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}