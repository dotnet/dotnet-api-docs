' Visual Basic .NET Document
Option Strict On

' <Snippet7>

Module Example
    Public Async Sub Main()
        Await Task.Factory.StartNew(
            Sub()
                ' Just loop.
                Dim counter As Integer = 0
                For counter = 0 To 1000000
                Next
                Console.WriteLine("Finished {0} loop iterations", counter)
            End Sub)
    End Sub
End Module
' This example displays the following output:
'     Finished 1000001 loop iterations
' </Snippet7>
