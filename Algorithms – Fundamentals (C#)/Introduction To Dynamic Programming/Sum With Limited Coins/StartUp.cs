namespace SumWithLimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine());
            var sums = GetSums(coins);
            Console.WriteLine(sums[targetSum]);
        }

        private static Dictionary<int, int> GetSums(int[] coins)
        {
            var sums = new Dictionary<int, int>();
            foreach (var coin in coins)
            {
                foreach (var sum in sums.Keys.ToArray())
                {
                    if (!sums.ContainsKey(sum + coin))
                    {
                        sums.Add(sum + coin, 1);
                    }
                    else
                    {
                        sums[sum + coin]++;
                    }

                }

                if (!sums.ContainsKey(coin))
                {
                    sums.Add(coin, 1);
                }
                else
                {
                    sums[coin]++;
                }
            }

            return sums;
        }
    }
}