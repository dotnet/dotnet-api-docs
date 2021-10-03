'<snippet1>
Imports System.IO
Imports System.IO.Compression

Module FileCompressCompressionLevelExample
    Private Const OriginalFileName As String = "original.txt"
    Private Const CompressedFileName As String = "compressed.dfl"

    Sub Main()
        CreateFileToCompress()
        CompressFile()
        PrintResults()
        DeleteFiles()

        'Output:
        '   The original file 'original.txt' weighs 55 bytes. Contents: "This is the content saved inside the original.txt file."
        '   The compressed file 'compressed.dfl' weighs 54 bytes.
    End Sub

    Private Sub CreateFileToCompress()
        Using writer = New StreamWriter(OriginalFileName)
            writer.Write($"This is the content saved inside the {OriginalFileName} file.")
        End Using
    End Sub

    Private Sub CompressFile()
        Using originalFileStream As FileStream = File.Open(OriginalFileName, FileMode.Open)
            Using compressedFileStream As FileStream = File.Create(CompressedFileName)
                Using deflateStream = New DeflateStream(compressedFileStream, CompressionLevel.Fastest)
                    originalFileStream.CopyTo(deflateStream)
                End Using
            End Using
        End Using
    End Sub

    Private Sub PrintResults()
        Dim originalSize As Long = New FileInfo(OriginalFileName).Length
        Dim compressedSize As Long = New FileInfo(CompressedFileName).Length
        Console.WriteLine($"The original file '{OriginalFileName}' weighs {originalSize} bytes. Contents: ""{File.ReadAllText(OriginalFileName)}""")
        Console.WriteLine($"The compressed file '{CompressedFileName}' weighs {compressedSize} bytes.")
    End Sub

    Private Sub DeleteFiles()
        File.Delete(OriginalFileName)
        File.Delete(CompressedFileName)
    End Sub
End Module
'</snippet1>
