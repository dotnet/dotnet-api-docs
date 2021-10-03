'<snippet1>
Imports System.IO
Imports System.IO.Compression

Module FileCompressDecompressCompressionModeExample
    Private Const OriginalFileName As String = "original.txt"
    Private Const CompressedFileName As String = "compressed.dfl"
    Private Const DecompressedFileName As String = "decompressed.txt"

    Sub Main()
        CreateFileToCompress()
        CompressFile()
        DecompressFile()
        PrintResults()
        DeleteFiles()

        'Output:
        '   The original file 'original.txt' weighs 55 bytes. Contents: "This is the content saved inside the original.txt file."
        '   The compressed file 'compressed.dfl' weighs 52 bytes.
        '   The decompressed file 'decompressed.txt' weighs 55 bytes. Contents: "This is the content saved inside the original.txt file."
    End Sub

    Private Sub CreateFileToCompress()
        Using writer = New StreamWriter(OriginalFileName)
            writer.Write($"This is the content saved inside the {OriginalFileName} file.")
        End Using
    End Sub

    Private Sub CompressFile()
        Using originalFileStream As FileStream = File.Open(OriginalFileName, FileMode.Open)
            Using compressedFileStream As FileStream = File.Create(CompressedFileName)
                Using deflateStream = New DeflateStream(compressedFileStream, CompressionMode.Compress)
                    originalFileStream.CopyTo(deflateStream)
                End Using
            End Using
        End Using
    End Sub

    Private Sub DecompressFile()
        Using compressedFileStream As FileStream = File.Open(CompressedFileName, FileMode.Open)
            Using outputFileStream As FileStream = File.Create(DecompressedFileName)
                Using deflateStream = New DeflateStream(compressedFileStream, CompressionMode.Decompress)
                    deflateStream.CopyTo(outputFileStream)
                End Using
            End Using
        End Using
    End Sub

    Private Sub PrintResults()
        Dim originalSize As Long = New FileInfo(OriginalFileName).Length
        Dim compressedSize As Long = New FileInfo(CompressedFileName).Length
        Dim decompressedSize As Long = New FileInfo(DecompressedFileName).Length
        Console.WriteLine($"The original file '{OriginalFileName}' weighs {originalSize} bytes. Contents: ""{File.ReadAllText(OriginalFileName)}""")
        Console.WriteLine($"The compressed file '{CompressedFileName}' weighs {compressedSize} bytes.")
        Console.WriteLine($"The decompressed file '{DecompressedFileName}' weighs {decompressedSize} bytes. Contents: ""{File.ReadAllText(DecompressedFileName)}""")
    End Sub

    Private Sub DeleteFiles()
        File.Delete(OriginalFileName)
        File.Delete(CompressedFileName)
        File.Delete(DecompressedFileName)
    End Sub
End Module
'</snippet1>
