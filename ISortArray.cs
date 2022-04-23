using System.Collections;

namespace SortingAlgorithms
{
    interface ISortArray
    {
        int Key { get; set; }
        int ArraySize { get; set; }
        int SwapCount { get; set; }

        void Swap(ref int firstPosition, ref int secondPosition);
        int Compare(int firstValue, int secondValue);
        void StartSorting();
        void ChooseFillingType(in int size);
        int[] FillArray(int key, int size);
        void SortArray(IMakeSort getArray);
        void PrintResult((int[], int, int) tuple, in long time);
    }
}
