using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            //Custom Min function
            HashSet<int> setOfIntegers = Console.ReadLine().Split(" ", StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            Func<HashSet<int>, int> Min = GetMin;
            Console.WriteLine(Min(setOfIntegers));
        }

        static int GetMin(HashSet<int> integers)
        {
            int min = integers.First();
            
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