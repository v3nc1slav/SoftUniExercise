namespace BubbleSort
{
    using System;
    using System.Linq;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers.Length - i; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        Swap(ref numbers, j - 1, j);
                    }
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