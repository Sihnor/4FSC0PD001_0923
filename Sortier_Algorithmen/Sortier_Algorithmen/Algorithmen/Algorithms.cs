using System;

namespace Sortier_Algorithmen.Algorithmen
{
    public abstract class Algorithms
    {
        public enum ESort
        {
            Ascending,
            Descending,
            ZigZag
        }
        
        public enum EAlgorithm
        {
            BogoSort,
            BubbleSort,
            CocktailSort,
            CombSort,
            GnomeSort,
            All,
            None
        }
        
        protected int[] NumberArray;
        protected int[] SortedNumberArray;
        protected string Name;
        protected readonly ESort SortType;

        #region Constructor

        protected Algorithms(ESort sortType = ESort.Ascending)
        {
            this.CreateRandomNumberArray(100000, 1, 1000000);
            this.SortType = sortType;
        }

        protected Algorithms(int arrayLength, int minNumber, int maxNumber, ESort sortType = ESort.Ascending)
        {
            this.CreateRandomNumberArray(arrayLength, minNumber, maxNumber);
            this.SortType = sortType;
        }

        protected Algorithms(int[] numberArray, ESort sortType = ESort.Ascending)
        {
            if (numberArray.Length == 0)
            {
                numberArray = Algorithms.GetRandomNumberArray(100000, 1, 1000000);
            }
            this.NumberArray = numberArray;
            this.SortType = sortType;
        }

        #endregion

        protected abstract void SetName();
        
        public string GetName()
        {
            return this.Name;
        }

        /// <summary>
        /// Starts the algorithm.
        /// </summary>
        /// <param name="printArray">Prints the number array if true.</param>
        public abstract void StartAlgorithm(bool printArray = false);

        protected abstract void AscendingSort(ref int[] copyArray);
        protected abstract void DescendingSort(ref int[] copyArray);
        protected abstract void ZigZagSort(ref int[] copyArray);

        /// <summary>
        /// Starts the algorithm without printing any Output.
        /// </summary>
        public abstract void StartAlgorithmWithoutOutput();
        
        /// <summary>
        /// Ends the algorithm and prints the elapsed time.
        /// </summary>
        /// <param name="startTime"></param>
        protected void EndAlgorithm(DateTime startTime)
        {
            DateTime endTime = DateTime.Now;

            TimeSpan elapsedTime = endTime - startTime;

            Console.WriteLine($"Beende {this.Name}...");

            Console.WriteLine($"{this.Name} brauchte: {elapsedTime.ToString()}");
        }
        
        /// <summary>
        /// Returns the unsorted number array.
        /// </summary>
        /// <returns>Number array.</returns>
        public int[] GetNumberArray()
        {
            return this.NumberArray;
        }
        
        /// <summary>
        /// Returns the sorted number array.
        /// </summary>
        /// <returns>Sorted number array.</returns>
        public int[] GetSortedNumberArray()
        {
            return this.SortedNumberArray;
        }
        
        /// <summary>
        /// Sets the number array.
        /// </summary>
        /// <param name="numberArray">Number array.</param>
        public void SetNumberArray(int[] numberArray)
        {
            this.NumberArray = numberArray;
        }
        
        /// <summary>
        /// Creates a random number array.
        /// </summary>
        /// <param name="numberOfEntries">Number of entries.</param>
        /// <param name="min">Minimum number.</param>
        /// <param name="max">Maximum number.</param>
        private void CreateRandomNumberArray(int numberOfEntries, int min, int max)
        {
            this.NumberArray = new int[numberOfEntries];

            Random randomNumber = new Random();

            for (int i = 0; i < numberOfEntries; i++)
            {
                this.NumberArray[i] = randomNumber.Next(min, max);
            }
        }
        
        /// <summary>
        /// Checks if the number array is sorted.
        /// </summary>
        /// <param name="array">Number array.</param>
        /// <returns>True if sorted, false if not.</returns>
        protected static bool IsAscendingSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        protected static bool IsDescendingSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        protected static bool IsZigZagSorted(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    switch (i % 2)
                    {
                        case 0 when array[i] > array[j]:
                            return false;
                        case 0:
                            continue;
                        case 1 when array[i] < array[j]:
                            return false;
                    }
                }
            }
            
            return true;
        }
        
        /// <summary>
        /// Prints the number array.
        /// </summary>
        /// <param name="numberArray">Number array.</param>
        protected static void PrintNumberArray(int[] numberArray)
        {
            Console.WriteLine("Number Array:");

            foreach (int number in numberArray)
            {
                Console.Write($"{number.ToString()} ");
            }

            Console.Write("\n");
        }

        /// <summary>
        /// Creates a random number array.
        /// </summary>
        /// <param name="numberOfEntries">Number of entries.</param>
        /// <param name="min">Minimum number.</param>
        /// <param name="max">Maximum number.</param>
        /// <returns>Random number array.</returns>
        public static int[] GetRandomNumberArray(int numberOfEntries, int min, int max)
        {
            int[] numberArray = new int[numberOfEntries];

            Random randomNumber = new Random();

            for (int i = 0; i < numberOfEntries; i++)
            {
                numberArray[i] = randomNumber.Next(min, max);
            }

            return numberArray;
        }
    }
}