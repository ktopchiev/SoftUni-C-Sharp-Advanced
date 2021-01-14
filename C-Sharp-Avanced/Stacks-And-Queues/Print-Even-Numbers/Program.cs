using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    /*
        Write program that:
         Reads an array of integers and adds them to a queue
         Prints the even numbers separated by "," 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> ints = new Queue<int>(integers);
            
            while (ints.Count > 0)
            {
                int num = ints.Dequeue();
                if (num % 2 == 0)
                {
                    Console.Write(num);

                    if (ints.Count > 0)
                    {
                        Console.Write(", ");
                    }
                }
            }
        }
    }
}