using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace _05.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);

            Dictionary<string, Dictionary<string, double>> filesData =
                new Dictionary<string, Dictionary<string, double>>();
            
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileExtension = fileInfo.Extension;
                double fileLength = fileInfo.Length;
                double size = fileLength / 1024;
                
                if (!filesData.ContainsKey(fileExtension))
                {
                    filesData.Add(fileExtension, new Dictionary<string, double>());
                    filesData[fileExtension].Add(fileInfo.Name, size);
                }
                else
                {
                    filesData[fileExtension].Add(fileInfo.Name, size);
                }
            }

            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/report.txt";
            
            FileStream fileStream = new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite);
            fileStream.Close();
            
            foreach (var pair in filesData
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x))
            {
                string extension = pair.Key;
                File.AppendAllText(path, $"{extension}\n");
                var filesValues = pair.Value;
                
                foreach (var file in filesValues )
                {
                    File.AppendAllText(path, $"--{file.Key} - {file.Value}kb\n"); 
                }
            }
        }
    }
}