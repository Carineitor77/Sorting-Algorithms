using System;
using System.Collections.Generic;

using SortingAlgorithms.DataStructures;

namespace SortingAlgorithms
{
    sealed class HeapSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine(typeof(HeapSort).Name);
            var heap = new Heap<int>(arr);
            arr = heap.Order().ToArray();

            return (arr, SwapCount, ComparisonCount);
        }
    }
}