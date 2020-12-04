namespace Combinations_with_Repetition
{
    using System;
    public class StarUp
    {
        private static int[] combinations;
        private static int n;
        private static int k;
        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            combinations = new int[k];
            Comb(0, 1);
        }

        private static void Comb(int index, int start)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }
            for (int i = start; i <= n; i++)
            {
                combinations[index] = i;
                Comb(index + 1, i);
            }
        }
    }
}
