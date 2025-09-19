Imports System.Data
Imports System.ComponentModel
Imports System.Security.Cryptography

Public Module Sample
    Private DATA_SIZE As Integer = 1024

    Public Sub Main()
' <Snippet1>
Dim data(DATA_SIZE) As Byte
Dim result() As Byte
Using shaM As New SHA384Managed()
    result = shaM.ComputeHash(data)
End Using
' </Snippet1>
    End Sub
End Module
