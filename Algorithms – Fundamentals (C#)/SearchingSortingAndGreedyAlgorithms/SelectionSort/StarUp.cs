namespace SelectionSort
{
    using System;
    using System.Linq;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Sort(numbers);
        }

        private static void Sort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; ++i)
            {
                int temp = numbers[i];
                int[] tempSubArray = numbers.TakeLast(numbers.Length - i).ToArray();
                int minIndex = Array.IndexOf(numbers.TakeLast(numbers.Length - i).ToArray(), numbers.TakeLast(numbers.Length - i).ToArray().Min());
                numbers[i] = numbers[minIndex + i];
                numbers[minIndex + i] = temp;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
