namespace QuickSort
{
    using System;
    using System.Linq;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            QuickSortHelper(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(" ", numbers));
        }

        public static void QuickSortHelper(int[] array, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx)
            {
                return;
            }

            var pivotIdx = startIdx;
            var leftIdx = startIdx + 1;
            var rightIdx = endIdx;
            while (leftIdx <= rightIdx)
            {
                if (array[leftIdx] > array[pivotIdx] && array[rightIdx] < array[pivotIdx])
                {
                    Swap(ref array, leftIdx, rightIdx);
                }

                if (array[leftIdx] <= array[pivotIdx])
                {
                    leftIdx += 1;
                }

                if (array[rightIdx] >= array[pivotIdx])
                {
                    rightIdx -= 1;
                }
            }
            Swap(ref array, pivotIdx, rightIdx);

            var isLeftSubArraysSmaller =
                rightIdx - 1 - startIdx < endIdx - (rightIdx + 1);

            if (isLeftSubArraysSmaller)
            {
                QuickSortHelper(array, startIdx, rightIdx - 1);
                QuickSortHelper(array, rightIdx + 1, endIdx);
            }

            else
            {
                QuickSortHelper(array, rightIdx + 1, endIdx);
                QuickSortHelper(array, startIdx, rightIdx - 1);
            }

        }

        private static void Swap(ref int[] numbers, int i, in int j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
