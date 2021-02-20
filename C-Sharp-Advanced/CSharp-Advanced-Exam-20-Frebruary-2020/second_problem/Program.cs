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

            string[,] field = new string[nSize, nSize];

            //Get the attack coordinates
            int[] attackCommandsInput = Console.ReadLine()
                .Split(new[] {",", " "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> attackCommands = new Queue<int>(attackCommandsInput);

            //Fill the matrix
            for (int row = 0; row < nSize; row++)
            {
                string[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < nSize; col++)
                {
                    field[row, col] = rowInput[col];
                }
            }


            int playerOneShips = 0;
            int playerTwoShips = 0;
            
            foreach (var cell in field)
            {
                if (cell == "<")
                {
                    playerOneShips++;
                }
                else if (cell == ">")
                {
                    playerTwoShips++;
                }
            }

            int counter = 0;
            int totalCountShipsDestroyed = 0;

            //Start the massacre
            while (attackCommands.Count > 0 && playerOneShips > 0 && playerTwoShips > 0)
            {
                counter++;

                int row = attackCommands.Dequeue();
                int col = attackCommands.Dequeue();

                if (row < nSize && row >= 0 && col < nSize && col >= 0)
                {
                    if (field[row, col] == "#")
                    {
                        bool upExplosion = false,
                            downExplosion = false,
                            leftExplosion = false,
                            rightExplosion = false;

                        //EXPLODE STRAIGHTS

                        //Explode up
                        if (row - 1 >= 0)
                        {
                            if (field[row - 1, col] == "<")
                            {
                                playerOneShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row - 1, col] == ">")
                            {
                                playerTwoShips--;
                                totalCountShipsDestroyed++;
                            }

                            field[row - 1, col] = "X";
                            upExplosion = true;
                        }

                        //Explode down
                        if (row + 1 < nSize)
                        {
                            if (field[row + 1, col] == "<")
                            {
                                playerOneShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row + 1, col] == ">")
                            {
                                playerTwoShips--;
                                totalCountShipsDestroyed++;
                            }

                            field[row + 1, col] = "X";
                            downExplosion = true;
                        }

                        //Explode left
                        if (col - 1 >= 0)
                        {
                            if (field[row, col - 1] == "<")
                            {
                                playerOneShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row, col - 1] == ">")
                            {
                                playerTwoShips--;
                                totalCountShipsDestroyed++;
                            }

                            field[row, col - 1] = "X";
                            leftExplosion = true;
                        }

                        //Explode right
                        if (col + 1 < nSize)
                        {
                            if (field[row, col + 1] == "<")
                            {
                                playerOneShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row, col + 1] == ">")
                            {
                                playerTwoShips--;
                                totalCountShipsDestroyed++;
                            }

                            field[row, col + 1] = "X";
                            rightExplosion = true;
                        }

                        //EXPLODE DIAGONALS

                        //Explode up to right diagonal
                        if (upExplosion && rightExplosion)
                        {
                            if (field[row - 1, col + 1] == "<")
                            {
                                playerOneShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row - 1, col + 1] == ">")
                            {
                                playerTwoShips--;
                                totalCountShipsDestroyed++;
                            }

                            field[row - 1, col + 1] = "X";
                        }

                        //Explode up to left diagonal
                        if (upExplosion && leftExplosion)
                        {
                            if (field[row - 1, col - 1] == "<")
                            {
                                playerOneShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row - 1, col - 1] == ">")
                            {
                                playerTwoShips--;
                                totalCountShipsDestroyed++;
                            }

                            field[row - 1, col - 1] = "X";
                        }

                        //Explode down to right
                        if (downExplosion && rightExplosion)
                        {
                            if (field[row + 1, col + 1] == "<")
                            {
                                playerOneShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row + 1, col + 1] == ">")
                            {
                                playerTwoShips--;
                                totalCountShipsDestroyed++;
                            }

                            field[row + 1, col + 1] = "X";
                        }

                        //Explode down to left
                        if (downExplosion && leftExplosion)
                        {
                            if (field[row + 1, col - 1] == "<")
                            {
                                playerOneShips--;
                                totalCountShipsDestroyed++;
                            }
                            else if (field[row + 1, col - 1] == ">")
                            {
                                playerTwoShips--;
                                totalCountShipsDestroyed++;
                            }

                            field[row + 1, col - 1] = "X";
                        }

                        field[row, col] = "X";
                    }

                    if (counter % 2 == 0)
                    {
                        if (field[row, col] == "<")
                        {
                            field[row, col] = "X";
                            playerOneShips--;
                            totalCountShipsDestroyed++;
                        }
                    }
                    else
                    {
                        if (field[row, col] == ">")
                        {
                            field[row, col] = "X";
                            playerTwoShips--;
                            totalCountShipsDestroyed++;
                        }
                    }
                }
            }


            if (attackCommands.Count == 0 && playerOneShips != 0 && playerTwoShips != 0 && playerOneShips != playerTwoShips)
            {
                Console.WriteLine(
                    $"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
            else if (playerOneShips == playerTwoShips)
            {
                Console.WriteLine(
                    $"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
            else if (playerOneShips > playerTwoShips)
            {
                Console.WriteLine(
                    $"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (playerOneShips < playerTwoShips)
            {
                Console.WriteLine(
                    $"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
        }
    }
}