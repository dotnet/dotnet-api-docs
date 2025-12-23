// <snippet13>
using System;
using System.IO;

partial class Example1
{
    static void SearchOptionExample()
    {
        string sourceDirectory = @"C:\current";
        string archiveDirectory = @"C:\archive";

        try
        {
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt", SearchOption.AllDirectories);

            foreach (string currentFile in txtFiles)
            {
                string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
// </snippet13>
