using System;

namespace Sortier_Algorithmen.Algorithmen
{
    public sealed class CocktailSort : Algorithms
    {
        #region Constructor

        public CocktailSort(ESort sortType = ESort.Ascending) : base(sortType)
        {
            this.SetName();
        }

        public CocktailSort(int arrayLength, int minNumber, int maxNumber, ESort sortType = ESort.Ascending) : base(arrayLength, minNumber, maxNumber, sortType)
        {
            this.SetName();
        }

        public CocktailSort(int[] numberArray, ESort sortType = ESort.Ascending) : base(numberArray, sortType)
        {
            this.SetName();
        }

        #endregion

        protected override void SetName()
        {
            this.Name = "CocktailSort";
        }

        public override void StartAlgorithm(bool printArray = false)
        {
            Console.WriteLine($"Starte {this.Name}...");

            int[] copyArray = (int[])this.NumberArray.Clone();
            
            DateTime startTime = DateTime.Now;

            switch (this.SortType)
            {
                case ESort.Ascending:
                    AscendingSort(ref copyArray);
                    break;
                case ESort.Descending:
                    DescendingSort(ref copyArray);
                    break;
                case ESort.ZigZag:
                    ZigZagSort(ref copyArray);
                    break;
            }
            
            this.EndAlgorithm(startTime);
            
            this.SortedNumberArray = copyArray;
            
            if (printArray)
            {
                Console.WriteLine();
                Console.Write("Unsorted Array: ");
                PrintNumberArray(this.NumberArray);
                Console.Write("Sorted Array: ");
                PrintNumberArray(copyArray);
            }

            Console.WriteLine("----------------------------------------");
        }

        protected override void AscendingSort(ref int[] copyArray)
        {
            bool swapped = true;
            int start = 0;
            int end = copyArray.Length - 1;
            
            while (swapped)
            {
                // Forward
                swapped = false;

                for (int i = start; i < end; ++i)
                {
                    if (copyArray[i] <= copyArray[i + 1]) continue;
                    (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
                    swapped = true;
                }
                
                if (!swapped)
                    break;

                // Backward
                swapped = false;
                end--;

                for (int i = end - 1; i >= start; --i)
                {
                    if (copyArray[i] <= copyArray[i + 1]) continue;
                    (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
                    swapped = true;
                }

                start++;
            }
        }

        protected override void DescendingSort(ref int[] copyArray)
        {
            bool swapped = true;
            int start = 0;
            int end = copyArray.Length - 1;
            
            while (swapped)
            {
                // Forward
                swapped = false;

                for (int i = start; i < end; ++i)
                {
                    if (copyArray[i] >= copyArray[i + 1]) continue;
                    (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
                    swapped = true;
                }

                if (!swapped)
                    break;

                // Backward
                swapped = false;
                end--;

                for (int i = end - 1; i >= start; --i)
                {
                    if (copyArray[i] >= copyArray[i + 1]) continue;
                    (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
                    swapped = true;
                }

                start++;
            }
        }

        protected override void ZigZagSort(ref int[] copyArray)
        {
            AscendingSort(ref copyArray);
            
            int j = 1;
            
            while (!IsZigZagSorted(copyArray))
            {
                for (int i = copyArray.Length - 1; j  != copyArray.Length - 1; i--)
                {
                    if (i <= j)
                    {
                        break;
                    }
                    (copyArray[i], copyArray[i - 1]) = (copyArray[i - 1], copyArray[i]);
                }
                
                j += 2;
            }
        }

        public override void StartAlgorithmWithoutOutput()
        {
            int[] copyArray = (int[])this.NumberArray.Clone();

            bool swapped = true;
            int start = 0;
            int end = copyArray.Length;

            while (swapped)
            {
                // Forward
                swapped = false;

                for (int i = start; i < end; ++i)
                {
                    if (copyArray[i] <= copyArray[i + 1]) continue;
                    (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
                    swapped = true;
                }
                
                if (!swapped)
                    break;

                // Backward
                swapped = false;
                end--;

                for (int i = end - 1; i >= start; --i)
                {
                    if (copyArray[i] <= copyArray[i + 1]) continue;
                    (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
                    swapped = true;
                }

                start++;
            }
            
            this.SortedNumberArray = copyArray;
        }
    }
}