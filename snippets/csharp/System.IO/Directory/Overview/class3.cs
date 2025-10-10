// <snippet11>
using System;
using System.IO;
using System.Linq;


partial class Program
{
    static void EnumerateFilesExample()
    {
        string archiveDirectory = @"C:\archive";

        var files = from retrievedFile in Directory.EnumerateFiles(archiveDirectory, "*.txt", SearchOption.AllDirectories)
                    from line in File.ReadLines(retrievedFile)
                    where line.Contains("Example")
                    select new
                    {
                        File = retrievedFile,
                        Line = line
                    };

        foreach (var f in files)
        {
            Console.WriteLine("{0} contains {1}", f.File, f.Line);
        }

        Console.WriteLine("{0} lines found.", files.Count().ToString());
    }
}
// </snippet11>
