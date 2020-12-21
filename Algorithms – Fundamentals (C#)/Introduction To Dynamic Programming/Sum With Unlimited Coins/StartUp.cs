namespace SumWithUnlimitedAmountOfCoins
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine());
            int[] sums = new int[targetSum + 1];
            Array.Sort(numbers);
            sums[0] = 1;
            GenerateSums(ref sums, numbers);
            Console.WriteLine(sums[targetSum]);
        }

        private static void GenerateSums(ref int[] sums, int[] numbers)
        {
            foreach (var number in numbers)
            {
                for (int i = number; i < sums.Length; i++)
                {
                    sums[i] += sums[i - number];
                }
            }
        }
    }
}
