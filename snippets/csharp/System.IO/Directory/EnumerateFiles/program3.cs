// <Snippet1>
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Set a variable to the My Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Set the options for the enumeration.
            var options = new EnumerationOptions()
            {
                IgnoreInaccessible = true,
                MatchCasing = MatchCasing.CaseInsensitive,
                MatchType = MatchType.Simple,
                RecurseSubdirectories = true
            };

            var files = from file in Directory.EnumerateFiles(docPath, "*.txt", options)
                        from line in File.ReadLines(file)
                        where line.Contains("Microsoft")
                        select new
                        {
                            File = file,
                            Line = line
                        };

            foreach (var f in files)
            {
                Console.WriteLine($"{f.File}\t{f.Line}");
            }

            Console.WriteLine($"{files.Count()} files found.");
        }
        catch (PathTooLongException pathEx)
        {
            Console.WriteLine(pathEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
// </Snippet1>
