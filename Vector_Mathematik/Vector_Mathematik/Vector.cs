using System;
using System.Collections;
using System.Collections.Generic;


namespace Vector_Mathematik
{
    public class Vector
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Vector class with default 3D coordinates (0, 0, 0).
        /// </summary>
        public Vector()
        {
            this.XPosition = 0;
            this.YPosition = 0;
            this.ZPosition = 0;
        }
        
        /// <summary>
        /// Initializes a new instance of the Vector class with custom 3D coordinates.
        /// </summary>
        /// <param name="_StartXPosition">The initial X-coordinate of the vector.</param>
        /// <param name="_StartYPosition">The initial Y-coordinate of the vector.</param>
        /// <param name="_StartZPosition">The initial Z-coordinate of the vector.</param>
        public Vector(float _StartXPosition, float _StartYPosition, float _StartZPosition)
        {
            this.XPosition = _StartXPosition;
            this.YPosition = _StartYPosition;
            this.ZPosition = _StartZPosition;
        }

        /// <summary>
        /// Initializes a new instance of the Vector class by copying the values from another Vector.
        /// </summary>
        /// <param name="_CopyVector">The Vector to copy values from.</param>
        public Vector(Vector _CopyVector)
        {
            this.XPosition = _CopyVector.XPosition;
            this.YPosition = _CopyVector.YPosition;
            this.ZPosition = _CopyVector.ZPosition;
        }

        #endregion
        
        private float XPosition;
        private float YPosition;
        private float ZPosition;
        
        /// <summary>
        /// Calculates and returns the length (magnitude) of the vector in 3D space.
        /// </summary>
        /// <returns>The length of the vector.</returns>
        public float GetVectorLenght()
        {
            // Sqrt(X^2 + Y^2 + Z^2)
            return (float)Math.Sqrt(Math.Pow(this.XPosition, 2) + Math.Pow(this.YPosition, 2) + Math.Pow(this.ZPosition, 2));
        }

        /// <summary>
        /// Calculates and returns the length (magnitude) of the vector in 3D space.
        /// </summary>
        /// <param name="_Other">The vector to calculate the length.</param>
        /// <returns>The length of the vector.</returns>
        public static float GetVectorLenght(Vector _Other)
        {
            return (float)Math.Sqrt(Math.Pow(_Other.XPosition, 2) + Math.Pow(_Other.YPosition, 2) + Math.Pow(_Other.ZPosition, 2));
        }

        /// <summary>
        /// Calculates and returns the Euclidean distance between the current vector and another specified vector in 3D space.
        /// </summary>
        /// <param name="_Other">The vector to calculate the distance to.</param>
        /// <returns>The Euclidean distance between the two vectors.</returns>
        public float GetEuclideanDistance(Vector _Other)
        {
            return this.GetVectorBetweenVectors(_Other).GetVectorLenght();
        }

        /// <summary>
        /// Calculates and returns the Euclidean distance between two vectors in 3D space.
        /// </summary>
        /// <param name="_StartVector">The starting vector.</param>
        /// <param name="_EndVector">The ending vector.</param>
        /// <returns>The Euclidean distance between the two vectors.</returns>
        public static float GetEuclideanDistance(Vector _StartVector, Vector _EndVector)
        {
            Vector temp = GetVectorBetweenVectors(_StartVector, _EndVector);

            return Vector.GetVectorLenght(temp);
        }

        /// <summary>
        /// Calculates and returns a vector representing the difference between the current vector 
        /// and another specified vector in 3D space.
        /// </summary>
        /// <param name="_Other">The vector to calculate the difference from.</param>
        /// <returns>A new vector representing the difference between the two vectors.</returns>
        public Vector GetVectorBetweenVectors(Vector _Other)
        {
            Vector ResultVector = new Vector(
                _Other.XPosition - this.XPosition,
                _Other.YPosition - this.YPosition,
                _Other.ZPosition - this.ZPosition
            );

            return ResultVector;
        }

        /// <summary>
        /// Calculates and returns a vector representing the difference between two vectors in 3D space.
        /// </summary>
        /// <param name="_StartVector">The starting vector.</param>
        /// <param name="_EndVector">The ending vector.</param>
        /// <returns>A new vector representing the difference between the two vectors.</returns>
        public static Vector GetVectorBetweenVectors(Vector _StartVector, Vector _EndVector)
        {
            Vector ResultVector = new Vector(
                _EndVector.XPosition - _StartVector.XPosition,
                _EndVector.YPosition - _StartVector.YPosition,
                _EndVector.ZPosition - _StartVector.ZPosition
            );

            return ResultVector;
        }

        /// <summary>
        /// Calculates and returns the square of the length (magnitude) of the vector in 3D space.
        /// </summary>
        /// <returns>The square of the length of the vector.</returns>
        public float CalculateOwnSquareLength()
        {
            return (float)(Math.Pow(this.XPosition, 2) + Math.Pow(this.YPosition, 2) + Math.Pow(this.ZPosition, 2));
        }

