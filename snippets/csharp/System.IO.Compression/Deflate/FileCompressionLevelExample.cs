//<snippet1>
using System;
using System.IO;
using System.IO.Compression;

public static class FileCompressionLevelExample
{
    private const string Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    private const string OriginalFileName = "original.txt";
    private const string CompressedFileName = "compressed.dfl";

    public static void Main()
    {
        CreateFileToCompress();
        CompressFile();
        PrintResults();
        DeleteFiles();

        /*
         Output:
            The original file 'original.txt' weighs 445 bytes.
            The compressed file 'compressed.dfl' weighs 259 bytes.
         */
    }

    private static void CreateFileToCompress() => File.WriteAllText(OriginalFileName, Message);

    private static void CompressFile()
    {
        using FileStream originalFileStream = File.Open(OriginalFileName, FileMode.Open);
        using FileStream compressedFileStream = File.Create(CompressedFileName);
        using var compressor = new DeflateStream(compressedFileStream, CompressionLevel.Fastest);
        originalFileStream.CopyTo(compressor);
    }

    private static void PrintResults()
    {
        long originalSize = new FileInfo(OriginalFileName).Length;
        long compressedSize = new FileInfo(CompressedFileName).Length;
        
        Console.WriteLine($"The original file '{OriginalFileName}' weighs {originalSize} bytes.");
        Console.WriteLine($"The compressed file '{CompressedFileName}' weighs {compressedSize} bytes.");
    }

    private static void DeleteFiles()
    {
        File.Delete(OriginalFileName);
        File.Delete(CompressedFileName);
    }
}
//</snippet1>
