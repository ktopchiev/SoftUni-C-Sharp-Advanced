using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating new streamreader and put him path for location of input file
            StreamReader reader = new StreamReader(@"../../../input.txt");

            using (reader)
            {
                //Store every read line in string variable
                string line = reader.ReadLine();

                int counter = 0;
                
                //Open new stream writer with path to output file
                using (var writer = new StreamWriter(@"../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            //Write in output.txt file
                            writer.WriteLine(line);
                        }
                        
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}