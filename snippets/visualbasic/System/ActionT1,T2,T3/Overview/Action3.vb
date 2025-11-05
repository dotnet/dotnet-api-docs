' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module TestAction3
    Public Sub RunIt()
        Dim ordinals() As String = {"First", "Second", "Third", "Fourth", "Fifth"}
        Dim copiedOrdinals(ordinals.Length - 1) As String
        Dim copyOperation As Action(Of String(), String(), Integer) = AddressOf CopyStrings
        copyOperation(ordinals, copiedOrdinals, 3)
        For Each ordinal As String In copiedOrdinals
            If String.IsNullOrEmpty(ordinal) Then
                Console.WriteLine("<None>")
            Else
                Console.WriteLine(ordinal)
            End If
        Next
    End Sub

    Private Sub CopyStrings(source() As String, target() As String, startPos As Integer)
        If source.Length <> target.Length Then
            Throw New IndexOutOfRangeException("The source and target arrays must have the same number of elements.")
        End If
        For ctr As Integer = startPos To source.Length - 1
            target(ctr) = source(ctr)
        Next
    End Sub
End Module
' </Snippet2>

