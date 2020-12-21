namespace BinomialCoefficients
{
    using System;

    public class StartUp
    {
        public static long[,] matrix;

        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long k = long.Parse(Console.ReadLine());
            matrix = new long[n + 2, n + 2];
            for (int i = 0; i <= n; i++)
            {
                matrix[i, 0] = 1;
                matrix[i, i] = 1;
            }

            Console.WriteLine(Solve(n, k));
        }

        private static long Solve(long n, long k)
        {
            if (matrix[n, k] != 0)
            {
                return matrix[n, k];
            }

            if (matrix[n - 1, k - 1] != 0 && matrix[n - 1, k] != 0)
            {
                return matrix[n - 1, k - 1] + matrix[n - 1, k];
            }

            if (matrix[n - 1, k - 1] == 0) matrix[n - 1, k - 1] = Solve(n - 1, k - 1);
            if (matrix[n - 1, k] == 0) matrix[n - 1, k] = Solve(n - 1, k);

            matrix[n, k] = matrix[n - 1, k - 1] + matrix[n - 1, k];
            return matrix[n, k];
        }
    }
}