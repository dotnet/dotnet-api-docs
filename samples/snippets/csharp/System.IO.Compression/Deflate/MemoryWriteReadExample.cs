//<snippet1>
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

public static class MemoryWriteReadExample
{
    private const string Message = "example text to compress and decompress";
    private static readonly byte[] s_messageBytes = Encoding.ASCII.GetBytes(Message);

    public static void Main()
    {
        Console.WriteLine($"The original string length is {s_messageBytes.Length} bytes.");
        using var stream = new MemoryStream();
        CompressBytesToStream(stream);
        Console.WriteLine($"The compressed stream length is {stream.Length} bytes.");
        int decompressedLength = DecompressStreamToBytes(stream);
        Console.WriteLine($"The decompressed string length is {decompressedLength} bytes, same as the original length.");
    }

    private static void CompressBytesToStream(Stream stream)
    {
        using var compressor = new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true);
        compressor.Write(s_messageBytes, 0, s_messageBytes.Length);
    }

    private static int DecompressStreamToBytes(Stream stream)
    {
        stream.Position = 0;
        int bufferSize = 512;
        byte[] decompressedBytes = new byte[bufferSize];
        using var decompressor = new DeflateStream(stream, CompressionMode.Decompress);
        int length = decompressor.Read(decompressedBytes, 0, bufferSize);
        return length;
    }
}
//</snippet1>
