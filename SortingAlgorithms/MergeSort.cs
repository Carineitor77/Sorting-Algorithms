using System;

namespace SortingAlgorithms
{
    sealed class MergeSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine(typeof(MergeSort).Name);
            arr = Sort(arr);
            return (arr, SwapCount, ComparisonCount);
        }

        private int[] Sort(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;

            int mid = arr.Length / 2;
            int[] left = arr[..mid];
            int[] right = arr[mid..];

            return Merge(Sort(left), Sort(right));
        }

        private int[] Merge(int[] left, int[] right)
        {
            int length = left.Length + right.Length;
            int leftPointer = 0;
            int rightPointer = 0;
            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                if (leftPointer < left.Length && rightPointer < right.Length)
                {
                    if(Compare(left[leftPointer], right[rightPointer]) == -1)
                    {
                        result[i] = left[leftPointer];
                        leftPointer++;
                    }
                    else
                    {
                        result[i] = right[rightPointer];
                        rightPointer++;
                    }
                }
                else
                {
                    if (rightPointer < right.Length)
                    {
                        result[i] = right[rightPointer];
                        rightPointer++;
                    }
                    else
                    {
                        result[i] = left[leftPointer];
                        leftPointer++;
                    }
                }
            }

            return result;
        }
    }
}