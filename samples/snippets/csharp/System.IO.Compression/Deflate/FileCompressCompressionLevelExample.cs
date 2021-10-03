//<snippet1>
using System;
using System.IO;
using System.IO.Compression;

public static class FileCompressCompressionLevelExample
{
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
            The original file 'original.txt' weighs 55 bytes. Contents: "This is the content saved inside the original.txt file."
            The compressed file 'compressed.dfl' weighs 54 bytes.
         */
    }

    private static void CreateFileToCompress()
    {
        using var writer = new StreamWriter(OriginalFileName);
        writer.Write($"This is the content saved inside the {OriginalFileName} file.");
    }

    private static void CompressFile()
    {
        using FileStream originalFileStream = File.Open(OriginalFileName, FileMode.Open);
        using FileStream compressedFileStream = File.Create(CompressedFileName);
        using var deflateStream = new DeflateStream(compressedFileStream, CompressionLevel.Fastest);
        originalFileStream.CopyTo(deflateStream);
    }

    private static void PrintResults()
    {
        long originalSize = new FileInfo(OriginalFileName).Length;
        long compressedSize = new FileInfo(CompressedFileName).Length;
        Console.WriteLine($"The original file '{OriginalFileName}' weighs {originalSize} bytes. Contents: \"{File.ReadAllText(OriginalFileName)}\"");
        Console.WriteLine($"The compressed file '{CompressedFileName}' weighs {compressedSize} bytes.");
    }

    private static void DeleteFiles()
    {
        File.Delete(OriginalFileName);
        File.Delete(CompressedFileName);
    }
}
//</snippet1>
