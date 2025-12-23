' <Snippet1>
Imports System.IO
Imports System.Xml.Linq

Partial Class Example2
    Shared Sub EnumerationOptionsExample()

        Try
            ' Set a variable to the My Documents Path.
            Dim docPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            ' Set the options for the enumeration.
            Dim options As New EnumerationOptions() With {
                .IgnoreInaccessible = True,
                .MatchCasing = MatchCasing.CaseInsensitive,
                .MatchType = MatchType.Simple,
                .RecurseSubdirectories = True
            }

            Dim files = From chkFile In Directory.EnumerateFiles(docPath, "*.txt", options)
                        From line In File.ReadLines(chkFile)
                        Where line.Contains("Microsoft")
                        Select New With {
                            .curFile = chkFile,
                            .curLine = line
                        }

            For Each f In files
                Console.WriteLine($"{f.curFile}\t{f.curLine}")
            Next

            Console.WriteLine($"{files.Count} files found.")
        Catch pathEx As PathTooLongException
            Console.WriteLine(pathEx.Message)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub
End Class
' </Snippet1>
