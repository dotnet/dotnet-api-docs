Imports System.Data
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Public Sub Method()
' <Snippet1>
 Dim random() As Byte = New Byte(100) {}

 Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
     rng.GetNonZeroBytes(random) ' bytes in random are now random and none are zero
 End Using
' </Snippet1>
    End Sub
End Class
