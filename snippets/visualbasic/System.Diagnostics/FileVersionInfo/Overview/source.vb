' <Snippet1>
Imports System.IO
Imports System.Diagnostics



Class Class1

    Public Shared Sub Main(ByVal args() As String)
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, "Notepad.exe"))


        ' Print the file name and version number.
        Console.WriteLine("File: " + myFileVersionInfo.FileDescription + Environment.NewLine + "Version number: " + myFileVersionInfo.FileVersion)

    End Sub
End Class

' </Snippet1>
