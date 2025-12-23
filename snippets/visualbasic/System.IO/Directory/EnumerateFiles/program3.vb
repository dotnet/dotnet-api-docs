' <Snippet1>
Imports System.IO

Partial Class Example1
    Shared Sub EnumerationOptionsExample()

        Dim sourceDirectory As String = "C:\current"
        Dim archiveDirectory As String = "C:\archive"

        Dim options As New EnumerationOptions() With {
            .MatchCasing = MatchCasing.CaseInsensitive,
            .MatchType = MatchType.Simple,
            .RecurseSubdirectories = True
        }

        Try
            Dim txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt", options)

            For Each currentFile As String In txtFiles
                Dim fileName = currentFile.Substring(sourceDirectory.Length + 1)
                Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName))
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub
End Class
' </Snippet1>
