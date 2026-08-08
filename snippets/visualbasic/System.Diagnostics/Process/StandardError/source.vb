' System.Diagnostics.Process.StandardError
'
' The following example demonstrates property 'StandardError' of
' 'Process' class.

' It starts a process(net.exe) which writes an error message on to the standard
' error when a bad network path is given. This program gets 'StandardError' of
' net.exe process and reads output from its stream reader.*/

Imports System.Diagnostics
Imports System.ComponentModel

Namespace Process_StandardError

    Class Class1

        Shared Sub Main(args() As String)
            If args.Length < 1 Then
                Console.WriteLine(ControlChars.Newline +
                    "This requires a machine name as a parameter which is not on the network.")
                Console.WriteLine(ControlChars.Newline + "Usage:")
                Console.WriteLine("Process_StandardError <\\machine name>")
            Else
                GetStandardError(args)
            End If
            Return
        End Sub

        Public Shared Sub GetStandardError(args() As String)
            ' <Snippet1>
            Using myProcess As New Process()
                Dim myProcessStartInfo As New ProcessStartInfo("net ", "use " + args(0))

                myProcessStartInfo.UseShellExecute = False
                myProcessStartInfo.RedirectStandardError = True
                myProcess.StartInfo = myProcessStartInfo
                myProcess.Start()

                ' Read the standard error of net.exe and write it on to console.
                Console.WriteLine(myProcess.StandardError.ReadLine())
            End Using
            ' </Snippet1>
        End Sub
    End Class
End Namespace 'Process_StandardError
