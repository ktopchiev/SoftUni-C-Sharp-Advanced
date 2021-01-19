using System;
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

            char[] snake = Console.ReadLine().Split("", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            snake.Reverse();

            char[,] isle = new char[rows, cols];

            int currentSnakeIndex = 0;

            for (int row = 0; row < isle.GetLength(0); row++)
            {
                snake.Reverse();
                
                for (int col = 0; col < isle.GetLength(1); col++)
                {
                    if (col > snake.Length - 1)
                    {
                        for (int i = 0; i < isle.GetLength(1); i++)
                        {
                            isle[row, col] = snake[i];
                            currentSnakeIndex = i;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < currentSnakeIndex; i++)
                        {
                            isle[row, col] = snake[i];
                        }
                    }

                    isle[row, col] = snake[col];
                }
            }

        }
    }
}