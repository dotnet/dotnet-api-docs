﻿//<snippet00>
using System;
using System.IO;
using System.Text;

class Test
{
    public static void Main()
    {
        string path = @"c:\temp\MyTest.txt";

        // This text is added only once to the file.
        if (!File.Exists(path))
        {
            // Create a file to write to.
            string[] createText = { "Hello", "And", "Welcome" };
            File.WriteAllLines(path, createText, Encoding.UTF8);
        }

        // This text is always added, making the file longer over time
        // if it is not deleted.
        string appendText = "This is extra text" + Environment.NewLine;
        File.AppendAllText(path, appendText, Encoding.UTF8);

        // Open the file to read from.
        string[] readText = File.ReadAllLines(path, Encoding.UTF8);
        foreach (string s in readText)
        {
            Console.WriteLine(s);
        }
    }
}
//</snippet00>