        /// <summary>
        /// Calculates and returns the square of the length (magnitude) of a vector in 3D space.
        /// </summary>
        /// <param name="_Other">The vector for which to calculate the square of the length.</param>
        /// <returns>The square of the length of the specified vector.</returns>
        public static float CalculateSquareLength(Vector _Other)
        {
            return (float)(Math.Pow(_Other.XPosition, 2) + Math.Pow(_Other.YPosition, 2) + Math.Pow(_Other.ZPosition, 2));
        }

        /// <summary>
        /// Normalizes the vector by dividing its components by its length, ensuring it becomes a unit vector.
        /// </summary>
        /// <returns>A new vector representing the normalized form of the original vector.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the length of the vector is zero.</exception>
        public Vector Normalize()
        {
            if (this.GetVectorLenght() == 0)
            {
                throw new InvalidOperationException("Vector Lenght is 0!");
            }

            Vector temp = new Vector();

            temp.XPosition = this.XPosition / this.GetVectorLenght();
            temp.YPosition = this.YPosition / this.GetVectorLenght();
            temp.ZPosition = this.ZPosition / this.GetVectorLenght();

            return temp;
        }

        /// <summary>
        /// Normalizes the specified vector by dividing its components by its length, ensuring it becomes a unit vector.
        /// </summary>
        /// <param name="_Other">The vector to be normalized.</param>
        /// <returns>A new vector representing the normalized form of the specified vector.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the length of the specified vector is zero.</exception>
        public static Vector Normalize(Vector _Other)
        {
            if (_Other.GetVectorLenght() == 0)
            {
                throw new InvalidOperationException("Vector Lenght is 0!");
            }

            Vector temp = new Vector();

            temp.XPosition = _Other.XPosition / _Other.GetVectorLenght();
            temp.YPosition = _Other.YPosition / _Other.GetVectorLenght();
            temp.ZPosition = _Other.ZPosition / _Other.GetVectorLenght();

            return temp;
        }

        /// <summary>
        /// Overloads the addition operator to add two vectors component-wise and returns the result.
        /// </summary>
        /// <param name="_FirstVector">The first vector.</param>
        /// <param name="_SecondVector">The second vector.</param>
        /// <returns>A new vector representing the sum of the two input vectors.</returns>
        public static Vector operator +(Vector _FirstVector, Vector _SecondVector)
        {
            Vector ResultVector = new Vector(
                _FirstVector.XPosition + _SecondVector.XPosition,
                _FirstVector.YPosition + _SecondVector.YPosition,
                _FirstVector.ZPosition + _SecondVector.ZPosition);
            return ResultVector;
        }

        /// <summary>
        /// Overloads the subtraction operator to subtract the components of the second vector from the corresponding components of the first vector.
        /// </summary>
        /// <param name="_FirstVector">The minuend vector.</param>
        /// <param name="_SecondVector">The subtrahend vector.</param>
        /// <returns>A new vector representing the result of subtracting the second vector from the first vector.</returns>
        public static Vector operator -(Vector _FirstVector, Vector _SecondVector)
        {
            Vector ResultVector = new Vector(
                _FirstVector.XPosition - _SecondVector.XPosition,
                _FirstVector.YPosition - _SecondVector.YPosition,
                _FirstVector.ZPosition - _SecondVector.ZPosition);
            return ResultVector;
        }

        /// <summary>
        /// Overloads the multiplication operator to multiply each component of the vector by a scalar value.
        /// </summary>
        /// <param name="_FirstVector">The vector to be multiplied.</param>
        /// <param name="_Scalar">The scalar value by which to multiply each component of the vector.</param>
        /// <returns>A new vector representing the result of multiplying each component of the input vector by the scalar value.</returns>
        public static Vector operator *(Vector _FirstVector, float _Scalar)
        {
            Vector ResultVector = new Vector(
                _FirstVector.XPosition * _Scalar,
                _FirstVector.YPosition * _Scalar,
                _FirstVector.ZPosition * _Scalar);
            return ResultVector;
        }

        /// <summary>
        /// Overloads the equality operator to check if two vectors are equal by comparing their components.
        /// </summary>
        /// <param name="_FirstVector">The first vector for comparison.</param>
        /// <param name="_SecondVector">The second vector for comparison.</param>
        /// <returns>True if the vectors are equal; otherwise, false.</returns>
        public static bool operator ==(Vector _FirstVector, Vector _SecondVector)
        {
            return (_FirstVector.XPosition == _SecondVector.XPosition && _FirstVector.YPosition == _SecondVector.YPosition && _FirstVector.ZPosition == _SecondVector.ZPosition);
        }

        /// <summary>
        /// Overloads the inequality operator to check if two vectors are not equal by comparing their components.
        /// </summary>
        /// <param name="_FirstVector">The first vector for comparison.</param>
        /// <param name="_SecondVector">The second vector for comparison.</param>
        /// <returns>True if the vectors are not equal; otherwise, false.</returns>
        public static bool operator !=(Vector _FirstVector, Vector _SecondVector)
        {
            return (_FirstVector.XPosition != _SecondVector.XPosition || _FirstVector.YPosition != _SecondVector.YPosition || _FirstVector.ZPosition != _SecondVector.ZPosition);
        }

