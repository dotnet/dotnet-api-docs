//<snippet1>
using System;
using System.IO;

public static class PreallocationSizeExample
{
    private const string SourcePath = "source.txt";
    private const string DestinationPath = "destination.txt";

    public static void Main()
    {
        CheckFiles();
        PreallocateAndCopy();

        // Destination contents should be the same as source contents
        Console.WriteLine(File.ReadAllText(DestinationPath));
    }

    private static void PreallocateAndCopy()
    {
        var openForReading = new FileStreamOptions { Mode = FileMode.Open };
        using var source = new FileStream(SourcePath, openForReading);

        var createForWriting = new FileStreamOptions
        {
            Mode = FileMode.CreateNew,
            Access = FileAccess.Write,
            PreallocationSize = source.Length // specify size up-front
        };
        using var destination = new FileStream(DestinationPath, createForWriting);

        source.CopyTo(destination);
    }

    private static void CheckFiles()
    {
        if (!File.Exists(SourcePath))
        {
            File.WriteAllText(SourcePath, "Hello world!");
        }

        if (File.Exists(DestinationPath))
        {
            File.Delete(DestinationPath);
        }
    }
}
//</snippet1>
