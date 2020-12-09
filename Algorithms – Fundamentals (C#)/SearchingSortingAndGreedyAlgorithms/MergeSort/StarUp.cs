namespace MergeSort
{
    using System;
    using System.Linq;

    public class StarUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", MergeSort(numbers)));
        }
        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            var copy = new int[array.Length];
            Array.Copy(array, copy, array.Length);

            MergeSortHelper(array, copy, 0, array.Length - 1);

            return array;
        }

        public static void MergeSortHelper(
            int[] source, int[] copy, int leftIdx, int rightIdx)
        {
            if (leftIdx >= rightIdx)
                return;

            var middleIdx = (leftIdx + rightIdx) / 2;
            MergeSortHelper(copy, source, leftIdx, middleIdx);
            MergeSortHelper(copy, source, middleIdx + 1, rightIdx);

            MergeArrays(source, copy, leftIdx, middleIdx, rightIdx);
        }
        public static void MergeArrays(
            int[] source, int[] copy, int startIdx, int middleIdx, int endIdx)
        {
            var sourceIdx = startIdx;
            var leftIdx = startIdx; var rightIdx = middleIdx + 1;
            while (leftIdx <= middleIdx && rightIdx <= endIdx)
            {
                if (copy[leftIdx] < copy[rightIdx])
                    source[sourceIdx++] = copy[leftIdx++];
                else
                    source[sourceIdx++] = copy[rightIdx++];
            }
            while (leftIdx <= middleIdx)
            {
                source[sourceIdx] = copy[leftIdx];
                leftIdx += 1;
                sourceIdx += 1;
            }

            while (rightIdx <= endIdx)
            {
                source[sourceIdx] = copy[rightIdx];
                rightIdx += 1;
                sourceIdx += 1;
            }

        }


    }
}
