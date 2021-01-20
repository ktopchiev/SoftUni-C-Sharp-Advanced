using System;
using System.Collections.Generic;

namespace _05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputString = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> symbolsData = new SortedDictionary<char, int>();

            foreach (var symbol in inputString)
            {
                if (symbolsData.ContainsKey(symbol))
                {
                    symbolsData[symbol]++;
                }
                else
                {
                    symbolsData.Add(symbol, 1);
                }
            }

            foreach (var pair in symbolsData)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}