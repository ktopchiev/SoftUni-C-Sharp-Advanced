using System.IO;
using System.IO.Compression;
 
namespace ZipArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipFile = @"..\..\..\my.zip";
            var file = "fileForZip.png";
 
            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}