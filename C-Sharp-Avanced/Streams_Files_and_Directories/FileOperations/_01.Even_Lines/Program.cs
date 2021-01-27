using System;
using System.IO;
using System.Linq;

namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"../../../text.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                var lineCounter = 0;
                char[] chars = {'-', ',', '.', '!', '?'};
                
                while (line != null)
                {
                    if (lineCounter % 2 == 0)
                    {
                        foreach (var chr in chars)
                        {
                            if (line.Contains(chr))
                            {
                                line = line.Replace(chr, '@');
                            }
                        }

                        string[] words = line.Split(" ");
                        Console.WriteLine(string.Join(" ", words.Reverse()));
                    }

                    line = reader.ReadLine();
                    lineCounter++;
                }
            }
        }
    }
}