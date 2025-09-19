﻿'<Snippet1>
Imports System.Threading
Imports System.Security.Permissions
Imports System.Security.Principal
Imports System.Diagnostics



Class ProcessDemo

    Public Shared Sub Main()
        Dim notePad As Process = Process.Start("notepad")
        Console.WriteLine("Started notepad process Id = " + notePad.Id.ToString())
        Console.WriteLine("All instances of notepad:")
        ' Get Process objects for all running instances on notepad.
        Dim localByName As Process() = Process.GetProcessesByName("notepad")
        Dim i As Integer = localByName.Length
        While i > 0
            ' You can use the process Id to pass to other applications or to
            ' reference that particular instance of the application.
            Console.WriteLine(localByName((i - 1)).Id.ToString())
            i -= 1
        End While

        i = localByName.Length
        While i > 0
            Console.WriteLine("Enter a process Id to kill the process")
            Dim id As String = Console.ReadLine()
            If id = String.Empty Then
                Exit While
            End If
            Try
                Using chosen As Process = Process.GetProcessById(Int32.Parse(id))
                    If chosen.ProcessName = "notepad" Then
                        chosen.Kill()
                        chosen.WaitForExit()
                    End If
                End Using
            Catch e As Exception
                Console.WriteLine("Incorrect entry.")
                GoTo ContinueWhile1
            End Try
            i -= 1
ContinueWhile1:
        End While

    End Sub
End Class
'</Snippet1>
