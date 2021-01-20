using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<double, int> numsCounts = new Dictionary<double, int>();
            
            for (int i = 0; i < n; i++)
            {
               double input = double.Parse(Console.ReadLine());

               if (!numsCounts.ContainsKey(input))
               {
                   numsCounts.Add(input, 1);
               }
               else
               {
                   numsCounts[input]++;
               }
            }

            foreach (var pair in numsCounts)
            {
                int value = pair.Value;

                if (value % 2 == 0)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}