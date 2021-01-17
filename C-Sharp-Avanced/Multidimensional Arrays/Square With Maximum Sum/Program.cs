using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    class Program
    {
        /*Write a program that read a matrix from console. Then find biggest sum of 2x2 submatrix and print it to console.
        On first line you will get matrix sizes in format rows, columns.
        One next rows lines you will get elements for each column separated with coma.
        Print biggest top-left square, which you find and sum of its elements.
        */
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            int[,] matrix = new int[rows, cols];
            int sum = 0;
            int maxColIndex = 0;
            int maxRowIndex = 0;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbersInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbersInput[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] + matrix[row + 1, col + 1] + matrix[row + 1, col] + matrix[row, col + 1] > sum)
                    {
                        sum = matrix[row, col] + matrix[row + 1, col + 1] + matrix[row + 1, col] + matrix[row, col + 1];
                        maxColIndex = col;
                        maxRowIndex = row;
                    };
                }
            }

            for (int row = maxRowIndex; row < maxRowIndex + 2; row++)
            {
                for (int col = maxColIndex; col < maxColIndex + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine(sum);
        }
    }
}