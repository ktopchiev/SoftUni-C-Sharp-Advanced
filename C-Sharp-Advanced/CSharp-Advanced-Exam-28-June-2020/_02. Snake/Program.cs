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

            List<int> lairsCoordinates = new List<int>();
            
            int snakePositionRow = 0;
            int snakePositionCol = 0;

            //Fill the matrix
            for (int row = 0; row < territorySize; row++)
            {
                char[] rowsOfTerritoryInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < territorySize; col++)
                {
                    territory[row, col] = rowsOfTerritoryInput[col].ToString();
                    
                    if (rowsOfTerritoryInput[col] == 'S')
                    {
                        snakePositionRow = row;
                        snakePositionCol = col;
                        territory[row, col] = ".";
                    }

                    if (rowsOfTerritoryInput[col] == 'B')
                    {
                        lairsCoordinates.Add(row);
                        lairsCoordinates.Add(col);
                    }
                }
            }
            
            int eatenFood = 0;

            //Move inside
            while (true)
            {
                string command = Console.ReadLine();
                territory[snakePositionRow, snakePositionCol] = ".";
                
                switch (command)
                {
                    case "up":
                        snakePositionRow--;
                        if (IsValidIndex(snakePositionRow, snakePositionCol,territorySize))
                        {
                            if(territory[snakePositionRow, snakePositionCol] == "*")
                            {
                                eatenFood += 1;
                                territory[snakePositionRow, snakePositionCol] = ".";
                            }
                            else if (territory[snakePositionRow, snakePositionCol] == "B")
                            {
                                territory[snakePositionRow, snakePositionCol] = ".";
                                territory[lairsCoordinates[2], lairsCoordinates[3]] = ".";
                                snakePositionRow = lairsCoordinates[2];
                                snakePositionCol = lairsCoordinates[3];
                            }
                        }
                        else
                        {
                            Console.WriteLine("Game over!");
                        }
                        break;
                    case "down":
                        snakePositionRow++;
                        if (IsValidIndex(snakePositionRow, snakePositionCol,territorySize))
                        {
                            if(territory[snakePositionRow, snakePositionCol] == "*")
                            {
                                eatenFood += 1;
                                territory[snakePositionRow, snakePositionCol] = ".";
                            }
                            else if (territory[snakePositionRow, snakePositionCol] == "B")
                            {
                                territory[snakePositionRow, snakePositionCol] = ".";
                                territory[lairsCoordinates[2], lairsCoordinates[3]] = ".";
                                snakePositionRow = lairsCoordinates[2];
                                snakePositionCol = lairsCoordinates[3];
                            }
                        }
                        else
                        {
                            Console.WriteLine("Game over!");
                        }
                        break;
                    case "left":
                        snakePositionCol--;
                        if (IsValidIndex(snakePositionRow, snakePositionCol,territorySize))
                        {
                            if(territory[snakePositionRow, snakePositionCol] == "*")
                            {
                                eatenFood += 1;
                                territory[snakePositionRow, snakePositionCol] = ".";
                            }
                            else if (territory[snakePositionRow, snakePositionCol] == "B")
                            {
                                territory[snakePositionRow, snakePositionCol] = ".";
                                territory[lairsCoordinates[2], lairsCoordinates[3]] = ".";
                                snakePositionRow = lairsCoordinates[2];
                                snakePositionCol = lairsCoordinates[3];
                            }  
                        }
                        else
                        {
                            Console.WriteLine("Game over!");
                        }
                        break;
                    case "right":
                        snakePositionCol++;
                        if (IsValidIndex(snakePositionRow, snakePositionCol,territorySize))
                        {
                            if(territory[snakePositionRow, snakePositionCol] == "*")
                            {
                                eatenFood += 1;
                                territory[snakePositionRow, snakePositionCol] = ".";
                            }
                            else if (territory[snakePositionRow, snakePositionCol] == "B")
                            {
                                territory[snakePositionRow, snakePositionCol] = ".";
                                territory[lairsCoordinates[2], lairsCoordinates[3]] = ".";
                                snakePositionRow = lairsCoordinates[2];
                                snakePositionCol = lairsCoordinates[3];
                            } 
                        }
                        else
                        {
                            Console.WriteLine("Game over!");
                        }
                        break;
                }
                
                if (!IsValidIndex(snakePositionRow,snakePositionCol,territorySize))
                {
                    break;
                }
                
                if (eatenFood >= 10)
                {
                    territory[snakePositionRow, snakePositionCol] = "S";
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
            }
            Console.WriteLine($"Food eaten: {eatenFood}");
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