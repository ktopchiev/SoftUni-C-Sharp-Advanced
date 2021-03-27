using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            char[] snake = Console.ReadLine().ToCharArray();
            
            Queue<string> snakeQueue = new Queue<string>();
            Stack<string> snakeStack = new Stack<string>();
                
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] isle = new string[rows, cols];

            int isleCapacity = rows * cols;

            int capacityCounter = 0;
            
            //Get the snake into queue
            for (int i = 0; i <= snake.Length; i++)
            {
                if (capacityCounter == isleCapacity)
                {
                    break;
                }
                
                if (i < snake.Length)
                {
                    snakeQueue.Enqueue(snake[i].ToString());
                    capacityCounter++;
                }
                else
                {
                    i = -1;
                }
            }
            
            //Populating the matrix with the snake
            for (int row = 0; row < isle.GetLength(0); row++)
            {
                if (row % 2 != 0)
                {
                    for (int i = 0; i < isle.GetLength(1); i++)
                    {
                        snakeStack.Push(snakeQueue.Dequeue());
                    }
                }
                for (int col = 0; col < isle.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        isle[row, col] = snakeQueue.Dequeue();
                    }
                    else
                    {
                        isle[row, col] = snakeStack.Pop();
                    }
                }
            }
            
            //Print the matrix
            for (int row = 0; row < isle.GetLength(0); row++)
            {
                for (int col = 0; col < isle.GetLength(1); col++)
                {
                    Console.Write(isle[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}