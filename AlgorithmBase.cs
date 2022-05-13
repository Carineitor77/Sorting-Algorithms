using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    class AlgorithmBase : ISortArray
    {
        private int key;
        private int arraySize;

        public int SwapCount { get; set; } = 0;
        public int ComparisonCount { get; set; } = 0;

        public int Key
        {
            get { return key; }
            set { key = value; }
        }
        public int ArraySize
        {
            get { return arraySize; }
            set { arraySize = value >= 2 ? value : 10000; }
        }

        public AlgorithmBase() { }

        public AlgorithmBase(int key, int arraySize)
        {
            Key = key;
            ArraySize = arraySize;
        }

        /// <summary>
        /// Swaps two variables. With SwapCount
        /// </summary>
        /// <param name="firstPosition"></param>
        /// <param name="secondPosition"></param>
        public void Swap(ref int firstPosition, ref int secondPosition)
        {
            int temp = firstPosition;
            firstPosition = secondPosition;
            secondPosition = temp;

            SwapCount++;
        }

        /// <summary>
        /// Comparison analogue of "firstValue.CompareTo(secondValue)" with ComparisonCount
        /// </summary>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        public int Compare(int firstValue, int secondValue)
        {
            ComparisonCount++;

            return firstValue.CompareTo(secondValue);
        }
        public void StartSorting()
        {
            if (Key == 0)
            {
                while (ArraySize <= 1)
                {
                    Console.Write("Enter an array size: ");
                    int.TryParse(Console.ReadLine(), out arraySize);
                }
                ChooseFillingType(ArraySize);
            }
            else
                FillArray(Key, ArraySize);
        }
        public void ChooseFillingType(in int ArraySize)
        {
            Console.WriteLine("Enter '1' to sorted populate the array");
            Console.WriteLine("Enter '2' to UNsorted populate the array");
            Console.WriteLine("Enter '3' to randomly populate the array");

            while (true)
            {
                try
                {
                    Console.Write("key: ");
                    Key = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(new string('-', 100));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
            FillArray(Key, ArraySize);
        }
        public int[] FillArray(int Key, int ArraySize)
        {
            int[] arr = new int[ArraySize];
            Random rnd = new Random();

            if (Key == 1)
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = i;
            }
            else if (Key == 2)
            {
                for (int i = arr.Length, j = 0; i > 0; i--, j++)
                    arr[j] = i;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = rnd.Next(0, 10000);
            }

            return arr;
        }
        public void SortArray(IMakeSort sortArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            int[] arr = FillArray(Key, ArraySize);

            stopwatch.Start();
            var tuple = sortArray.MakeSort(arr);
            stopwatch.Stop();

            PrintResult(tuple, stopwatch.ElapsedMilliseconds);
        }
        public void PrintResult((int[], int, int) tuple, in long time)
        {
            Console.WriteLine($"\nArraySize: {ArraySize}");
            Console.WriteLine($"Algorithm running time: {time}(milliseconds)");
            if (tuple.Item2 != 0 || tuple.Item3 != 0)
            {
                Console.WriteLine($"SwapCount: {tuple.Item2}");
                Console.WriteLine($"ComparisonCount: {tuple.Item3}");
            }
            Console.WriteLine("Print array to console?");
            string str = Console.ReadLine() ?? "";
            string[] answers = { "yes", "ye", "y" };

            for (int i = 0; i < answers.Length; i++)
            {
                if (str?.ToLower().CompareTo(answers[i]) == 0)
                {
                    for (int j = 0; j < tuple.Item1.Length; j++)
                        Console.Write($"{tuple.Item1[j]}  ");
                }
            }
            Console.WriteLine("\n\n" + new string('-', 100));
        }
    }
}