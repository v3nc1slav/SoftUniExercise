namespace N_Choose_K_Count
{
    using System;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(PascalTriangle(n, k));
        }

        private static int PascalTriangle(int n, int k)
        {
            if (n == 0 || n == 1) return 1;
            if (k == 0 || k == n) return 1;
            else
            {
                return PascalTriangle(n - 1, k - 1) + PascalTriangle(n - 1, k);
            }
        }
    }
}
