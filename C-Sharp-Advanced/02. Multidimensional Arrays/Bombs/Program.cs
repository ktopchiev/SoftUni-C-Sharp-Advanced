using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the matrix
            int nSize = int.Parse(Console.ReadLine());

            int[,] field = new int[nSize, nSize];
            
            //Fill the matrix
            for (int row = 0; row < nSize; row++)
            {
                int[] rowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < nSize; col++)
                {
                    field[row, col] = rowInput[col];
                }
            }
            
            //Get the bombs coordinates
            int[] coordinatesOfBombsInput = Console.ReadLine()
                .Split(new[] {",", " "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> coordinatesOfBombs = new Queue<int>(coordinatesOfBombsInput);
            
            //Start the massacre
            while (coordinatesOfBombs.Count > 0)
            {
                int row = coordinatesOfBombs.Dequeue();
                int col = coordinatesOfBombs.Dequeue();

                if (row < nSize && row >= 0 && col < nSize && col >= 0)
                {
                    int bombPower = field[row, col];
                    bool upExplosion = false,
                        downExplosion = false,
                        leftExplosion = false, 
                        rightExplosion = false;
                    
                    //EXPLODE STRAIGHTS
                    
                    //Explode up
                    if (row - 1 >= 0)
                    {
                        if (field[row - 1, col] > 0)
                        {
                            field[row - 1, col] -= bombPower;
                        }
                        
                        upExplosion = true;
                    }
                    
                    //Explode down
                    if (row + 1 < nSize)
                    {
                        if (field[row + 1, col] > 0)
                        {
                            field[row + 1, col] -= bombPower;
                        }
                        
                        downExplosion = true;
                    }
                    
                    //Explode left
                    if (col - 1 >= 0)
                    {
                        if (field[row, col - 1] > 0)
                        {
                            field[row, col - 1] -= bombPower;
                        }
                        
                        leftExplosion = true;
                    }
                    
                    //Explode right
                    if (col + 1 < nSize)
                    {
                        if (field[row, col + 1] > 0)
                        {
                            field[row, col + 1] -= bombPower;
                        }
                        
                        rightExplosion = true;
                    }
                    
                    //EXPLODE DIAGONALS
                    
                    //Explode up to right diagonal
                    if (upExplosion && rightExplosion)
                    {
                        if (field[row - 1, col + 1] > 0)
                        {
                            field[row - 1, col + 1] -= bombPower;
                        }
                    }
                    
                    //Explode up to left diagonal
                    if (upExplosion && leftExplosion)
                    {
                        if (field[row - 1, col - 1] > 0)
                        {
                            field[row - 1, col - 1] -= bombPower;
                        }
                    }
                    
                    //Explode down to right
                    if (downExplosion && rightExplosion)
                    {
                        if (field[row + 1, col + 1] > 0)
                        {
                            field[row + 1, col + 1] -= bombPower;
                        }
                    }
                    
                    //Explode down to left
                    if (downExplosion && leftExplosion)
                    {
                        if (field[row + 1, col - 1] > 0)
                        {
                            field[row + 1, col - 1] -= bombPower;
                        }
                    }

                    field[row, col] = 0;
                }
            }
            
            //Print the count of alive cells and the sum of their values
            int aliveCellsCounter = 0;
            int sumOfAliveCells = 0;
            
            foreach (var cell in field)
            {
                if (cell > 0)
                {
                    aliveCellsCounter++;
                    sumOfAliveCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCounter}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");
            
            //Print the matrix final condition
            PrintField(field);
        }

        private static void PrintField(int[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}