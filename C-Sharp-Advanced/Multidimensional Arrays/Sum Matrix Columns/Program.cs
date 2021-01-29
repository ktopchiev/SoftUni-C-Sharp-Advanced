using System;
using System.Linq;

namespace Sum_Matrix_Elements
{
    /*
     * Write program that read a matrix from console and print the sum for each column.
     * On first line you will get matrix rows.
     * On the next rows lines, you will get elements for each column separated with a space.
     *//// <summary>
       /// /
       /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            int[,] matrix = new int[rows, cols];
            int sum = 0;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbersInput[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}