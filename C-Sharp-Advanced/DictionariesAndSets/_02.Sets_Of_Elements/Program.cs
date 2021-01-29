using System;
using System.Collections.Generic;

namespace _02.Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(parameters[0]);
            int m = int.Parse(parameters[1]);

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            
            for (int i = 0; i < n + m; i++)
            {
                if (i >= n)
                {
                    int secondSetInput = int.Parse(Console.ReadLine());
                    secondSet.Add(secondSetInput);
                }
                else
                {
                    int firstSetInput = int.Parse(Console.ReadLine());
                    firstSet.Add(firstSetInput);
                }
            }

            foreach (var element1 in firstSet)
            {
                foreach (var element2 in secondSet)
                {
                    if (element1 == element2)
                    {
                        Console.Write(element1 + " ");
                    }
                }
            }
        }
    }
}