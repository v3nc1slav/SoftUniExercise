namespace MinimumEditDistance
{
    using System;

    public class StartUp
    {
        public static int replaceCost, insertCost, deleteCost;
        public static string str1, str2;

        public static void Main(string[] args)
        {
            replaceCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
            var DPMatrix = FillMatrix();
            Console.WriteLine($"Minimum edit distance: {DPMatrix[DPMatrix.GetLength(0) - 1, DPMatrix.GetLength(1) - 1]}");
        }

        private static int[,] FillMatrix()
        {
            var DPMatrix = new int[str1.Length + 1, str2.Length + 1];
            for (int i = 0; i < DPMatrix.GetLength(1); i++)
            {
                DPMatrix[0, i] = i * insertCost;
            }

            for (int i = 0; i < DPMatrix.GetLength(0); i++)
            {
                DPMatrix[i, 0] = i * deleteCost;
            }

            for (int i = 1; i < DPMatrix.GetLength(0); i++)
            {
                for (int j = 1; j < DPMatrix.GetLength(1); j++)
                {
                    int ValueWithReplacement;
                    if (str1[i - 1] != str2[j - 1])
                        ValueWithReplacement = DPMatrix[i - 1, j - 1] + replaceCost;
                    else
                        ValueWithReplacement = DPMatrix[i - 1, j - 1];
                    int ValueWithDeletion = DPMatrix[i - 1, j] + deleteCost;
                    int ValueWithInsertion = DPMatrix[i, j - 1] + insertCost;
                    DPMatrix[i, j] = Math.Min(ValueWithInsertion, Math.Min(ValueWithDeletion, ValueWithReplacement));
                }
            }

            return DPMatrix;
        }
    }
}