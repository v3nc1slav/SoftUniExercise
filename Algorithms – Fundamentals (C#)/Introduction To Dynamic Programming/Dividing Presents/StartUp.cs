namespace Dividingpresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var presents = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sums = GetSums(presents);
            var AlanSum = GetAlanSums(sums, presents.Sum() / 2);
            var BobSum = presents.Sum() - AlanSum;
            if (BobSum < AlanSum)
            {
                int temp = AlanSum;
                AlanSum = BobSum;
                BobSum = temp;
            }

            Console.WriteLine($"Difference: {Math.Abs(AlanSum - BobSum)}");
            Console.WriteLine($"Alan:{AlanSum} Bob:{BobSum}");
            Console.WriteLine($"Alan takes: {GetAlanPath(AlanSum, sums)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static string GetAlanPath(int alanSum, Dictionary<int, int> sums)
        {
            int currentSum = alanSum;
            List<int> presents = new List<int>();
            while (true)
            {
                if (currentSum == 0) break;
                presents.Add(sums[currentSum]);
                currentSum -= sums[currentSum];
            }

            return string.Join(" ", presents);
        }

        private static int GetAlanSums(Dictionary<int, int> sums, int targetSum)
        {
            if (sums.ContainsKey(targetSum)) return targetSum;
            sums = sums.OrderBy(x => Math.Abs(targetSum - x.Key)).ToDictionary(x => x.Key, x => x.Value);
            return sums.First().Key;
        }

        private static Dictionary<int, int> GetSums(int[] presents)
        {
            var sums = new Dictionary<int, int>();
            foreach (var present in presents)
            {
                foreach (var sum in sums.Keys.ToArray())
                {
                    if (!sums.ContainsKey(sum + present))
                    {
                        sums.Add(sum + present, present);
                    }
                }

                if (!sums.ContainsKey(present))
                {
                    sums.Add(present, present);
                }
            }

            return sums;
        }
    }
}
