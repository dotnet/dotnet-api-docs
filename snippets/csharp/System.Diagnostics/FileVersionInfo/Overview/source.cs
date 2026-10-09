// <Snippet1>
using System;
using System.Diagnostics;
using System.IO;

// Get the file version for Notepad.
FileVersionInfo fileVersionInfo =
    FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "Notepad.exe"));

// Display the file name and version number.
Console.WriteLine($"File: {fileVersionInfo.FileDescription}{Environment.NewLine}Version number: {fileVersionInfo.FileVersion}");
// </Snippet1>
