using System;
using System.Linq;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] gameField = new string[n,n];

            int countOfCommands = int.Parse(Console.ReadLine());

            //Get the rows of the matrix

            FillMatrix(gameField);

            int[] currentPosition = FindPlayerPosition(gameField);
            
            bool reachedFinal = false;

            //Play the game
            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();
                
                if (reachedFinal)
                    break;

                var targetPositionStatus = GetTargetPositionStatus(command, gameField, currentPosition);

                MovePlayer(command,targetPositionStatus,gameField,currentPosition);
                
                currentPosition = FindPlayerPosition(gameField);

                reachedFinal = CheckForReachedFinal(gameField);
            }

        }

//Methods
        static void FillMatrix(string[,] gameField)
        {
            //Populate the matrix with content from the console
            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < gameField.GetLength(1); col++)
                {
                    gameField[row,col] = rowInput[col].ToString();
                }
            }
        }
        
        static int[] FindPlayerPosition(string[,] gameField)
        {
            //Find player's current position in the matrix
            int[] position = {0, 0};
            
            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                for (int col = 0; col < gameField.GetLength(1); col++)
                {
                    if (gameField[row,col] == "f")
                    {
                        position[0] = row;
                        position[1] = col;
                    }
                }
            }

            return position;
        }

        static string GetTargetPositionStatus(string command, string[,] gameField, int[] currentPosition)
        {
            //Get string of content of the target position from the matrix
            string status = null;
            int row = currentPosition[0];
            int col = currentPosition[1];
            
            switch (command)
            {
                case "up":
                    status = gameField[row - 1, col];
                    break;
                case "down":
                    status = gameField[row + 1, col];
                    break;
                case "left":
                    status = gameField[row, col - 1];
                    break;
                case "right":
                    status = gameField[row, col + 1];
                    break;
            }

            return status;
        }

        static void MovePlayer(string command, string targetPositionStatus, string[,] gameField, int[] 
        currentPlayerPosition)
        {
            
        }

        static bool CheckForReachedFinal(string[,] gameField)
        {
            bool reachedFinal = true;

            foreach (var point in gameField)
            {
                if (point == "F")
                {
                    reachedFinal = false;
                }
            }

            return reachedFinal;
        }
    }
}
