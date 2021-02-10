using System;
using System.Collections.Generic;

namespace _02.Selling
{
    public class Program
    {
        static void Main(string[] args)
        {
            int bakerySize = int.Parse(Console.ReadLine());

            string[,] bakery = new string[bakerySize, bakerySize];

            List<int> pillarsCoordinates = new List<int>();
            
            int bakerPositionRow = 0;
            int bakerPositionCol = 0;

            //Fill the matrix
            for (int row = 0; row < bakerySize; row++)
            {
                char[] rowsOfBakeryInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < bakerySize; col++)
                {
                    bakery[row, col] = rowsOfBakeryInput[col].ToString();
                    
                    if (rowsOfBakeryInput[col] == 'S')
                    {
                        bakerPositionRow = row;
                        bakerPositionCol = col;
                        bakery[row, col] = "-";
                    }

                    if (rowsOfBakeryInput[col] == 'S')
                    {
                        pillarsCoordinates.Add(row);
                        pillarsCoordinates.Add(col);
                    }
                }
            }
            
            int collectedMoney = 0;
            
            
            //Move inside
            while (true)
            {
                string command = Console.ReadLine();
                bakery[bakerPositionRow, bakerPositionCol] = "-";
                
                switch (command)
                {
                    case "up":
                        bakerPositionRow--;
                        if (IsValidIndex(bakerPositionRow, bakerPositionCol,bakerySize))
                        {
                            if(Char.IsNumber(char.Parse(bakery[bakerPositionRow, bakerPositionCol])))
                            {
                                collectedMoney += int.Parse(bakery[bakerPositionRow, bakerPositionCol]);
                            }
                            else if (bakery[bakerPositionRow, bakerPositionCol] == "O")
                            {
                                bakery[pillarsCoordinates[2], pillarsCoordinates[3]] = "-";
                                bakerPositionRow = pillarsCoordinates[2];
                                bakerPositionCol = pillarsCoordinates[3];
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad news, you are out of the bakery.");
                        }
                        break;
                    case "down":
                        bakerPositionRow++;
                        if (IsValidIndex(bakerPositionRow, bakerPositionCol,bakerySize))
                        {
                            if(Char.IsNumber(char.Parse(bakery[bakerPositionRow, bakerPositionCol])))
                            {
                                collectedMoney += int.Parse(bakery[bakerPositionRow, bakerPositionCol]);
                            }
                            else if (bakery[bakerPositionRow, bakerPositionCol] == "O")
                            {
                                bakery[pillarsCoordinates[2], pillarsCoordinates[3]] = "-";
                                bakerPositionRow = pillarsCoordinates[2];
                                bakerPositionCol = pillarsCoordinates[3];
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bad news, you are out of the bakery.");
                        }
                        break;
                    case "left":
                        bakerPositionCol--;
                        if (IsValidIndex(bakerPositionRow, bakerPositionCol,bakerySize))
                        {
                            if(Char.IsNumber(char.Parse(bakery[bakerPositionRow, bakerPositionCol])))
                            {
                                collectedMoney += int.Parse(bakery[bakerPositionRow, bakerPositionCol]);
                            }
                            else if (bakery[bakerPositionRow, bakerPositionCol] == "O")
                            {
                                bakery[pillarsCoordinates[2], pillarsCoordinates[3]] = "-";
                                bakerPositionRow = pillarsCoordinates[2];
                                bakerPositionCol = pillarsCoordinates[3];
                            }  
                        }
                        else
                        {
                            Console.WriteLine("Bad news, you are out of the bakery.");
                        }
                        break;
                    case "right":
                        bakerPositionCol++;
                        if (IsValidIndex(bakerPositionRow, bakerPositionCol,bakerySize))
                        {
                            if(Char.IsNumber(char.Parse(bakery[bakerPositionRow, bakerPositionCol])))
                            {
                                collectedMoney += int.Parse(bakery[bakerPositionRow, bakerPositionCol]);
                            }
                            else if (bakery[bakerPositionRow, bakerPositionCol] == "O")
                            {
                                bakery[pillarsCoordinates[2], pillarsCoordinates[3]] = "-";
                                bakerPositionRow = pillarsCoordinates[2];
                                bakerPositionCol = pillarsCoordinates[3];
                            } 
                        }
                        else
                        {
                            Console.WriteLine("Bad news, you are out of the bakery.");
                        }
                        break;
                }
                
                if (!IsValidIndex(bakerPositionRow,bakerPositionCol,bakerySize))
                {
                    break;
                }
                
                if (collectedMoney >= 50)
                {
                    bakery[bakerPositionRow, bakerPositionCol] = "S";
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }
            Console.WriteLine($"Money: {collectedMoney}");
            PrintBakery(bakery);
        }

        public static void PrintBakery(string[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsValidIndex(int bakerPositionRow, int bakerPositionCol,int bakerySize)
        {
            return bakerPositionRow >= 0 && bakerPositionRow < bakerySize && bakerPositionCol >=
                0 && bakerPositionCol < bakerySize;
        }
    }
}