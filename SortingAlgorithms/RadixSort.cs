using System;

namespace SortingAlgorithms
{
    sealed class RadixSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine(typeof(RadixSort).Name);
            int i, j;
            int[] tmp = new int[arr.Length];

            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
            return (arr, SwapCount, ComparisonCount);
        }
    }
}