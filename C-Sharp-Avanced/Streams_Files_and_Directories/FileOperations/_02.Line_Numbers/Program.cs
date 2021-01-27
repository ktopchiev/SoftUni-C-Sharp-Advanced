using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines(@"../../../input.txt");
            char[] punctuationMarks = {'-', ',', '.', '!', '\'', '?' };
            int lineNum = 1;
            int punctuationMarksCount = 0;
            int whitespaces = 0;

            foreach (var line in text)
            {
                foreach (var ch in punctuationMarks)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == ch)
                        {
                            punctuationMarksCount++;
                        }
                    }
                }
                
                whitespaces = line.Count(x => x == ' ');
                int lettersCount = line.Length - punctuationMarksCount - whitespaces;
                File.AppendAllText("../../../output.txt", $"Line {lineNum}:{line} ({lettersCount})({punctuationMarksCount})\n");
                punctuationMarksCount = 0;
                lineNum++;
            }
        }
    }
}