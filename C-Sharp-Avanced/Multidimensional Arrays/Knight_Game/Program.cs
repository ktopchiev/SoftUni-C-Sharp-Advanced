using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] board = new string[n, n];
            
            //Populate the board with knights
            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < n; col++)
                {
                    board[row, col] = input[col].ToString();
                }
            }
            
            int knightsForRemove = 0;
            int strongestKnight = 0;
            int knightXpostiion = 0;
            int knightYposition = 0;

            while (true)
            {
                //Check for possible moves and count knights which should be removed
                for (int row = 0; row < board.GetLength(0); row++)
                {

                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int hitCounter = 0;

                        if (board[row, col] == "K")
                        {
                            //Arrays of possible moves
                            int[] horizontalMoves = {2, 1, -1, -2, -2, -1, 1, 2};
                            int[] verticalMoves = {1, 2, 2, 1, -1, -2, -2, -1};

                            for (int move = 0; move < 8; move++)
                            {
                                //Position after move
                                int x = row + horizontalMoves[move];
                                int y = col + verticalMoves[move];

                                //Check if there is another Knight and count
                                if (board[x, y] == "K" && x >= 0 && y >= 0 && x < n && y < n)
                                {
                                    hitCounter++;
                                }
                            }
                            
                            if (hitCounter > strongestKnight)
                            {
                                strongestKnight = hitCounter;
                                knightXpostiion = row;
                                knightYposition = col;
                                knightsForRemove++;
                            }
                        }
                    }
                }

                board[knightXpostiion, knightYposition] = "0";

                if (strongestKnight == 0)
                {
                    break;
                }
            }

            Console.WriteLine(knightsForRemove);

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}