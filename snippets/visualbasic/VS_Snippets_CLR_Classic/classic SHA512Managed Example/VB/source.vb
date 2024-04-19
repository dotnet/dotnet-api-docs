Imports System.Data
Imports System.ComponentModel
Imports System.Security.Cryptography

Public Class Sample
    Protected DATA_SIZE As Integer = 1024

    Protected Sub Method()
' <Snippet1>
Dim data(DATA_SIZE) As Byte
Dim result() As Byte

Using shaM As New SHA512Managed()
    result = shaM.ComputeHash(data)
End Using
' </Snippet1>
    End Sub
End Class
