using System;

namespace SortingAlgorithms
{
    sealed class GnomeSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine("GnomeSort");
            int i = 1;

            while (i < arr.Length)
            {
                if(i == 0 || Compare(arr[i], arr[i - 1]) != -1)
                {
                    i++;
                }
                else
                {
                    Swap(ref arr[i], ref arr[i - 1]);
                    i--;
                }
            }
            return (arr, SwapCount, ComparisonCount);
        }
    }
}

