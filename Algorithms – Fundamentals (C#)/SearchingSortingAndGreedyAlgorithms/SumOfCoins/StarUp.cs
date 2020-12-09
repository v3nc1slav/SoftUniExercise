namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            var availableCoins = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var targetSum = int.Parse(Console.ReadLine());
            Dictionary<int, int> selectedCoins = new Dictionary<int, int>();

            try
            {
                selectedCoins = ChooseCoins(availableCoins, targetSum);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                return;
            }
            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }

        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortedCoins = coins.OrderByDescending(c => c).ToList();

            var chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int coinIndex = 0;

            while (coinIndex < sortedCoins.Count && currentSum != targetSum)
            {
                var currentCoinValue = sortedCoins[coinIndex];
                var remainingSum = targetSum - currentSum;
                var numberOfCoins = remainingSum / currentCoinValue;

                if (numberOfCoins > 0)
                {
                    chosenCoins.Add(currentCoinValue, numberOfCoins);
                    currentSum += currentCoinValue * numberOfCoins;
                }

                coinIndex++;
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException();
            }
            return chosenCoins;
        }
    }
}
