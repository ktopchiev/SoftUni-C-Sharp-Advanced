using System;
using System.Collections.Generic;

namespace _02.Snake
{
    public class Program
    {
        static void Main(string[] args)
        {
            int territorySize = int.Parse(Console.ReadLine());

            string[,] territory = new string[territorySize, territorySize];

            int beePositionRow = 0;
            int beePositionCol = 0;

            //Fill the matrix
            for (int row = 0; row < territorySize; row++)
            {
                char[] rowsOfTerritoryInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < territorySize; col++)
                {
                    territory[row, col] = rowsOfTerritoryInput[col].ToString();
                    
                    if (rowsOfTerritoryInput[col] == 'B')
                    {
                        beePositionRow = row;
                        beePositionCol = col;
                        territory[row, col] = ".";
                    }
                }
            }
            
            int pollinatedFlowers = 0;

            //Move inside
            while (true)
            {
                string command = Console.ReadLine();
                territory[beePositionRow, beePositionCol] = ".";

                if (command == "End")
                {
                    break;
                }
                
                switch (command)
                {
                    case "up":
                        beePositionRow--;
                        if (IsValidIndex(beePositionRow, beePositionCol,territorySize))
                        {
                            if(territory[beePositionRow, beePositionCol] == "f")
                            {
                                pollinatedFlowers++;
                            }
                            else if (territory[beePositionRow, beePositionCol] == "O")
                            {
                                territory[beePositionRow, beePositionCol] = ".";
                                beePositionRow--;
                                if (territory[beePositionRow, beePositionCol] == "f")
                                {
                                    pollinatedFlowers++;
                                }
                            } 
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                        }
                        break;
                    case "down":
                        beePositionRow++;
                        if (IsValidIndex(beePositionRow, beePositionCol,territorySize))
                        {
                            if(territory[beePositionRow, beePositionCol] == "f")
                            {
                                pollinatedFlowers++;
                            }
                            else if (territory[beePositionRow, beePositionCol] == "O")
                            {
                                territory[beePositionRow, beePositionCol] = ".";
                                beePositionRow++;
                                if (territory[beePositionRow, beePositionCol] == "f")
                                {
                                    pollinatedFlowers++;
                                }
                            } 
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                        }
                        break;
                    case "left":
                        beePositionCol--;
                        if (IsValidIndex(beePositionRow, beePositionCol,territorySize))
                        {
                            if(territory[beePositionRow, beePositionCol] == "f")
                            {
                                pollinatedFlowers ++;
                            }
                            else if (territory[beePositionRow, beePositionCol] == "O")
                            {
                                territory[beePositionRow, beePositionCol] = ".";
                                beePositionCol--;
                                if (territory[beePositionRow, beePositionCol] == "f")
                                {
                                    pollinatedFlowers++;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                        }
                        break;
                    case "right":
                        beePositionCol++;
                        if (IsValidIndex(beePositionRow, beePositionCol,territorySize))
                        {
                            if(territory[beePositionRow, beePositionCol] == "f")
                            {
                                pollinatedFlowers ++;
                            }
                            else if (territory[beePositionRow, beePositionCol] == "O")
                            {
                                territory[beePositionRow, beePositionCol] = ".";
                                beePositionCol++;
                                if (territory[beePositionRow, beePositionCol] == "f")
                                {
                                    pollinatedFlowers++;
                                }
                            } 
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                        }
                        break;
                }
                
                if (!IsValidIndex(beePositionRow,beePositionCol,territorySize))
                {
                    break;
                }
            }

            if (IsValidIndex(beePositionRow, beePositionCol, territorySize))
            {
                territory[beePositionRow, beePositionCol] = "B";
            }
            
            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");   
            }
            
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            PrintTerritory(territory);
        }

        public static void PrintTerritory(string[,] territory)
        {
            for (int row = 0; row < territory.GetLength(0); row++)
            {
                for (int col = 0; col < territory.GetLength(1); col++)
                {
                    Console.Write(territory[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsValidIndex(int snakePositionRow, int snakePositionCol,int territorySize)
        {
            return snakePositionRow >= 0 && snakePositionRow < territorySize && snakePositionCol >=
                0 && snakePositionCol < territorySize;
        }
    }
}