using System;
using System.Diagnostics;
using System.IO;

// <Snippet1>
// Get the file version for Notepad.
FileVersionInfo fileVersionInfo =
    FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "Notepad.exe"));

// Display the OriginalFilename property.
Console.WriteLine($"Original file name: {fileVersionInfo.OriginalFilename}");
// </Snippet1>
