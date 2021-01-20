using System;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElements = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in input)
                {
                    chemicalElements.Add(element);    
                }
            }

            foreach (var element in chemicalElements)
            {
                Console.Write(element + " ");
            }
        }
    }
}