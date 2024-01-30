using System;

namespace Sortier_Algorithmen.Algorithmen
{
    public sealed class BogoSort : Algorithms
    {
        #region Constructor

        public BogoSort(ESort sortType = ESort.Ascending) : base(sortType)
        {
            this.SetName();
        }

        public BogoSort(int arrayLength, int minNumber, int maxNumber, ESort sortType = ESort.Ascending) : base(arrayLength, minNumber, maxNumber, sortType)
        {
            SetName();
        }

        public BogoSort(int[] numberArray, ESort sortType = ESort.Ascending) : base(numberArray, sortType)
        {
            SetName();
        }

        #endregion

        protected override void SetName()
        {
            this.Name = "BogoSort";
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
                Console.Write("Unsorted Array: ");
                PrintNumberArray(this.NumberArray);
                Console.Write("Sorted Array: ");
                PrintNumberArray(copyArray);
            }
            
            Console.WriteLine("----------------------------------------");
        }
        
        protected override void AscendingSort(ref int[] copyArray)
        {
            Random randomNumber = new Random();
            
            while (!IsAscendingSorted(copyArray))
            {
                for (int i = 0; i < copyArray.Length; i++)
                {
                    int randomIndex = randomNumber.Next(i, copyArray.Length);

                    (copyArray[randomIndex], copyArray[i]) = (copyArray[i], copyArray[randomIndex]);
                }
            }
        }

        protected override void DescendingSort(ref int[] copyArray)
        {
            Random randomNumber = new Random();
            
            while (!IsDescendingSorted(copyArray))
            {
                for (int i = 0; i < copyArray.Length; i++)
                {
                    int randomIndex = randomNumber.Next(i, copyArray.Length);

                    (copyArray[randomIndex], copyArray[i]) = (copyArray[i], copyArray[randomIndex]);
                }
            }
        }

        protected override void ZigZagSort(ref int[] copyArray)
        {
            Random randomNumber = new Random();
            
            while (!IsZigZagSorted(copyArray))
            {
                for (int i = 0; i < copyArray.Length; i++)
                {
                    int randomIndex = randomNumber.Next(i, copyArray.Length);

                    (copyArray[randomIndex], copyArray[i]) = (copyArray[i], copyArray[randomIndex]);
                }
            }
        }

        public override void StartAlgorithmWithoutOutput()
        {
            int[] copyArray = (int[])this.NumberArray.Clone();

            Random randomNumber = new Random();

            while (!IsAscendingSorted(copyArray))
            {
                for (int i = 0; i < copyArray.Length; i++)
                {
                    int randomIndex = randomNumber.Next(i, copyArray.Length);

                    (copyArray[randomIndex], copyArray[i]) = (copyArray[i], copyArray[randomIndex]);
                }
            }
            
            this.SortedNumberArray = copyArray;
        }
    }
}