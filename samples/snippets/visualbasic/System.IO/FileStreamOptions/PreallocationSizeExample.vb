'<snippet1>
Imports System.IO

Module PreallocationSizeExample
    Private Const SourcePath As String = "source.txt"
    Private Const DestinationPath As String = "destination.txt"

    Sub Main()
        CheckFiles()
        PreallocateAndCopy()

        'Destination contents should be the same as source contents
        Console.WriteLine(File.ReadAllText(DestinationPath))
    End Sub

    Private Sub PreallocateAndCopy()
        Dim openForReading = New FileStreamOptions With {
            .Mode = FileMode.Open
        }
        Using source = New FileStream(SourcePath, openForReading)

            Dim createForWriting = New FileStreamOptions With {
                .Mode = FileMode.CreateNew,
                .Access = FileAccess.Write,
                .PreallocationSize = source.Length ' specify size up-front
            }

            Using destination = New FileStream(DestinationPath, createForWriting)
                source.CopyTo(destination)
            End Using

        End Using

    End Sub

    Private Sub CheckFiles()
        If Not File.Exists(SourcePath) Then
            File.WriteAllText(SourcePath, "Hello world!")
        End If

        If File.Exists(DestinationPath) Then
            File.Delete(DestinationPath)
        End If
    End Sub

End Module
'</snippet1>
