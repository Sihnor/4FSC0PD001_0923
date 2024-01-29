using System;

namespace Sortier_Algorithmen.Algorithmen
{
    public sealed class CombSort : Algorithms
    {
        #region Constructor

        public CombSort(ESort sortType = ESort.Ascending) : base(sortType)
        {
            this.SetName();
        }

        public CombSort(int arrayLength, int minNumber, int maxNumber, ESort sortType = ESort.Ascending) : base(arrayLength, minNumber, maxNumber, sortType)
        {
            this.SetName();
        }

        public CombSort(int[] numberArray, ESort sortType = ESort.Ascending) : base(numberArray, sortType)
        {
            this.SetName();
        }

        #endregion

        protected override void SetName()
        {
            this.Name = "CombSort";
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
            int gap = copyArray.Length;
            const double shrinkFactor = 1.3;
            bool swapped = true;
            
            while (gap > 1 || swapped)
            {
                gap = (int)(gap / shrinkFactor);
                gap = Math.Max(1, gap);

                swapped = false;

                for (int i = 0; i < copyArray.Length - gap; i++)
                {
                    if (copyArray[i] <= copyArray[i + gap]) continue;
                    (copyArray[i], copyArray[i + gap]) = (copyArray[i + gap], copyArray[i]);
                    swapped = true;
                }
            }
        }

        protected override void DescendingSort(ref int[] copyArray)
        {
            int gap = copyArray.Length;
            const double shrinkFactor = 1.3;
            bool swapped = true;
            
            while (gap > 1 || swapped)
            {
                gap = (int)(gap / shrinkFactor);
                gap = Math.Max(1, gap);

                swapped = false;

                for (int i = 0; i < copyArray.Length - gap; i++)
                {
                    if (copyArray[i] < copyArray[i + gap])
                    {
                        (copyArray[i], copyArray[i + gap]) = (copyArray[i + gap], copyArray[i]);
                        swapped = true;
                    }
                }
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
            
            int gap = copyArray.Length;
            const double shrinkFactor = 1.3;
            bool swapped = true;

            while (gap > 1 || swapped)
            {
                gap = (int)(gap / shrinkFactor);
                gap = Math.Max(1, gap);

                swapped = false;

                for (int i = 0; i < copyArray.Length - gap; i++)
                {
                    if (copyArray[i] <= copyArray[i + gap]) continue;
                    (copyArray[i], copyArray[i + gap]) = (copyArray[i + gap], copyArray[i]);
                    swapped = true;
                }
            }
            
            this.SortedNumberArray = copyArray;
        }
    }
}