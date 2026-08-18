using System;
using System.IO;
using System.IO.Enumeration;

FileSystemEnumerable<string> enumeration = new(
    directory: Path.GetTempPath(), // Search the Temp directory.
    transform: (ref FileSystemEntry entry) => entry.ToFullPath(), // Map FileSystemEntry to string (see FileSystemEnumerable generic argument).
    options: new()
    {
        RecurseSubdirectories = true
    })
{
    // The following predicate filters the file entries.
    ShouldIncludePredicate = (ref FileSystemEntry entry) => !entry.IsDirectory && Path.GetExtension(entry.ToFullPath()) == ".tmp"
};

// Print all ".tmp" files from the Temp directory.
foreach (string filePath in enumeration)
{
    Console.WriteLine(filePath);
}
