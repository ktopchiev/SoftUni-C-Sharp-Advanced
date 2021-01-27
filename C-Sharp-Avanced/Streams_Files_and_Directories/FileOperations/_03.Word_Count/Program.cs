using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"../../../text.txt");
            var text = input.Select(x => x.ToLowerInvariant()).ToArray();
            
            string[] words = File.ReadAllLines(@"../../../words.txt");

            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();
            
            foreach (var word in words)
            {
                wordsCounts.Add(word, 0);

                foreach (var line in text)
                {
                    var count = Regex.Matches(line, $"\\b{word}\\b").Count;
                    wordsCounts[word] += count;
                }
            }

            string actualResultPath = @"../../../actualResults.txt";
            string expectedResultPath = @"../../../expectedResults.txt";

            foreach (var pair in wordsCounts)
            {
                File.AppendAllText(actualResultPath, $"{pair.Key} - {pair.Value}\n");
            }

            foreach (var pair in wordsCounts.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(expectedResultPath, $"{pair.Key} - {pair.Value}\n");
            }
        }
    }
}