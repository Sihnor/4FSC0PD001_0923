using System;
using System.Collections.Generic;
using Sortier_Algorithmen.Algorithmen;

namespace Sortier_Algorithmen
{
    public class SortTests
    {
        private readonly int[][] UnsortedTestArrays = new int[][]
        {
            new int[] {42, 18, 7, 91, 30, 5, 76, 23, 15, 88, 42, 64, 29, 11, 50},
            new int[] {65, 23, 47, 12, 84, 6, 33, 78, 51, 19, 92, 13, 55, 27, 70},
            new int[] {56, 29, 14, 68, 37, 2, 45, 89, 22, 60, 38, 77, 49, 16, 73},
            new int[] {9, 82, 53, 20, 75, 44, 3, 67, 31, 58, 26, 12, 94, 21, 41},
            new int[] {34, 61, 25, 46, 10, 79, 8, 52, 94, 17, 63, 39, 85, 72, 24}
        };
        private readonly int[][] SortedTestArrays = new int[][]
        {
            new int[] {5, 7, 11, 15, 18, 23, 29, 30, 42, 42, 50, 64, 76, 88, 91},
            new int[] {6, 12, 13, 19, 23, 27, 33, 47, 51, 55, 65, 70, 78, 84, 92},
            new int[] {2, 14, 16, 22, 29, 37, 38, 45, 49, 56, 60, 68, 73, 77, 89},
            new int[] {3, 9, 12, 20, 21, 26, 31, 41, 44, 53, 58, 67, 75, 82, 94},
            new int[] {8, 10, 17, 24, 25, 34, 39, 46, 52, 61, 63, 72, 79, 85, 94}
        };

        private readonly List<Algorithms> AlgorithmsArray = new List<Algorithms>();
        private readonly List<Type> ClassList = new List<Type>();

        /// <summary>
        /// Adds the algorithm.
        /// </summary>
        /// <param name="algorithms"></param>
        public void AddAlgorithm(Algorithms algorithms)
        {
            this.AlgorithmsArray.Add(algorithms);
        }
        
        /// <summary>
        /// Starts the tests.
        /// </summary>
        public void StartTests()
        {
            foreach (Algorithms algorithm in this.AlgorithmsArray)
            {
                Console.WriteLine($"Teste {algorithm.GetName()}...");
                
                for (int i = 0; i < this.UnsortedTestArrays.Length; i++)
                {
                    algorithm.SetNumberArray(this.UnsortedTestArrays[i]);
                    algorithm.StartAlgorithmWithoutOutput();

                    if (IsEqual(this.SortedTestArrays[i], algorithm.GetSortedNumberArray()))
                    {
                        Console.Write($"Test {i + 1} von {algorithm.GetName()} war");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" erfolgreich!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"Test {i + 1} von {algorithm.GetName()} war");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" nicht erfolgreich!");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine($"Alle Tests für {algorithm.GetName()} wurden durchgeführt!");
                Console.WriteLine();
            }
            
            
        }
        
        /// <summary>
        /// Checks if both are equal.
        /// </summary>
        /// <param name="array1">Sorted array</param>
        /// <param name="array2">Test array</param>
        /// <returns></returns>
        private bool IsEqual(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length) return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }

            return true;
        }
        
        /// <summary>
        /// Adds the algorithm class.
        /// </summary>
        /// <param name="type">Class type</param>
        public void AddAlgorithmClass(Type type)
        {
            if (!(typeof(Algorithms).IsAssignableFrom(type))) return;
            
            this.ClassList.Add(type);
        }

        /// <summary>
        /// Starts the class test.
        /// </summary>
        public void StartClassTest()
        {
            this.AlgorithmsArray.Clear();
            
            foreach (Type type in this.ClassList)
            {
                this.AlgorithmsArray.Add((Algorithms)Activator.CreateInstance(type));
            }
            
            StartTests();
        }
    }
}