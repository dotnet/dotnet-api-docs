using System;
using System.Diagnostics;
using System.IO;

// <Snippet1>
// Get the file version for Notepad.
FileVersionInfo fileVersionInfo =
    FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "Notepad.exe"));

// Display the IsSpecialBuild property.
Console.WriteLine($"File is a special build: {fileVersionInfo.IsSpecialBuild}");
// </Snippet1>
