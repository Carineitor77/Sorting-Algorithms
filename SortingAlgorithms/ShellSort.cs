using System;

namespace SortingAlgorithms
{
    sealed class ShellSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine("ShellSort");
            int step = arr.Length / 2;

            while (step > 0)
            {
                for (int i = step; i < arr.Length; i++)
                {
                    int j = i;
                    while ((j >= step) && Compare(arr[j - step], arr[j]) == 1)
                    {
                        Swap(ref arr[j - step], ref arr[j]);
                        j -= step;
                    }
                }
                step /= 2;
            }
            return (arr, SwapCount, ComparisonCount);
        }
    }
}
