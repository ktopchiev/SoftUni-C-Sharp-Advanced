using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_Or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using Predicate<> for finding odds and evens from a list of integers
            
            int[] boundaries = Console.ReadLine().Split(" ", StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray();

            int lowerBound = boundaries[0];
            int upperBound = boundaries[1];

            List<int> integers = new List<int>();
            
            for (int low = lowerBound; low <= upperBound; low++)
            {
                integers.Add(low);
            }
            
            Predicate<int> oddNumFinder = i => i % 2 != 0;
            Predicate<int> evenNumFinder = i => i % 2 == 0;

            List<int> odds = integers.FindAll(oddNumFinder).ToList();
            List<int> evens = integers.FindAll(evenNumFinder).ToList();

            string finderCommand = Console.ReadLine();

            switch (finderCommand)
            {
                case "even":
                    Console.WriteLine(string.Join(" ", evens));
                    break;
                case "odd":
                    Console.WriteLine(string.Join(" ", odds));
                    break;
            }
        }
    }
}