namespace Nested_Loops
{
    using System;
    public class StarUp
    {
        public static int[] array;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            array = new int[n];
            PrintNumbers(0, array);
        }

        private static void PrintNumbers(int index, int[] array)
        {
            if (index == array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[index] = i + 1;
                PrintNumbers(index + 1, array);
            }
        }
    }
}
