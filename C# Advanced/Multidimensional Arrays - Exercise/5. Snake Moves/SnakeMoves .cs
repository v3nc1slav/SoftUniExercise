using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Snake_Moves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            PrintSnakeMoves();
        }

        private static void PrintSnakeMoves()
        {
            var matrixLength = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new char[matrixLength[0],matrixLength[1]];
            var snake = Console.ReadLine().ToArray();
            var queueSnake = new Queue<char>();
            for (int i = 0; i < snake.Length; i++)
            {
                queueSnake.Enqueue(snake[i]);
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var queue = queueSnake.Dequeue();
                    matrix[row, col] = queue;
                    queueSnake.Enqueue(queue);
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
