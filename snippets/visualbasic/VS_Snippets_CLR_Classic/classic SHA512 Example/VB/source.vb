Imports System.Data
Imports System.ComponentModel
Imports System.Security.Cryptography

Public Module Sample
    Private DATA_SIZE As Integer = 1024

    Public Sub Main()
' <Snippet1>
Dim data(DATA_SIZE) As Byte
Dim result() As Byte

Using sha512 As SHA512 = SHA512.Create()
    result = sha512.ComputeHash(data)
End Using
' </Snippet1>
    End Sub
End Module
