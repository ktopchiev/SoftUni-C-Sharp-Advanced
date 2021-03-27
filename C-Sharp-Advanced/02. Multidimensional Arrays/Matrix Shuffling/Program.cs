
/*Write a program which reads a string matrix from the console and performs certain operations with its elements.
 User input is provided in a similar way like in the problems above – first you read the dimensions and then the data. 
Your program should then receive commands in format: "swap row1 col1 row2c col2" where row1, row2, col1, col2 are 
coordinates in the matrix. In order for a command to be valid, it should start with the "swap" keyword along with 
four valid coordinates (no more, no less). You should swap the values at the given coordinates (cell [row1, col1] with cell [row2, col2]) 
and print the matrix at each step (thus you'll be able to check if the operation was performed correctly). 
If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered or 
the given coordinates do not exist), print "Invalid input!" and move on to the next command. 
Your program should finish when the string "END" is entered.
*/

using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensionsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRows = matrixDimensionsInput[0];
            int matrixCols = matrixDimensionsInput[1];

            string[,] matrix = new string[matrixRows, matrixCols];
            
            FillMatrix(matrix);

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string command = commands[0];
                
                if (command == "END")
                {
                    break;
                }

                bool isValid = CommandValidation(matrix, commands);
                
                if (isValid)
                {
                    SwapMatrixElements(matrix, commands);
                    PrintMatrix(matrix);
                }
                else if(!isValid)
                {
                    Console.WriteLine("Invalid input!");
                }
                
            }
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        private static void SwapMatrixElements(string[,] matrix, string[] coordinates)
        {
            int row1 = int.Parse(coordinates[1]);
            int col1 = int.Parse(coordinates[2]);
            int row2 = int.Parse(coordinates[3]);
            int col2 = int.Parse(coordinates[4]);

            string firstElement = matrix[row1, col1];
            string secondElement = matrix[row2, col2];
            
            matrix[row1, col1] = secondElement;
            matrix[row2, col2] = firstElement;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool CommandValidation(string[,] matrix, string[] commands)
        {

            bool isTrue = false;
            
            if (commands.Length == 5 && commands[0] == "swap")
            {
                int row1;
                int col1;
                int row2;
                int col2;
                
                bool successRow1 = int.TryParse(commands[1], out row1);
                bool successCol1 = int.TryParse(commands[2], out col1);
                bool successRow2 = int.TryParse(commands[3], out row2);
                bool successCol2 = int.TryParse(commands[4], out col2);

                if (successRow1 && successCol1 && successRow2 && successCol2)
                {
                    if (row1 < matrix.GetLength(0) && row1 >= 0 &&
                        col1 < matrix.GetLength(1) && col1 >= 0 &&
                        col2 < matrix.GetLength(1) && col2 >= 0 &&
                        row2 < matrix.GetLength(0) && row2 >= 0)
                    {
                        isTrue = true;
                    }
                }
            }

            return isTrue;
        }
    }
}