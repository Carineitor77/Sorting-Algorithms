namespace SortingAlgorithms
{
    class Program
    {
        static void Main()
        {
            ISortArray array = new AlgorithmBase(key: (int)TypeOfFilling.random, arraySize: 10000);
            IMakeSort[] makeSort = {
                new BubbleSort(),
                new GnomeSort(),
                new CocktailSort(),
                new SelectionSort(),
                new InsertionSort(),
                new ShellSort(),
                new TreeSort(),
                new HeapSort(),
                new RadixSort(),
                new MergeSort(),
                new QuickSort(),
                new CountingSort(),
                new LsdRadixSort<int>()
            };

            array.StartSorting();
            foreach (var item in makeSort)
                if (item is IMakeSort i)
                    array.SortArray(i);
        }
    }
}