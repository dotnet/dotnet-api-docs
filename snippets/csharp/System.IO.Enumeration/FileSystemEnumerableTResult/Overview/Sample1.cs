using System;
using System.IO;
using System.IO.Enumeration;

namespace MyNamespace
{
    public class MyClassCS
    {
        static void Main()
        {
            var enumeration = new FileSystemEnumerable<string>(
                directory: Path.GetTempPath(), // search Temp directory
                transform: (ref FileSystemEntry entry) => entry.ToFullPath(), // map FileSystemEntry to string (see FileSystemEnumerable generic argument)
                options: new EnumerationOptions()
                {
                    RecurseSubdirectories = true
                })
            {
                // The following predicate will be used to filter the file entries
                ShouldIncludePredicate = (ref FileSystemEntry entry) => !entry.IsDirectory && Path.GetExtension(entry.ToFullPath()) == ".tmp"
            };

            // Prints all ".tmp" files from Temp directory
            foreach (string filePath in enumeration)
            {
                Console.WriteLine(filePath);
            }
        }
    }

}
