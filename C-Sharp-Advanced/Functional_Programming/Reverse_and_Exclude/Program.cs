using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get a collection of numbers
            int[] collectionOfNums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Func<int[], List<int>> reverse = ReverseCollection;
            
            // Reverse the numbers from the collection using Func<T,T>
            List<int> reversedList = reverse(collectionOfNums);

            Predicate<int> divisibleNum = num => num % n == 0;
            
            //Remove all numbers that are divisible by n
            reversedList.RemoveAll(divisibleNum);

            Console.WriteLine(string.Join(" ", reversedList));

        }

        static List<int> ReverseCollection(int[] collection)
        {
            List<int> reversedList = new List<int>();

            for (int i = 0; i < collection.Length / 2; i++)
            {
                int tempNum = collection[i];
                collection[i] = collection[collection.Length - 1 - i];
                collection[collection.Length - 1 - i] = tempNum;
            }

            reversedList = collection.ToList();
            return reversedList;
        }
    }
}