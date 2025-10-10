// <Snippet1>
using System;
using System.IO;

partial class Example1
{
    static void EnumerationOptionsExample()
    {
        string sourceDirectory = @"C:\current";
        string archiveDirectory = @"C:\archive";

        var options = new EnumerationOptions
        {
            MatchCasing = MatchCasing.CaseInsensitive,
            MatchType = MatchType.Simple,
            RecurseSubdirectories = true
        };

        try
        {
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt", options);

            foreach (string currentFile in txtFiles)
            {
                string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
// <Snippet1>
