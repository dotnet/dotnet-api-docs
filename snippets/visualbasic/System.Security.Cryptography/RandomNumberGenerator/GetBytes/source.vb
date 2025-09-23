Imports System.Data
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Public Shared Sub Main()
' <Snippet1>
 Dim random() As Byte = New Byte(100) {}
        
 Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
    rng.GetBytes(random) ' bytes in random are now random
 End Using
' </Snippet1>
    End Sub
End Class
