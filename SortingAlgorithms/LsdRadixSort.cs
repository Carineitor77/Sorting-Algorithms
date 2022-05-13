using System;

namespace SortingAlgorithms
{
    sealed class LsdRadixSort<T> : AlgorithmBase, IMakeSort where T: IComparable
    {
        public (int[], int, int) MakeSort(int[] arr)
        {
            Console.WriteLine(typeof(LsdRadixSort<T>).Name);
            var groups = new List<List<int>>();
            for (int i = 0; i < 10; i++)
            {
                groups.Add(new List<int>());
            }

            int length = GetMaxLength(arr);

            for (int step = 0; step < length; step++)
            {
                foreach (var item in arr)
                {
                    var i = item.GetHashCode();
                    var value = i % (int)Math.Pow(10, step + 1) / (int)Math.Pow(10, step);
                    groups[value].Add(item);
                }

                var j = 0;
                foreach (var group in groups)
                {
                    foreach (var item in group)
                    {
                        arr[j] = item;
                        j++;
                    }
                }

                foreach (var group in groups)
                {
                    group.Clear();
                }
            }
            return (arr, SwapCount, ComparisonCount);
        }
        private int GetMaxLength(int[] arr)
        {
            int length = 0;
            foreach (var item in arr)
            {
                if (item.GetHashCode() < 0)
                {
                    throw new ArgumentException("Digit sort only supports integers (greater than or equal to zero)", nameof(arr));
                }

                //var l = Convert.ToInt32(Math.Log10(item.GetHashCode()) + 1); // Does not work with item = 0. Gives -inf.
                var l = item.GetHashCode().ToString().Length;
                if (l > length)
                {
                    length = l;
                }
            }
            return length;
        }
    }
}

