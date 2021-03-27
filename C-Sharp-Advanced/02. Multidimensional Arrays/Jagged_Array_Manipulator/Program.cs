/*Create a program that populates, analyzes and manipulates the elements of a matrix with unequal length of its
rows.
    First you will receive an integer N equal to the number of rows in your matrix.
    On the next N lines, you will receive sequences of integers, separated by a single space. Each sequence is a row in
the matrix.
    After populating the matrix, start analyzing it. If a row and the one below it have equal length, multiply each
element in both of them by 2, otherwise - divide by 2.
    Then, you will receive commands. There are three possible commands:
     &quot;Add {row} {column} {value}&quot; - add {value} to the element at the given indexes, if they are valid
     &quot;Subtract {row} {column} {value}&quot; - subtract {value} from the element at the given indexes, if
they are valid
     &quot;End&quot; - print the final state of the matrix (all elements separated by a single space) and stop the program*/

using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsNum = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rowsNum][];
            
            //Populating the jagged array's rows with integers input sequences from the console
            for (int row = 0; row < rowsNum; row++)
            {
                double[] intSequenceInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArray[row] = intSequenceInput;
            }
            
            
            //Analyzing the array
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
            
            //Perform manipulations
            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                
                if (command == "End")
                {
                    PrintJaggedArray(jaggedArray);
                    break;
                }
                else
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    double value = double.Parse(commands[3]);

                    switch (command)
                    {
                        case "Add":
                            Add(jaggedArray, row, col, value);
                            break;
                        case "Subtract":
                            Subtract(jaggedArray, row, col, value);
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        private static void Add(double[][] jaggedArray, int row, int col, double 
        value)
        {
            if (jaggedArray.Length > row && row >= 0 && col >= 0)
            {
                if (jaggedArray[row].Length > col)
                {
                    jaggedArray[row][col] += value;   
                }
            }
        }

        private static void Subtract(double[][] jaggedArray, int row, int col, double 
            value)
        {
            if (jaggedArray.Length > row && row >= 0 && col >= 0)
            {
                if (jaggedArray[row].Length > col)
                {
                    jaggedArray[row][col] -= value;   
                }
            }
        }

        private static void PrintJaggedArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}