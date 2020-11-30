namespace Permutations_without_Repetition
{
    using System;
    public class StarUp
    {
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            int k = int.Parse(Console.ReadLine()); ;
            variations = new string[k];
            used = new bool[elements.Length];

            Variations(0);
        }

        static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Print();
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variations[index] = elements[i];
                        Variations(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", variations));
        }
    }
}
