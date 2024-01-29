using System;

namespace Sortier_Algorithmen.Algorithmen
{
    public sealed class BubbleSort : Algorithms
    {
        #region Constructor

        public BubbleSort(ESort sortType = ESort.Ascending) : base(sortType)
        {
            this.SetName();
        }

        public BubbleSort(int arrayLength, int minNumber, int maxNumber, ESort sortType = ESort.Ascending) : base(arrayLength, minNumber, maxNumber,sortType)
        {
            this.SetName();
        }

        public BubbleSort(int[] numberArray, ESort sortType = ESort.Ascending) : base(numberArray, sortType)
        {
            this.SetName();
        }

        #endregion

        protected override void SetName()
        {
            this.Name = "BubbleSort";
        }

        public override void StartAlgorithm(bool printArray = false)
        {
            Console.WriteLine($"Starte {this.Name}...");

            int[] copyArray = (int[])this.NumberArray.Clone();

            System.DateTime startTime = System.DateTime.Now;

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
                System.Console.WriteLine();
                System.Console.Write("Unsorted Array: ");
                PrintNumberArray(this.NumberArray);
                System.Console.Write("Sorted Array: ");
                PrintNumberArray(copyArray);
            }
            
            System.Console.WriteLine("----------------------------------------");
        }

        protected override void AscendingSort(ref int[] copyArray)
        {
            while (!IsAscendingSorted(copyArray))
            {
                for (int i = 0; i < copyArray.Length - 1; i++)
                {
                    if (copyArray[i] > copyArray[i + 1])
                    {
                        (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
                    }
                }
            }
        }

        protected override void DescendingSort(ref int[] copyArray)
        {
            while (!IsDescendingSorted(copyArray))
            {
                for (int i = 0; i < copyArray.Length - 1; i++)
                {
                    if (copyArray[i] < copyArray[i + 1])
                    {
                        (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
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

            while (!IsAscendingSorted(copyArray))
            {
                for (int i = 0; i < copyArray.Length; i++)
                {
                    if (copyArray[i] > copyArray[i + 1])
                    {
                        (copyArray[i], copyArray[i + 1]) = (copyArray[i + 1], copyArray[i]);
                    }
                }
            }
            
            this.SortedNumberArray = copyArray;
        }
    }
}