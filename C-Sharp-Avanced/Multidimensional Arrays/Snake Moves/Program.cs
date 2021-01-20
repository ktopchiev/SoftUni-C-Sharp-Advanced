using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[] snake = Console.ReadLine().ToCharArray();
            Queue<char> snakeChars = new Queue<char>();

            char[,] matrix = new char[rows, cols];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    snakeChars.Enqueue(snake[j]);
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snakeChars.Dequeue();
                    }   
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col > 0; col--)
                    {
                        matrix[row, col] = snakeChars.Dequeue();
                    }
                }
            }

            Console.WriteLine();
        }
    }
}