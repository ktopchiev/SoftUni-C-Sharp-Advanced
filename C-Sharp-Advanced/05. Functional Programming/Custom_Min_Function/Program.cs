using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            //Custom Min function that returns the smallest integer
            
            int[] setOfIntegers = Console.ReadLine().Split(" ", StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> Min = GetMinInt;
            Console.WriteLine(Min(setOfIntegers));
        }

        static int GetMinInt(int[] integers)
        {
            int min = integers[0];
            
            foreach (var integer in integers)
            {
                if (integer < min)
                {
                    min = integer;
                }
            }

            return min;
        }
    }
}