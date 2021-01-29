using System;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        /*
         * Write a program that finds the difference between the sums of the square matrix diagonals (absolute value).
         */
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int sumFirstDiagonal = 0;
            int sumSecondDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == row)
                    {
                        sumFirstDiagonal += matrix[row, col];
                        sumSecondDiagonal += matrix[row, matrix.GetLength(1) - 1 - col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumFirstDiagonal-sumSecondDiagonal));
        }
    }
}