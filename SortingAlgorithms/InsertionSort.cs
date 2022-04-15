using System;

namespace SortingAlgorithms
{
    sealed class InsertionSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine("InsertionSort");
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i;

                while (j > 0 && Compare(temp, arr[j - 1]) == -1)
                {
                    Swap(ref arr[j], ref arr[j - 1]);
                    j--;
                }
                arr[j] = temp;
            }
            return (arr, SwapCount, ComparisonCount);
        }
    }
}
