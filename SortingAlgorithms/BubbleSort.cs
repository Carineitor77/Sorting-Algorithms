using System;

namespace SortingAlgorithms
{
    sealed class BubbleSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine("BubbleSort");
            bool flag;

            do
            {
                flag = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (Compare(arr[i], arr[i + 1]) == 1)
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        flag = true;
                    }
                }
            } while (flag);
            return (arr, SwapCount, ComparisonCount);
        }
    }
}
