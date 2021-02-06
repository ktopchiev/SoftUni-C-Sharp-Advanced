using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] myList = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                myList[i] = int.Parse(input);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(myList, indexes[0], indexes[1]);

            foreach (var item in myList)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
        
        private static T[] Swap<T>(T[] list, int x, int y)
        {
            T[] myList = list;

            T temp = list[x];
            list[x] = list[y];
            list[y] = temp;

            return myList;
        }
    }
}