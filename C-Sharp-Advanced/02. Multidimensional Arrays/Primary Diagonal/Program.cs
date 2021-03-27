using System;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        /*
         * Write a program that finds the sum of matrix primary diagonal.
         */
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputNumbers[col];
                    if (col == row)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}