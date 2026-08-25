using System;
using System.Diagnostics;
using System.IO;

// <Snippet1>
// Get the file version for Notepad.
FileVersionInfo fileVersionInfo =
    FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "Notepad.exe"));

// Display the LegalTrademarks property.
Console.WriteLine($"Trademarks: {fileVersionInfo.LegalTrademarks}");
// </Snippet1>
