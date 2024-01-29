using System;

namespace Sortier_Algorithmen.Algorithmen
{
    public sealed class GnomeSort : Algorithms
    {
        #region Constructor

        public GnomeSort(ESort sortType = ESort.Ascending) : base(sortType)
        {
            this.SetName();
        }

        public GnomeSort(int arrayLength, int minNumber, int maxNumber, ESort sortType = ESort.Ascending) : base(arrayLength, minNumber, maxNumber, sortType)
        {
            this.SetName();
        }

        public GnomeSort(int[] numberArray, ESort sortType = ESort.Ascending) : base(numberArray, sortType)
        {
            this.SetName();
        }

        #endregion

        protected override void SetName()
        {
            this.Name = "GnomeSort";
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
            int index = 0;
            
            while (index < copyArray.Length)
            {
                if (index == 0) index++;

                if (copyArray[index] >= copyArray[index - 1]) index++;
                else
                {
                    (copyArray[index], copyArray[index - 1]) = (copyArray[index - 1], copyArray[index]);
                    index--;
                }
            }
        }

        protected override void DescendingSort(ref int[] copyArray)
        {
            int index = 0;
            
            while (index < copyArray.Length)
            {
                if (index == 0) index++;

                if (copyArray[index] <= copyArray[index - 1]) index++;
                else
                {
                    (copyArray[index], copyArray[index - 1]) = (copyArray[index - 1], copyArray[index]);
                    index--;
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

            int index = 0;

            while (index < copyArray.Length)
            {
                if (index == 0) index++;

                if (copyArray[index] >= copyArray[index - 1]) index++;
                else
                {
                    (copyArray[index], copyArray[index - 1]) = (copyArray[index - 1], copyArray[index]);
                    index--;
                }
            }
            
            this.SortedNumberArray = copyArray;
        }
    }
}