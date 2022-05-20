'<snippet1>
Imports System.IO
Imports System.IO.Compression

Module FileCompressionLevelExample
    Private Const Message As String = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
    Private Const OriginalFileName As String = "original.txt"
    Private Const CompressedFileName As String = "compressed.dfl"

    Sub Main()
        CreateFileToCompress()
        CompressFile()
        PrintResults()
        DeleteFiles()

        'Output:
        '   The original file 'original.txt' weighs 445 bytes.
        '   The compressed file 'compressed.dfl' weighs 259 bytes.
    End Sub

    Private Sub CreateFileToCompress()
        File.WriteAllText(OriginalFileName, Message)
    End Sub

    Private Sub CompressFile()
        Using originalFileStream As FileStream = File.Open(OriginalFileName, FileMode.Open)
            Using compressedFileStream As FileStream = File.Create(CompressedFileName)
                Using compressor = New DeflateStream(compressedFileStream, CompressionLevel.Fastest)
                    originalFileStream.CopyTo(compressor)
                End Using
            End Using
        End Using
    End Sub

    Private Sub PrintResults()
        Dim originalSize As Long = New FileInfo(OriginalFileName).Length
        Dim compressedSize As Long = New FileInfo(CompressedFileName).Length

        Console.WriteLine($"The original file '{OriginalFileName}' weighs {originalSize} bytes.")
        Console.WriteLine($"The compressed file '{CompressedFileName}' weighs {compressedSize} bytes.")
    End Sub

    Private Sub DeleteFiles()
        File.Delete(OriginalFileName)
        File.Delete(CompressedFileName)
    End Sub
End Module
'</snippet1>
