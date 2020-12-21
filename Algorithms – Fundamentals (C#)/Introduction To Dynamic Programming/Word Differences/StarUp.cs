namespace WordDifferences
{
    using System;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            int[,] DPMatrix = new int[str1.Length + 1, str2.Length + 1];

            InitializeMatrix(ref DPMatrix);
            FillMatrix(ref DPMatrix, str1, str2);
            Console.WriteLine($"Deletions and Insertions: " + ResultFromDPMatrix(DPMatrix));
        }

        private static object ResultFromDPMatrix(int[,] dpMatrix) =>
            dpMatrix[dpMatrix.GetLength(0) - 1, dpMatrix.GetLength(1) - 1];

        private static void FillMatrix(ref int[,] dpMatrix, string str1, string str2)
        {
            for (int r = 1; r < dpMatrix.GetLength(0); r++)
            {
                for (int c = 1; c < dpMatrix.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        dpMatrix[r, c] = dpMatrix[r - 1, c - 1];
                    }
                    else
                    {
                        dpMatrix[r, c] = Math.Min(dpMatrix[r - 1, c], dpMatrix[r, c - 1]) + 1;
                    }
                }
            }
        }

        private static void InitializeMatrix(ref int[,] dpMatrix)
        {
            for (int r = 0; r < dpMatrix.GetLength(0); r++)
            {
                dpMatrix[r, 0] = r;
            }

            for (int c = 0; c < dpMatrix.GetLength(1); c++)
            {
                dpMatrix[0, c] = c;
            }
        }
    }
}