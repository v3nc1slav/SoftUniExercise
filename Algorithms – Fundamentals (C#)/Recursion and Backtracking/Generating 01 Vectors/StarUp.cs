namespace Generating_01_Vectors
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            Gen01(arr, 0);
        }

        private static void Gen01(int[] array, int index)
        {
            if (index >= array.Length) Console.WriteLine(string.Join("", array));
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    array[index] = i;
                    Gen01(array, index + 1);
                }
            }
        }
    }
}