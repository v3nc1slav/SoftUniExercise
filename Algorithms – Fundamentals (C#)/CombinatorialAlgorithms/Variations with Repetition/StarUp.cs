namespace Variations_with_Repetition
{
    using System;

    public class StarUp
    {
        private static string[] elements;
        private static string[] variations;
        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            int k = int.Parse(Console.ReadLine()); ;
            variations = new string[k];

            Variations(0);
        }

        static void Variations(int index)
        {
            if (index >= variations.Length)
                Print();
            else
                for (int i = 0; i < elements.Length; i++)
                {
                    variations[index] = elements[i];
                    Variations(index + 1);
                }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", variations));
        }
    }
}
