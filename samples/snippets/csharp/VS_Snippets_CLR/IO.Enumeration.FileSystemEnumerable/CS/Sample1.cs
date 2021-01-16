using System;
using System.IO;
using System.IO.Enumeration;

namespace MyNamespace
{
    public class MyClassCS
    {
        static void Main()
        {
            /*
                Create the following file tree:
                    C:\Users\username\AppData\Local\Temp\testfolder\file1.txt
                    C:\Users\username\AppData\Local\Temp\testfolder\file2.mp3
                    C:\Users\username\AppData\Local\Temp\testfolder\testsubfolder\file3.txt
            */

            string pathDir = Path.Combine(Path.GetTempPath(), "testfolder");
            string pathFile1 = Path.Combine(pathDir, "file1.txt");
            string pathFile2 = Path.Combine(pathDir, "file2.mp3");

            Directory.CreateDirectory(pathDir);
            File.CreateText(pathFile1).Dispose();
            File.CreateText(pathFile2).Dispose();

            string pathSubdir = Path.Combine(pathDir, "testsubfolder");
            string pathFile3 = Path.Combine(pathSubdir, "FILE3.TXT");

            Directory.CreateDirectory(pathSubdir);
            File.CreateText(pathFile3).Dispose();

            // Create the enumeration object

            var options = new EnumerationOptions()
            {
                RecurseSubdirectories = true
            };

            static string myTransform(ref FileSystemEntry entry) =>
               entry.ToFullPath();

            static bool myPredicate(ref FileSystemEntry entry) =>
               !entry.IsDirectory &&
               Path.GetExtension(entry.ToFullPath()).Equals(".txt", StringComparison.InvariantCultureIgnoreCase);

            var enumeration = new FileSystemEnumerable<string>(pathDir, myTransform, options)
            {
                ShouldIncludePredicate = myPredicate
            };

            // Print only txt files

            foreach (string filePath in enumeration)
            {
                Console.WriteLine(filePath);
            }

            Directory.Delete(pathDir, recursive: true);

            /*
                Output:
                    C:\Users\username\AppData\Local\Temp\testfolder\file1.txt
                    C:\Users\username\AppData\Local\Temp\testfolder\testsubfolder\FILE3.TXT
            */
        }
    }

}
