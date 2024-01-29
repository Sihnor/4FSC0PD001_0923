using System;

namespace Vector_Mathematik
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Verwende den Standardkonstruktor
            Vector vector1 = new Vector();
            Console.WriteLine($"Vector 1: {vector1.ToOwnString()}");

            // Verwende den Konstruktor mit benutzerdefinierten Koordinaten
            Vector vector2 = new Vector(1.0f, 2.0f, 3.0f);
            Console.WriteLine($"Vector 2: {vector2.ToOwnString()}");

            // Verwende den Konstruktor zum Kopieren von Werten aus einem anderen Vektor
            Vector vector3 = new Vector(vector2);
            Console.WriteLine($"Vector 3 (copied from Vector 2): {vector3.ToOwnString()}");

            // Beispiel für die Verwendung von Funktionen
            Console.WriteLine($"Length of Vector 2: {vector1.GetVectorLenght()}");
            Console.WriteLine($"Length of Vector 2: {vector2.GetVectorLenght()}");
            Console.WriteLine($"Length of Vector 2: {vector3.GetVectorLenght()}");

            Console.WriteLine($"Length of Vector 2: {Vector.GetVectorLenght(vector1)}");
            Console.WriteLine($"Length of Vector 2: {Vector.GetVectorLenght(vector2)}");
            Console.WriteLine($"Length of Vector 2: {Vector.GetVectorLenght(vector3)}");

            Console.WriteLine($"Euclidean distance between Vector 1 and Vector 2: {vector1.GetEuclideanDistance(vector2)}");
            Console.WriteLine($"Euclidean distance between Vector 1 and Vector 3: {vector1.GetEuclideanDistance(vector3)}");
            Console.WriteLine($"Euclidean distance between Vector 2 and Vector 3: {vector2.GetEuclideanDistance(vector3)}");

            Console.WriteLine($"Euclidean distance between Vector 1 and Vector 2: {Vector.GetEuclideanDistance(vector1, vector2)}");
            Console.WriteLine($"Euclidean distance between Vector 1 and Vector 3: {Vector.GetEuclideanDistance(vector1, vector3)}");
            Console.WriteLine($"Euclidean distance between Vector 2 and Vector 3: {Vector.GetEuclideanDistance(vector2, vector3)}");

            Console.WriteLine($"Vector between Vector 1 and Vector 2: {vector1.GetVectorBetweenVectors(vector2).ToOwnString()}");
            Console.WriteLine($"Vector between Vector 1 and Vector 3: {vector1.GetVectorBetweenVectors(vector3).ToOwnString()}");
            Console.WriteLine($"Vector between Vector 2 and Vector 3: {vector2.GetVectorBetweenVectors(vector3).ToOwnString()}");

            Console.WriteLine($"Vector between Vector 1 and Vector 2: {Vector.GetVectorBetweenVectors(vector1, vector2).ToOwnString()}");
            Console.WriteLine($"Vector between Vector 1 and Vector 3: {Vector.GetVectorBetweenVectors(vector1, vector3).ToOwnString()}");
            Console.WriteLine($"Vector between Vector 2 and Vector 3: {Vector.GetVectorBetweenVectors(vector2, vector3).ToOwnString()}");

            Console.WriteLine($"Calculate Own SquareLength of Vector 1: {vector1.CalculateOwnSquareLength()}");
            Console.WriteLine($"Calculate Own SquareLength of Vector 2: {vector2.CalculateOwnSquareLength()}");
            Console.WriteLine($"Calculate Own SquareLength of Vector 3: {vector3.CalculateOwnSquareLength()}");

            Console.WriteLine($"Calculate Own SquareLength of Vector 1: {Vector.CalculateSquareLength(vector1)}");
            Console.WriteLine($"Calculate Own SquareLength of Vector 2: {Vector.CalculateSquareLength(vector2)}");
            Console.WriteLine($"Calculate Own SquareLength of Vector 3: {Vector.CalculateSquareLength(vector3)}");

            // Console.WriteLine($"Normalize Vector 1: {vector1.Normalize()}"); // NOT POSSIBLE BECAUSE OF ZERO VECTOR
            Console.WriteLine($"Normalize Vector 2: {vector2.Normalize().ToOwnString()}");
            Console.WriteLine($"Normalize Vector 3: {vector3.Normalize().ToOwnString()}");

            // Console.WriteLine($"Normalize Vector 1: {Vector.Normalize(vector1)}"); // NOT POSSIBLE BECAUSE OF ZERO VECTOR
            Console.WriteLine($"Normalize Vector 2: {Vector.Normalize(vector2).ToOwnString()}");
            Console.WriteLine($"Normalize Vector 3: {Vector.Normalize(vector3).ToOwnString()}");

            Console.WriteLine($"Vector 1 + Vector 2: {(vector1 + vector2).ToOwnString()}");
            Console.WriteLine($"Vector 1 + Vector 3: {(vector1 + vector3).ToOwnString()}");
            Console.WriteLine($"Vector 2 + Vector 3: {(vector2 + vector3).ToOwnString()}");

            Console.WriteLine($"Vector 1 - Vector 2: {(vector1 - vector2).ToOwnString()}");
            Console.WriteLine($"Vector 1 - Vector 3: {(vector1 - vector3).ToOwnString()}");
            Console.WriteLine($"Vector 2 - Vector 3: {(vector2 - vector3).ToOwnString()}");

            Console.WriteLine($"Vector 1 * scalar: {vector1 * 2}");
            Console.WriteLine($"Vector 1 * scalar: {vector1 * 2}");
            Console.WriteLine($"Vector 2 * scalar: {vector2 * 2}");

            Console.WriteLine($"Vector 1 and Vector 2 are equal: {vector1 == vector2}");
            Console.WriteLine($"Vector 1 and Vector 2 are not equal: {vector1 != vector2}");
            Console.WriteLine($"Vector 2 and Vector 3 are equal: {vector2 == vector3}");
            Console.WriteLine($"Vector 2 and Vector 3 are not equal: {vector2 != vector3}");

            Console.WriteLine($"Calculate Manhatten Distance between Vector 1 and Vector 2: {vector1.GetManhattenDistance(vector2)}");
            Console.WriteLine($"Calculate Manhatten Distance between Vector 1 and Vector 3: {vector1.GetManhattenDistance(vector3)}");
            Console.WriteLine($"Calculate Manhatten Distance between Vector 2 and Vector 3: {vector2.GetManhattenDistance(vector3)}");

            Console.WriteLine($"Calculate Manhatten Distance between Vector 1 and Vector 2: {Vector.GetManhattenDistance(vector1, vector2)}");
            Console.WriteLine($"Calculate Manhatten Distance between Vector 1 and Vector 3: {Vector.GetManhattenDistance(vector1, vector3)}");
            Console.WriteLine($"Calculate Manhatten Distance between Vector 2 and Vector 3: {Vector.GetManhattenDistance(vector2, vector3)}");

            Console.WriteLine($"Calculate Scalar Product between Vector 1 and Vector 2: {vector1.SkalarProdukt(vector2).ToString()}");
            Console.WriteLine($"Calculate Scalar Product between Vector 1 and Vector 3: {vector1.SkalarProdukt(vector3).ToString()}");
            Console.WriteLine($"Calculate Scalar Product between Vector 2 and Vector 3: {vector2.SkalarProdukt(vector3).ToString()}");

            Console.WriteLine($"Calculate Scalar Product between Vector 1 and Vector 2: {Vector.SkalarProdukt(vector1, vector2).ToString()}");
            Console.WriteLine($"Calculate Scalar Product between Vector 1 and Vector 3: {Vector.SkalarProdukt(vector1, vector3).ToString()}");
            Console.WriteLine($"Calculate Scalar Product between Vector 2 and Vector 3: {Vector.SkalarProdukt(vector2, vector3).ToString()}");

            Console.WriteLine($"Calculate Kreuzprodukt between Vector 1 and Vector 2: {vector1.Kreuzprodukt(vector2).ToOwnString()}"); // Nicht moeglich weil keine unterschiedlichen
            Console.WriteLine($"Calculate Kreuzprodukt between Vector 1 and Vector 3: {vector1.Kreuzprodukt(vector3).ToOwnString()}"); // Nicht moeglich weil keine unterschiedlichen
            Console.WriteLine($"Calculate Kreuzprodukt between Vector 2 and Vector 3: {vector2.Kreuzprodukt(vector3).ToOwnString()}"); // Nicht moeglich weil keine unterschiedlichen

            Console.WriteLine($"Calculate Kreuzprodukt between Vector 1 and Vector 2: {Vector.Kreuzprodukt(vector1, vector2).ToOwnString()}");
            Console.WriteLine($"Calculate Kreuzprodukt between Vector 1 and Vector 3: {Vector.Kreuzprodukt(vector1, vector3).ToOwnString()}"); // Nicht moeglich weil kein Unterschied
            Console.WriteLine($"Calculate Kreuzprodukt between Vector 2 and Vector 3: {Vector.Kreuzprodukt(vector2, vector3).ToOwnString()}"); // Nicht moeglich weil kein Unterschied
            Console.WriteLine($"Calculate Kreuzprodukt: {Vector.Kreuzprodukt(new Vector(1, 0, 0), new Vector(0, 1, 0)).ToOwnString()}");

            Console.WriteLine($"Convert to string Vector 1: {vector1.ToOwnString()}");
            Console.WriteLine($"Convert to string Vector 2: {vector2.ToOwnString()}");
            Console.WriteLine($"Convert to string Vector 3: {vector3.ToOwnString()}");

            Console.WriteLine($"Convert to string Vector 1: {Vector.ToOwnString(vector1)}");
            Console.WriteLine($"Convert to string Vector 2: {Vector.ToOwnString(vector2)}");
            Console.WriteLine($"Convert to string Vector 3: {Vector.ToOwnString(vector3)}");

            Console.WriteLine("Enumarte Vector 2:");

            foreach (float Coordinate in vector2)
            {
                Console.WriteLine($"Coordinate: {Coordinate}");
            }
        }
    }
}