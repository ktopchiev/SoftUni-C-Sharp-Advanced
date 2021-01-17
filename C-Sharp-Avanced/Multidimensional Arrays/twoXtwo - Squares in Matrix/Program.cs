using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    class Program
    {
        //Find the count of 2 x 2 squares of equal chars in a matrix.
        
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            string[,] matrix = new string[rows, cols];
            
            //Writing characters into the matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] charsInput = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charsInput[col];
                }
            }

            int counter = 0;
            
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    string firstChar = matrix[row, col];
                    string secondChar = matrix[row, col + 1];
                    string thirdChar = matrix[row + 1, col];
                    string fourthChar = matrix[row + 1, col + 1];

                    if (firstChar == secondChar && secondChar == thirdChar && thirdChar == fourthChar)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}