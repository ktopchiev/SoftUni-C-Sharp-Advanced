using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    class Program
    {
        /*Write a program that reads a rectangular integer matrix of size N x M and
         finds in it the square 3 x 3 that has maximal sum of its elements.
        */
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            int[,] matrix = new int[rows, cols];
            int currentSum = 0;
            int maxColIndex = 0;
            int maxRowIndex = 0;
            int biggestSum = 0;
            
            //Fill the matrix with numbers
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbersInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbersInput[col];
                }
            }
            
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    for (int i = row; i < row + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            currentSum += matrix[i, j];
                        }
                    }

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        currentSum = 0;
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                    else
                    {
                        currentSum = 0;
                    }
                }
            }
            
            Console.WriteLine($"Sum = {biggestSum}");
            
            for (int row = maxRowIndex; row < maxRowIndex + 3; row++)
            {
                for (int col = maxColIndex; col < maxColIndex + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}