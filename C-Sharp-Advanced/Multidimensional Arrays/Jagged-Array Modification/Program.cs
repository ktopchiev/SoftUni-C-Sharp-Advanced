using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    /*Write a program that reads a matrix from the console. On the first line you will get matrix rows.
    On next rows lines you will get elements for each column separated with space. You will be receiving commands in the following format:
    •	Add {row} {col} {value} – Increase the number at the given coordinates with the value.
    •	Subtract {row} {col} {value} – Decrease the number at the given coordinates by the value.
    Coordinates might be invalid. In this case you should print "Invalid coordinates". 
    When you receive "END" you should print the matrix and stop the program.
    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int[][] jaggedArray = new int[n][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[row] = inputNumbers;
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                
                if (command == "END")
                {
                    for (int r = 0; r < jaggedArray.Length; r++)
                    {
                        for (int c = 0; c < jaggedArray.Length; c++)
                        {
                            Console.Write(jaggedArray[r][c] + " ");
                        }

                        Console.WriteLine();
                    }
                    break;
                }

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row > jaggedArray.Length - 1 || row < 0 || col < 0 || col > jaggedArray.Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }
        }
    }
}