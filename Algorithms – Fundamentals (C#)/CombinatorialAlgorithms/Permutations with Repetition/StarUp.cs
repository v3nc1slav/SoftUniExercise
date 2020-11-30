namespace Permutations_with_Repetition
{
    using System;
    public class StarUp
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Print();
            }
            else
            {
                Permute(index + 1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            string temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", permutations));
        }
    }
}
