using System;
using System.Collections.Generic;

using SortingAlgorithms.DataStructures;

namespace SortingAlgorithms
{
    sealed class TreeSort : AlgorithmBase, IMakeSort
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine("TreeSort");
            var tree = new Tree<int>(arr);
            arr = tree.Inorder().ToArray();

            return (arr, SwapCount, ComparisonCount);
        }
    }
}
