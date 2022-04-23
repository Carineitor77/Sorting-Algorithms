using System;

namespace SortingAlgorithms
{
    sealed class CocktailSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine(typeof(CocktailSort).Name);
            int left = 0;
            int right = arr.Length - 1;
            bool flag;

            while (left < right)
            {
                flag = false;
                for (int i = left; i < right; i++)
                {
                    if (Compare(arr[i], arr[i + 1]) == 1)
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        flag = true;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (Compare(arr[i], arr[i - 1]) == -1)
                    {
                        Swap(ref arr[i], ref arr[i - 1]);
                        flag = true;
                    }
                }
                left++;

                if (!flag)
                    break;
            }
            return (arr, SwapCount, ComparisonCount);
        }
    }
}
