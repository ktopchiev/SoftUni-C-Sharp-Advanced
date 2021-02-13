using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get input for the dimensions of the garden
            int[] dimensionsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = dimensionsInput[0];
            int m = dimensionsInput[1];
            
            //Create the garden
            int[,] garden = new int[n, m];
            
            //Fill the garden with flowers initially set to zero
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }
            
            //Planting the flowers
            Queue<int[]> plantedFlowersPositions = new Queue<int[]>();

            while (true)
            {
                char[] positionForPlanting = Console.ReadLine().ToCharArray();

                int x = 0;
                int y = 0;

                if (positionForPlanting[0] == 'B')
                {
                    break;
                }
                else
                {
                    x = int.Parse(positionForPlanting[0].ToString());
                    y = int.Parse(positionForPlanting[2].ToString());
                }

                if (x > n || y > m)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    plantedFlowersPositions.Enqueue(new int[]{x, y});
                }
            }
            
            //Blooming!

            while (plantedFlowersPositions.Count > 0)
            {
                int[] currentFlowerPositions = plantedFlowersPositions.Dequeue();
                
                int currentFlowerRow = currentFlowerPositions[0];
                int currentFlowerCol = currentFlowerPositions[1];
                
                //Right flowers blooming
                for (int col = currentFlowerCol; col < garden.GetLength(1); col++)
                {
                    garden[currentFlowerRow, col]++;
                }
                
                //Left flowers blooming
                for (int col = currentFlowerCol; col >= 0; col--)
                {
                    garden[currentFlowerRow, col]++;
                }
                
                //Down flowers blooming
                for (int row = currentFlowerRow; row < garden.GetLength(0); row++)
                {
                    garden[row, currentFlowerCol]++;
                }
                
                //Up flowers blooming
                for (int row = currentFlowerRow; row >= 0; row--)
                {
                    garden[row, currentFlowerCol]++;
                }

                garden[currentFlowerRow, currentFlowerCol] = 1;
            }
            
            //Print the garden
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row,col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}