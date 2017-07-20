using System;
using System.IO;
using System.Linq;

namespace FolderInfo
{
    class Program
    {
        public static StreamWriter strmW = new StreamWriter("FILES.txt");
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            DirectoryInfo dir = new DirectoryInfo(@"C:\");

            PrintFiles(dir);
            strmW.Close();
            Console.WriteLine("Done");

            Console.ReadKey();
        }
        static void PrintFiles(DirectoryInfo dir)
        {
            try
            {
                foreach (var file in dir.GetFileSystemInfos())
                { strmW.WriteLine(file.FullName); }
                foreach (var path in dir.GetDirectories()
                    .Where(d => !d.Attributes.HasFlag(FileAttributes.NotContentIndexed)))
                    PrintFiles(path);
            }
            catch(Exception ex) { }
        }
    }
}
