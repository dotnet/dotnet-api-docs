// <snippet14>
using System;
using System.IO;

partial class Program
{
    static void DirectoryMoveExample()
    {
        string sourceDirectory = @"C:\source";
        string destinationDirectory = @"C:\destination";

        try
        {
            Directory.Move(sourceDirectory, destinationDirectory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
// </snippet14>
