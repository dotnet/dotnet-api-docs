//<snippet1>
using System;
using System.IO;
using System.IO.Compression;

public static class FileCompressDecompressCompressionModeExample
{
    private const string OriginalFileName = "original.txt";
    private const string CompressedFileName = "compressed.dfl";
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
            The original file 'original.txt' weighs 55 bytes. Contents: "This is the content saved inside the original.txt file."
            The compressed file 'compressed.dfl' weighs 52 bytes.
            The decompressed file 'decompressed.txt' weighs 55 bytes. Contents: "This is the content saved inside the original.txt file."
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
        using var deflateStream = new DeflateStream(compressedFileStream, CompressionMode.Compress);
        originalFileStream.CopyTo(deflateStream);
    }

    private static void DecompressFile()
    {
        using FileStream compressedFileStream = File.Open(CompressedFileName, FileMode.Open);
        using FileStream outputFileStream = File.Create(DecompressedFileName);
        using var deflateStream = new DeflateStream(compressedFileStream, CompressionMode.Decompress);
        deflateStream.CopyTo(outputFileStream);
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
