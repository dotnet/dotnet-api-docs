'<snippet1>
Imports System
Imports System.IO
Imports System.IO.Compression

Public Class FileCompressionModeExample
    Private Const Message As String = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
    Private Const OriginalFileName As String = "original.txt"
    Private Const CompressedFileName As String = "compressed.gz"
    Private Const DecompressedFileName As String = "decompressed.txt"

    Public Shared Sub Main()
        CreateFileToCompress()
        CompressFile()
        DecompressFile()
        PrintResults()
        DeleteFiles()

        ' Output:
        '   The original file 'original.txt' weighs 445 bytes. Contents: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."

        '   The compressed file 'compressed.gz' weighs 283 bytes.

        '   The decompressed file 'decompressed.txt' weighs 445 bytes. Contents: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
    End Sub

    Private Shared Sub CreateFileToCompress()
        File.WriteAllText(OriginalFileName, Message)
    End Sub

    Private Shared Sub CompressFile()
        Using originalFileStream As FileStream = File.Open(OriginalFileName, FileMode.Open)
            Using compressedFileStream As FileStream = File.Create(CompressedFileName)
                Using compressor = New GZipStream(compressedFileStream, CompressionMode.Compress)
                    originalFileStream.CopyTo(compressor)
                End Using
            End Using
        End Using
    End Sub

    Private Shared Sub DecompressFile()
        Using compressedFileStream As FileStream = File.Open(CompressedFileName, FileMode.Open)
            Using outputFileStream As FileStream = File.Create(DecompressedFileName)
                Using decompressor = New GZipStream(compressedFileStream, CompressionMode.Decompress)
                    decompressor.CopyTo(outputFileStream)
                End Using
            End Using
        End Using
    End Sub

    Private Shared Sub PrintResults()
        Dim originalSize As Long = New FileInfo(OriginalFileName).Length
        Dim compressedSize As Long = New FileInfo(CompressedFileName).Length
        Dim decompressedSize As Long = New FileInfo(DecompressedFileName).Length

        Console.WriteLine($"The original file '{OriginalFileName}' weighs {originalSize} bytes. Contents: ""{File.ReadAllText(OriginalFileName)}""")
        Console.WriteLine($"The compressed file '{CompressedFileName}' weighs {compressedSize} bytes.")
        Console.WriteLine($"The decompressed file '{DecompressedFileName}' weighs {decompressedSize} bytes. Contents: ""{File.ReadAllText(DecompressedFileName)}""")
    End Sub

    Private Shared Sub DeleteFiles()
        File.Delete(OriginalFileName)
        File.Delete(CompressedFileName)
        File.Delete(DecompressedFileName)
    End Sub
End Class
'</snippet1>
