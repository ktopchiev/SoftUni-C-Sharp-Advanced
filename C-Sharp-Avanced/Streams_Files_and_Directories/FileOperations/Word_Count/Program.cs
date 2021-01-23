using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
    Write a program that reads a list of words from the file words.txt and finds how many times each of the words is
    contained in another file text.txt. Matching should be case-insensitive.
    The result should be written to another text file. Sort the words by frequency in descending order.*/

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../words.txt";
            string pathToText = @"../../../text.txt";
            string pathToOutputTxt = @"../../../output.txt";
            
            StreamReader textReader = new StreamReader(pathToText);
            StreamReader wordsReader = new StreamReader(path);
            StreamWriter writer = new StreamWriter(pathToOutputTxt);
            
            using (wordsReader)
            {
                string[] words = wordsReader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                Dictionary<string, int> wordoMeter = new Dictionary<string, int>();

                foreach (var word in words)
                {
                    textReader = new StreamReader(pathToText);
                    
                    using (textReader)
                    {
                        string textLine = textReader.ReadLine();
                        
                        while (textLine != null)
                        {
                            textLine = textLine.ToLower();

                            int wordCounter = 0;

                            if (textLine.Contains(word))
                            {
                                wordCounter++;
                                if (wordoMeter.ContainsKey(word))
                                {
                                    wordoMeter[word]++;
                                }
                                else
                                {
                                    wordoMeter.Add(word, wordCounter);
                                }
                            }

                            textLine = textReader.ReadLine();
                            
                            if (textLine == null)
                            {
                                textReader.Close();
                            }
                        }
                    }
                }

                using (writer)
                {
                    foreach (var pair in wordoMeter.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{pair.Key} - {pair.Value}");
                    }
                }
            }
        }
    }
}