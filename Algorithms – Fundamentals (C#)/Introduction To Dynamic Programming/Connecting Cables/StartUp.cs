namespace ConnectingCables
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var DPMatrix = FillMatrix(numbers);

            Console.WriteLine($"Maximum pairs connected: {DPMatrix[numbers.Length, numbers.Length]}");
        }

        private static int[,] FillMatrix(int[] numbers)
        {
            var DPMatrix = new int[numbers.Length + 1, numbers.Length + 1];
            for (int i = 1; i < numbers.Length + 1; i++)
            {
                for (int j = 1; j < numbers.Length + 1; j++)
                {
                    if (numbers[i - 1] == j)
                    {
                        DPMatrix[i, j] = DPMatrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        DPMatrix[i, j] = Math.Max(DPMatrix[i - 1, j], DPMatrix[i, j - 1]);
                    }
                }
            }

            return DPMatrix;
        }
    }
}