using System;
using Sortier_Algorithmen.Algorithmen;

namespace Sortier_Algorithmen
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool PLEASE_SELECT_PATH = true;

            // moegliche Zahlen Reihenfolgen:
            // 12, 5, -7, 0, 23, -10, 42, 8, -3, 17, 31, q, 6, 19, -22

            if (PLEASE_SELECT_PATH)
            {
                ModulePath();
            }
            else
            {
                OwnPath();
            }
        }

        private static void ModulePath()
        {
            int[] numberArray = SelectArrayGenerator();
            bool printArray = SelectPrintArray(numberArray);
            Algorithms.ESort sortType = SelectSortType();
            Algorithms.EAlgorithm algorithm = SelectAlgorithm();

            Console.Clear();
            
            switch (algorithm)
            {
                case Algorithms.EAlgorithm.BogoSort:
                    BogoSort bogoSort = new BogoSort(numberArray, sortType);
                    bogoSort.StartAlgorithm(printArray);
                    break;
                case Algorithms.EAlgorithm.BubbleSort:
                    BubbleSort bubbleSort = new BubbleSort(numberArray, sortType);
                    bubbleSort.StartAlgorithm(printArray);
                    break;
                case Algorithms.EAlgorithm.CocktailSort:
                    CocktailSort cocktailSort = new CocktailSort(numberArray, sortType);
                    cocktailSort.StartAlgorithm(printArray);
                    break;
                case Algorithms.EAlgorithm.CombSort:
                    CombSort combSort = new CombSort(numberArray, sortType);
                    combSort.StartAlgorithm(printArray);
                    break;
                case Algorithms.EAlgorithm.GnomeSort:
                    GnomeSort gnomeSort = new GnomeSort(numberArray, sortType);
                    gnomeSort.StartAlgorithm(printArray);
                    break;
                case Algorithms.EAlgorithm.All:
                    //bogoSort = new BogoSort(numberArray, sortType);
                    bubbleSort = new BubbleSort(numberArray, sortType);
                    cocktailSort = new CocktailSort(numberArray, sortType);
                    combSort = new CombSort(numberArray, sortType);
                    gnomeSort = new GnomeSort(numberArray, sortType);

                    //bogoSort.StartAlgorithm(printArray);
                    bubbleSort.StartAlgorithm(printArray);
                    cocktailSort.StartAlgorithm(printArray);
                    combSort.StartAlgorithm(printArray);
                    gnomeSort.StartAlgorithm(printArray);
                    break;
                case Algorithms.EAlgorithm.None:
                    WrongInputExit();
                    break;
            }
        }

        private static void OwnPath()
        {
            int[] ownArray = new int[0];
            string input;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Möchtest du die Algorithmen testen oder benchmarken?");
                Console.WriteLine("[0]: Eigene Zahlen eingeben (Geht nur fürs Benchmarken)");
                Console.WriteLine("[1]: Benchmark");
                Console.WriteLine("[2]: Test1 mit Instancen der Algorithmen");
                Console.WriteLine("[3]: Test2 mit Klassen der Algorithmen");
                Console.WriteLine("[4]: Beenden");
                Console.Write("Eingabe: ");
                input = Console.ReadLine().Trim();

                if (input == "0") ownArray = SelectArrayGenerator();
                else break;
            }

            switch (input)
            {
                case "1":
                    if (ownArray.Length != 0) StartBenchmark(ownArray);
                    else StartBenchmark();
                    break;
                case "2":
                    StartTest1();
                    break;
                case "3":
                    StartTest2();
                    break;
                case "4":
                    Console.WriteLine("Programm wird beendet...");
                    Environment.Exit(0);
                    break;
                default:
                    WrongInputExit();
                    break;
            }
        }

        private static int[] SelectArrayGenerator()
        {
            Console.Clear();
            Console.WriteLine("[0] Möchtest du die Werte des Arrays selbst bestimmen?");
            Console.WriteLine("[1] Möchtest du die Generierung des Arrays selbst bestimmen?");
            Console.WriteLine("[2] Möchtest du die Generierung des Arrays dem Programm überlassen? (Nicht zum Benchmarken geeignet!)");
            Console.Write("Eingabe: ");
            string input = Console.ReadLine().Trim();

            switch (input)
            {
                case "0":
                    return CreateOwnArray();
                case "1":
                    return GenerateOwnArray();
                case "2":
                    break;
                default:
                    WrongInputExit();
                    break;
            }

            return null;
        }

        private static int[] CreateOwnArray()
        {
            Console.Clear();
            Console.WriteLine("Bitte gib die Zahlen Reihenfolge wie folgt ein: 567,345,126,-235,0,712");
            Console.Write("Eingabe: ");
            string input = Console.ReadLine().Trim();

            string[] inputArray = input.Split(',');
            int[] numberArray = new int[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                int.TryParse(inputArray[i], out numberArray[i]);
            }

            return numberArray;
        }

        private static int[] GenerateOwnArray()
        {
            Console.Clear();
            Console.WriteLine("Wie gross soll das Array werden: (Empfehlung: 100000)");
            Console.Write("Eingabe: ");
            string input = Console.ReadLine().Trim();

            int numberOfEntries;

            if (!int.TryParse(input, out numberOfEntries))
            {
                WrongInputExit();
            }

            Console.Clear();
            Console.WriteLine("Wie gross soll die kleinste Zahl sein: (Empfehlung: -18924)");
            Console.Write("Eingabe: ");
            input = Console.ReadLine().Trim();

            int min;

            if (!int.TryParse(input, out min))
            {
                WrongInputExit();
            }

            Console.Clear();
            Console.WriteLine("Wie gross soll die grösste Zahl sein: (Empfehlung: 1000000)");
            Console.Write("Eingabe: ");
            input = Console.ReadLine().Trim();

            int max;

            if (!int.TryParse(input, out max))
            {
                WrongInputExit();
            }

            return Algorithms.GetRandomNumberArray(numberOfEntries, min, max);
        }
        
        private static bool SelectPrintArray(int[] array)
        {
            Console.Clear();
            Console.WriteLine("Möchtest du die Zahlen beim loesen ausgeben lassen? (Wenn mehr als 25 Zahlen, dann wird das Array nicht ausgegeben)");
            Console.WriteLine("[0]: Nein");
            Console.WriteLine("[1]: Ja");
            Console.Write("Eingabe: ");
            string input = Console.ReadLine().Trim();

            if (array.Length > 25) return false;

            switch (input)
            {
                case "0":
                    return false;
                case "1":
                    return true;
                default:
                    WrongInputExit();
                    break;
            }

            return false;
        }

        private static Algorithms.ESort SelectSortType()
        {
            Console.Clear();
            Console.WriteLine("Wie möchtest du das die Algorithmen sortiert werden?");
            Console.WriteLine("[0] Aufsteigend");
            Console.WriteLine("[1] Absteigend");
            Console.WriteLine("[2] ZigZag");
            Console.WriteLine("Eingabe: ");
            string input = Console.ReadLine().Trim();

            int sortNumber;

            if (!int.TryParse(input, out sortNumber))
            {
                WrongInputExit();
            }

            return (Algorithms.ESort)sortNumber;
        }

        private static Algorithms.EAlgorithm SelectAlgorithm()
        {
            Console.Clear();
            Console.WriteLine("Welchen Algorithmus möchtest du testen?");
            Console.WriteLine("[0] BogoSort");
            Console.WriteLine("[1] BubbleSort");
            Console.WriteLine("[2] CocktailSort");
            Console.WriteLine("[3] CombSort");
            Console.WriteLine("[4] GnomeSort");
            Console.WriteLine("[5] Alle");
            Console.Write("Eingabe: ");
            string input = Console.ReadLine().Trim();

            switch (input)
            {
                case "0":
                    return Algorithms.EAlgorithm.BogoSort;
                case "1":
                    return Algorithms.EAlgorithm.BubbleSort;
                case "2":
                    return Algorithms.EAlgorithm.CocktailSort;
                case "3":
                    return Algorithms.EAlgorithm.CombSort;
                case "4":
                    return Algorithms.EAlgorithm.GnomeSort;
                case "5":
                    return Algorithms.EAlgorithm.All;
                default:
                    return Algorithms.EAlgorithm.None;
            }
        }

        private static void StartBenchmark()
        {
            int[] testArray = Algorithms.GetRandomNumberArray(100000, 1, 1000000);

            BogoSort bogoSort = new BogoSort(testArray);
            BubbleSort bubbleSort = new BubbleSort(testArray);
            CocktailSort cocktailSort = new CocktailSort(testArray);
            CombSort combSort = new CombSort(testArray);
            GnomeSort gnomeSort = new GnomeSort(testArray);

            Console.Clear();

            Console.WriteLine("Benchmark wird gestartet...");
            // bogoSort.StartAlgorithm();
            bubbleSort.StartAlgorithm();
            cocktailSort.StartAlgorithm();
            combSort.StartAlgorithm();
            gnomeSort.StartAlgorithm();
        }

        private static void StartBenchmark(int[] ownArray)
        {
            BogoSort bogoSort = new BogoSort(ownArray);
            BubbleSort bubbleSort = new BubbleSort(ownArray);
            CocktailSort cocktailSort = new CocktailSort(ownArray);
            CombSort combSort = new CombSort(ownArray);
            GnomeSort gnomeSort = new GnomeSort(ownArray);
            
            bool printArray = SelectPrintArray(ownArray);

            Console.Clear();

            Console.WriteLine("Benchmark wird gestartet...");
            // bogoSort.StartAlgorithm();
            bubbleSort.StartAlgorithm(printArray);
            cocktailSort.StartAlgorithm(printArray);
            combSort.StartAlgorithm(printArray);
            gnomeSort.StartAlgorithm(printArray);
        }

        private static void StartTest1()
        {
            BogoSort bogoSort = new BogoSort();
            BubbleSort bubbleSort = new BubbleSort();
            CocktailSort cocktailSort = new CocktailSort();
            CombSort combSort = new CombSort();
            GnomeSort gnomeSort = new GnomeSort();

            Console.Clear();
            Console.WriteLine("Test1 wird gestartet...");
            SortTests sortTests = new SortTests();

            sortTests.AddAlgorithm(bubbleSort);
            sortTests.AddAlgorithm(cocktailSort);
            sortTests.AddAlgorithm(combSort);
            sortTests.AddAlgorithm(gnomeSort);

            sortTests.StartTests();
        }

        private static void StartTest2()
        {
            Console.Clear();
            Console.WriteLine("Test2 wird gestartet...");
            SortTests sortTests = new SortTests();

            sortTests.AddAlgorithmClass(typeof(BubbleSort));
            sortTests.AddAlgorithmClass(typeof(CocktailSort));
            sortTests.AddAlgorithmClass(typeof(CombSort));
            sortTests.AddAlgorithmClass(typeof(GnomeSort));

            sortTests.StartClassTest();
        }

        private static void WrongInputExit()
        {
            Console.WriteLine("Falsche Eingabe!");
            Console.WriteLine("Programm wird beendet...");
            Environment.Exit(0);
        }
    }
}