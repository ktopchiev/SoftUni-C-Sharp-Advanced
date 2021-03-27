using System;
using System.IO;

namespace _04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream(@"../../../image-analysis.png", FileMode.Open))
            using (FileStream writeStream = new FileStream(@"../../../file2.png", FileMode.OpenOrCreate))
            {
                // create a buffer to hold the bytes 
                byte[] buffer = new Byte[1024];
                int bytesRead;
                // while the read method returns bytes
                // keep writing them to the output stream
                while ((bytesRead =
                    stream.Read(buffer, 0, 1024)) > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}