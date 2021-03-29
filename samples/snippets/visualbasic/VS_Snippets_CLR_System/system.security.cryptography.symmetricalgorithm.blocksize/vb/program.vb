'<Snippet1>
Imports System.Security.Cryptography


Class Program

    Shared Sub Main(ByVal args() As String)
        Dim aes As Aes = Aes.Create()
        Console.WriteLine("Aes ")
        Dim ks As KeySizes() = aes.LegalKeySizes
        Dim k As KeySizes
        For Each k In ks
            Console.WriteLine(vbTab + "Legal min key size = " & k.MinSize)
            Console.WriteLine(vbTab + "Legal max key size = " & k.MaxSize)
        Next k
        ks = aes.LegalBlockSizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min block size = " & k.MinSize)
            Console.WriteLine(vbTab + "Legal max block size = " & k.MaxSize)
        Next k


    End Sub
End Class
'This sample produces the following output:
'Aes
'        Legal min key size = 128
'        Legal max key size = 256
'        Legal min block size = 128
'        Legal max block size = 128
'</Snippet1>