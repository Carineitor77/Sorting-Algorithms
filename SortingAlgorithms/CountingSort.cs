using System;

namespace SortingAlgorithms
{
    sealed class CountingSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine(typeof(CountingSort).Name);
            int[] temp = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                temp[arr[i]]++;
            }

            int point1 = 0, p2 = 0;
            while (p2 < arr.Length)
            {
                if (temp[point1] > 0)
                {
                    arr[p2] = point1;
                    temp[point1]--;
                    p2++;
                }
                else
                {
                    point1++;
                }
            }
            return (arr, SwapCount, ComparisonCount);
        }
    }
}