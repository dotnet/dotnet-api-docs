'<snippet1>
Imports System.IO

Module PreallocationSizeExample

    Sub Main()

        Dim destinationPath As String = "destination.dll"
        Dim openForReading = New FileStreamOptions With {
            .Mode = FileMode.Open
        }

        Using source = New FileStream(GetType(PreallocationSizeExample).Assembly.Location, openForReading)

            Dim createForWriting = New FileStreamOptions With {
                .Mode = FileMode.CreateNew,
                .Access = FileAccess.Write,
                .PreallocationSize = source.Length ' specify size up-front
            }

            Using destination = New FileStream(destinationPath, createForWriting)
                source.CopyTo(destination) ' copies the contents of the assembly file into the destination file
            End Using

        End Using

    End Sub

End Module
'</snippet1>
