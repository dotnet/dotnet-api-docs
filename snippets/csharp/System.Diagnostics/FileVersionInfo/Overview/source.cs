// <Snippet1>

using System;
using System.IO;
using System.Diagnostics;

class Class1
{
    public static void Main(string[] args)
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "Notepad.exe"));

        // Print the file name and version number.
        Console.WriteLine("File: " + myFileVersionInfo.FileDescription + Environment.NewLine +
           "Version number: " + myFileVersionInfo.FileVersion);
    }
}
// </Snippet1>
