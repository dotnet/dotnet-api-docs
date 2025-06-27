using System;
using System.Diagnostics;

public class Example2
{
    public static void Main()
    {
        var p = new Process();
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.FileName = "Write500Lines.exe";
        p.Start();

        // To avoid deadlocks, always read the output stream first and then wait.  
        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();

        Console.WriteLine($"The last 50 characters in the output stream are:\n'{output.Substring(output.Length - 50)}'");
    }
}
// The example displays the following output:
//      Successfully wrote 500 lines.
//
//      The last 50 characters in the output stream are:
//      'ritten: 99,80%
//      Line 500 of 500 written: 100,00%
//      '
