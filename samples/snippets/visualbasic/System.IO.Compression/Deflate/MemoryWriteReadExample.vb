'<snippet1>
Imports System.IO
Imports System.IO.Compression
Imports System.Text

Module MemoryWriteReadExample
    Private Const Message As String = "example text to compress and decompress"
    Private ReadOnly s_messageBytes As Byte() = Encoding.ASCII.GetBytes(Message)

    Sub Main()
        Console.WriteLine($"The original string length is {s_messageBytes.Length} bytes.")

        Using stream = New MemoryStream()
            CompressBytesToStream(stream)
            Console.WriteLine($"The compressed stream length is {stream.Length} bytes.")
            Dim decompressedLength As Integer = DecompressStreamToBytes(stream)
            Console.WriteLine($"The decompressed string length is {decompressedLength} bytes, same as the original length.")
        End Using

    End Sub

    Private Sub CompressBytesToStream(ByVal stream As Stream)
        Using compressor = New DeflateStream(stream, CompressionMode.Compress, leaveOpen:=True)
            compressor.Write(s_messageBytes, 0, s_messageBytes.Length)
        End Using
    End Sub

    Private Function DecompressStreamToBytes(ByVal stream As Stream) As Integer
        stream.Position = 0
        Dim bufferSize As Integer = 512
        Dim decompressedBytes As Byte() = New Byte(bufferSize - 1) {}
        Using decompressor = New DeflateStream(stream, CompressionMode.Decompress)
            Dim length As Integer = decompressor.Read(decompressedBytes, 0, bufferSize)
            Return length
        End Using
    End Function
End Module
'</snippet1>
