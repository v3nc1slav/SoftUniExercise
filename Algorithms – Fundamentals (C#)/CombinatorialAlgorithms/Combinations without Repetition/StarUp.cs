namespace Combinations_without_Repetition
{
    using System;

    public class StarUp
    {
        private static string[] elements;
        private static string[] combinations;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            combinations = new string[n];
            Comb(0, 0);
        }

        private static void Comb(int index, int start)
        {
            if (index >= combinations.Length)
            {
                Print();
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    combinations[index] = elements[i];
                    Comb(index + 1, i + 1);
                }
            }

        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", combinations));
        }
    }
}