        /// <summary>
        /// Calculates and returns the Manhattan distance between the current vector and another specified vector in 3D space.
        /// </summary>
        /// <param name="_Other">The vector to calculate the Manhattan distance to.</param>
        /// <returns>The Manhattan distance between the two vectors.</returns>
        public float GetManhattenDistance(Vector _Other)
        {
            return Math.Abs(this.XPosition - _Other.XPosition) +
                   Math.Abs(this.YPosition - _Other.YPosition) +
                   Math.Abs(this.ZPosition - _Other.ZPosition);
        }
        
        /// <summary>
        /// Calculates and returns the Manhattan distance between the current vector and another specified vector in 3D space.
        /// </summary>
        /// <param name="_Other">The vector to calculate the Manhattan distance to.</param>
        /// <param name="_Other2">The vector to calculate the Manhattan distance to.</param>
        /// <returns>The Manhattan distance between the two vectors.</returns>
        public static float GetManhattenDistance(Vector _Other, Vector _Other2)
        {
            return Math.Abs(_Other.XPosition - _Other2.XPosition) +
                   Math.Abs(_Other.YPosition - _Other2.YPosition) +
                   Math.Abs(_Other.ZPosition - _Other2.ZPosition);
        }

        /// <summary>
        /// Calculates and returns the scalar product (dot product) between the current vector and another specified vector.
        /// </summary>
        /// <param name="_Other">The vector to calculate the scalar product with.</param>
        /// <returns>The scalar product between the two vectors.</returns>
        public float SkalarProdukt(Vector _Other)
        {
            return this.XPosition * _Other.XPosition + this.YPosition * _Other.YPosition + this.ZPosition * _Other.ZPosition;
        }
        
        /// <summary>
        /// Calculates and returns the scalar product (dot product) between the current vector and another specified vector.
        /// </summary>
        /// <param name="_Other">The vector to calculate the scalar product with.</param>
        /// <param name="_Other2">The vector to calculate the scalar product with.</param>
        /// <returns>The scalar product between the two vectors.</returns>
        public static float SkalarProdukt(Vector _Other, Vector _Other2)
        {
            return _Other.XPosition * _Other2.XPosition + _Other.YPosition * _Other2.YPosition + _Other.ZPosition * _Other2.ZPosition;
        }

        /// <summary>
        /// Calculates and returns the cross product between the current vector and another specified vector.
        /// </summary>
        /// <param name="_Other">The vector to calculate the cross product with.</param>
        /// <returns>A new vector representing the cross product between the two vectors.</returns>
        public Vector Kreuzprodukt(Vector _Other)
        {
            Vector temp = new Vector();

            temp.XPosition = (this.YPosition * _Other.ZPosition) - (this.ZPosition * _Other.YPosition);
            temp.YPosition = (this.ZPosition * _Other.XPosition) - (this.XPosition * _Other.ZPosition);
            temp.ZPosition = (this.XPosition * _Other.YPosition) - (this.YPosition * _Other.XPosition);

            return temp;
        }
        
        /// <summary>
        /// Calculates and returns the cross product between the current vector and another specified vector.
        /// </summary>
        /// <param name="_Other">The vector to calculate the cross product with.</param>
        /// <param name="_Other2">The vector to calculate the cross product with.</param>
        /// <returns>A new vector representing the cross product between the two vectors.</returns>
        public static Vector Kreuzprodukt(Vector _Other, Vector _Other2)
        {
            Vector temp = new Vector();

            temp.XPosition = (_Other.YPosition * _Other2.ZPosition) - (_Other.ZPosition * _Other2.YPosition);
            temp.YPosition = (_Other.ZPosition * _Other2.XPosition) - (_Other.XPosition * _Other2.ZPosition);
            temp.ZPosition = (_Other.XPosition * _Other2.YPosition) - (_Other.YPosition * _Other2.XPosition);

            return temp;
        }

        /// <summary>
        /// Returns a string representation of the vector in the format "XPosition, YPosition, ZPosition".
        /// </summary>
        /// <returns>A string representation of the vector.</returns>
        public string ToOwnString()
        {
            return ($"{this.XPosition}, {this.YPosition}, {this.ZPosition}");
        }
        
        /// <summary>
        /// Returns a string representation of the vector in the format "XPosition, YPosition, ZPosition".
        /// </summary>
        /// <returns>A string representation of the vector.</returns>
        public static string ToOwnString(Vector _Other)
        {
            return ($"{_Other.XPosition}, {_Other.YPosition}, {_Other.ZPosition}");
        }

        /// <summary>
        /// Returns an enumerator that iterates over the components of the vector.
        /// </summary>
        /// <returns>An enumerator for the vector's components.</returns>
        public IEnumerator<float> GetEnumerator()
        {
            yield return this.XPosition;
            yield return this.YPosition;
            yield return this.ZPosition;
        }
    }
}