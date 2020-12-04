namespace Reverse_Array
{
    using System;
    using System.Linq;

    public class StarUp
    {
        public static int[] array;

        public static void Main(string[] args)
        {
            array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            PrintArray(array.Length - 1);
        }

        private static void PrintArray(int index)
        {
            if (index < 0) return;
            Console.Write(array[index] + " ");
            PrintArray(index - 1);
        }
    }
}
