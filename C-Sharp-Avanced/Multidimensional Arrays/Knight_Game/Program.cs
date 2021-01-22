/*Chess is the oldest game, but it is still popular these days. For this task we will use only one chess piece – the Knight.
    The knight moves to the nearest square but not on the same row, column, or diagonal. (This can be thought of as
    moving two squares horizontally, then one square vertically, or moving one square horizontally then two squares
    vertically— i.e. in an "L" pattern.)
    The knight game is played on a board with dimensions N x N and a lot of chess knights.
    You will receive a board with "K" for knights and "0" for empty cells. Your task is to remove a MINIMUM of the knights,
    so there will be no knights left that can attack another knight.*/

using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] chessBoard = new string[n, n];
            
            //Populate the board with knights
            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                
                for (int col = 0; col < n; col++)
                {
                    chessBoard[row, col] = input[col].ToString();
                }
            }
            
            int knightsForRemove = 0;
            int strongestKnight = 0;
            int knightXposition = 0;
            int knightYposition = 0;

            while (true)
            {
                //Check for possible moves and count knights which should be removed
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        int hitCounter = 0;

                        if (chessBoard[row, col] == "K")
                        {
                            //Arrays of possible moves
                            int[] horizontalMoves = {2, 1, -1, -2, -2, -1, 1, 2};
                            int[] verticalMoves = {1, 2, 2, 1, -1, -2, -2, -1};

                            for (int move = 0; move < 8; move++)
                            {
                                //Position after move
                                int x = row + horizontalMoves[move];
                                int y = col + verticalMoves[move];

                                //Check if there is another Knight on the way and count the hit
                                if (x >= 0 && y >= 0 && x < n && y < n && chessBoard[x, y] == "K")
                                {
                                    hitCounter++;
                                }
                            }
                            
                            //If there is stronger knight replace current data with his data 'cause we're searching for the strongest knight
                            if (hitCounter > strongestKnight)
                            {
                                strongestKnight = hitCounter;
                                hitCounter = 0;
                                knightXposition = row;
                                knightYposition = col;
                            }
                        }
                    }
                }
                
                //Remove the strongest knight with biggest amount of possibilities to hit another knight
                if (strongestKnight > 0)
                {
                    chessBoard[knightXposition, knightYposition] = "0";
                    strongestKnight = 0;
                    knightsForRemove++;   
                }
                else
                {
                    //If there is no strongest knight 
                    break;
                }

            }

            Console.WriteLine(knightsForRemove);
        }
    }
}