﻿'<snippet1>
Imports System.IO

Public Class MoveToTest

    Public Shared Sub Main()
        ' Make a reference to a directory.
        Dim di As New DirectoryInfo("TempDir")
        ' Create the directory only if it does not already exist.
        If di.Exists = False Then
            di.Create()
        End If

        ' Create a subdirectory in the directory just created.
        Dim dis As DirectoryInfo = di.CreateSubdirectory("SubDir")

        ' Get a reference to the parent directory of the subdirectory you just made.
        Dim parentDir As DirectoryInfo = dis.Parent
        Console.WriteLine("The parent directory of '{0}' is '{1}'", dis.Name, parentDir.Name)

        ' Delete the parent directory.
        di.Delete(True)
    End Sub
End Class
'</snippet1>