namespace InsertionSort
{
    using System;
    using System.Linq;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 1; i < numbers.Length; i++)
            {
                var j = i;
                while (j > 0 && numbers[j] < numbers[j - 1])
                {
                    Swap(ref numbers, j - 1, j);
                    j--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Swap(ref int[] numbers, int i, in int j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}