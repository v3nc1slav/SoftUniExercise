namespace Recursion_and_Backtracking
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(GetSum(array, array.Length-1));
        }

        private static int GetSum(int[] arr, int index)
        {
            if (index == 0)
            {
                return arr[index];
            }
            return arr[index] + GetSum(arr, index - 1);
        }
    }
}
