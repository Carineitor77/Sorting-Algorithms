using System;

namespace SortingAlgorithms
{
    sealed class SelectionSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine("SelectionSort");
            int minIdex = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                minIdex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (Compare(arr[j], arr[minIdex]) == -1)
                        minIdex = j;
                }
                if (i != minIdex)
                    Swap(ref arr[i], ref arr[minIdex]);
            }
            return (arr, SwapCount, ComparisonCount);
        }
    }
}
