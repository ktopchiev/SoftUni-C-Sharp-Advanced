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

            int commandsNumberLimit = int.Parse(Console.ReadLine());

            //Get the content of the matrix

            int[] currentPosition = FillMatrix(gameField);
            
            int currentRow = currentPosition[0];
            int currentCol = currentPosition[1];

            bool finalIsReached = false;

            int enteredCommandsNum = 0;

            //Play the game
            while(enteredCommandsNum < commandsNumberLimit && !finalIsReached)
            {
                string command = Console.ReadLine();

                finalIsReached = MovePlayer(command,gameField, currentRow, currentCol);

                enteredCommandsNum++;

            }
            
            //At the end print the result and the game field
            switch (finalIsReached)
            {
                case true:
                    Console.WriteLine("Player won!");
                    PrintGameField(gameField);
                    break;
                case false:
                    Console.WriteLine("Player lost!");
                    PrintGameField(gameField);
                    break;
            }

        }

        //Methods
        static int[] FillMatrix(string[,] gameField)
        {
            int[] currentPosition = new int[2];
            //Populate the matrix with content from the console
            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < gameField.GetLength(1); col++)
                {
                    gameField[row,col] = rowInput[col].ToString();
                    if (rowInput[col] == 'f')
                    {
                        currentPosition[0] = row;
                        currentPosition[1] = col;
                    }
                }
            }

            return currentPosition;
        }
        

        static bool MovePlayer(string command, string[,] gameField, int currentRow, int currentCol)
        {
            bool hasWon = false;
            gameField[currentRow, currentCol] = "-";
            
            if (command == "up")
            {
                bool isCrossed = IsBoundaryCrossed(command, gameField, currentRow, currentCol);
                currentRow = isCrossed ? gameField.Length - 1 : currentRow - 1;
                
                if (gameField[currentRow, currentCol] == "B")
                {
                    MovePlayer("up", gameField, currentRow, currentCol);
                }
                else if (gameField[currentRow, currentCol] == "F")
                {
                    hasWon = true;
                }
                else if (gameField[currentRow,currentCol] == "T")
                {
                    MovePlayer("down", gameField, currentRow, currentCol);
                }
            }
            

            return hasWon;
        }

        static bool IsBoundaryCrossed(string command, string[,] gameField, int currentRow, int currentCol)
        {
            
            bool isCrossed = false;
            
            if (command == "up")
            {
                if (currentRow - 1 < 0)
                {
                    isCrossed = true;
                }
            }
            else if (command == "down")
            {
                if (currentRow + 1 >= gameField.GetLength(0))
                {
                    isCrossed = true;
                }
            }
            else if (command == "left")
            {
                if (currentCol - 1 < 0)
                {
                    isCrossed = true;
                }
            }
            else if (command == "right")
            {
                if (currentCol + 1 >= gameField.GetLength(1))
                {
                    isCrossed = true;
                }
            }

            return isCrossed;
        }

        static void PrintGameField(string[,] gameField)
        {
            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                for (int col = 0; col < gameField.GetLength(1); col++)
                {
                    Console.Write(gameField[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
