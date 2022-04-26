using System;

namespace SortingAlgorithms
{
    sealed class QuickSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine(typeof(QuickSort).Name);
            Qsort(ref arr, 0, arr.Length - 1);
            return (arr, SwapCount, ComparisonCount);
        }

        private void Qsort(ref int[] arr, int left, int right)
        {
            if (left >= right)
                return;

            int pivot = Sorting(ref arr, left, right);
            Qsort(ref arr, left, pivot - 1);
            Qsort(ref arr, pivot + 1, right);
        }

        private int Sorting(ref int[] arr, int left, int right)
        {
            int pointer = left;

            // The abutting element is under the Right address.
            for (int i = left; i <= right; i++)
            {
                if (Compare(arr[i], arr[right]) == -1)
                {
                    Swap(ref arr[pointer], ref arr[i]);
                    pointer++;
                }
            }

            Swap(ref arr[pointer], ref arr[right]);
            return pointer;
        }
    }
}