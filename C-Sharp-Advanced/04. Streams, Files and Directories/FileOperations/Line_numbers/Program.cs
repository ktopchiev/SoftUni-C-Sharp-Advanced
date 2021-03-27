using System;
using System.IO;

namespace Line_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"../../../input2.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter(@"../../../output2.txt"))
                {
                    int lineNum = 1;
                    
                    while (line != null)
                    {
                        writer.WriteLine($"{lineNum}. {line}");
                        lineNum++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}