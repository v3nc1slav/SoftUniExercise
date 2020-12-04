namespace School_Teams
{
    using System;
    using System.Collections.Generic;

    public class StarUp
    {
        private static string[] girls;
        private static string[] boys;
        private static string[] slots;
        private static List<string> boysResult;
        private static bool[] usedBoys;
        private static List<string> girlsResult;

        public static void Main(string[] args)
        {
            girls = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            boys = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            usedBoys = new bool[boys.Length];
            boysResult = new List<string>();
            girlsResult = new List<string>();
            slots = new string[3];
            Generate(0, 0, girls, ref girlsResult);
            slots = new string[2];
            Generate(0, 0, boys, ref boysResult);
            foreach (var girl in girlsResult)
            {
                foreach (var boy in boysResult)
                {
                    Console.WriteLine(girl + ", " + boy);
                }
            }
        }

        static void Generate(int index, int start, string[] elements, ref List<string> result)
        {
            if (index >= slots.Length)
                result.Add(string.Join(", ", slots));
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    slots[index] = elements[i];
                    Generate(index + 1, i + 1, elements, ref result);
                }
            }
        }
    }
}