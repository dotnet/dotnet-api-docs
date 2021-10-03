//<snippet1>
using System;
using System.IO;
using System.IO.Compression;

public class FileCompressionModeExample
{
    private const string Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    private const string OriginalFileName = "original.txt";
    private const string CompressedFileName = "compressed.gz";
    private const string DecompressedFileName = "decompressed.txt";

    public static void Main()
    {
        CreateFileToCompress();
        CompressFile();
        DecompressFile();
        PrintResults();
        DeleteFiles();

        /*
         Output:

            The original file 'original.txt' weighs 445 bytes. Contents: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."

            The compressed file 'compressed.gz' weighs 283 bytes.

            The decompressed file 'decompressed.txt' weighs 445 bytes. Contents: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
         */
    }

    private static void CreateFileToCompress() => File.WriteAllText(OriginalFileName, Message);

    private static void CompressFile()
    {
        using FileStream originalFileStream = File.Open(OriginalFileName, FileMode.Open);
        using FileStream compressedFileStream = File.Create(CompressedFileName);
        using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
        originalFileStream.CopyTo(compressor);
    }

    private static void DecompressFile()
    {
        using FileStream compressedFileStream = File.Open(CompressedFileName, FileMode.Open);
        using FileStream outputFileStream = File.Create(DecompressedFileName);
        using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
        decompressor.CopyTo(outputFileStream);
    }

    private static void PrintResults()
    {
        long originalSize = new FileInfo(OriginalFileName).Length;
        long compressedSize = new FileInfo(CompressedFileName).Length;
        long decompressedSize = new FileInfo(DecompressedFileName).Length;

        Console.WriteLine($"The original file '{OriginalFileName}' weighs {originalSize} bytes. Contents: \"{File.ReadAllText(OriginalFileName)}\"");
        Console.WriteLine($"The compressed file '{CompressedFileName}' weighs {compressedSize} bytes.");
        Console.WriteLine($"The decompressed file '{DecompressedFileName}' weighs {decompressedSize} bytes. Contents: \"{File.ReadAllText(DecompressedFileName)}\"");
    }

    private static void DeleteFiles()
    {
        File.Delete(OriginalFileName);
        File.Delete(CompressedFileName);
        File.Delete(DecompressedFileName);
    }
}
//</snippet1>
