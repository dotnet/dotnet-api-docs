'<Snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Xml

Public Class Verify
    Public Shared Sub Main(ByVal args As String())
        Console.WriteLine("Verifying " & args(0) & "...")

        Dim trustedKey As RSA = RSA.Create()
        ' ... load trustedKey from an out-of-band source ...

        Dim xmlDocument As New XmlDocument()
        xmlDocument.PreserveWhitespace = True
        Using reader As XmlReader = XmlReader.Create(args(0))
            xmlDocument.Load(reader)
        End Using

        Dim signedXml As New SignedXml(xmlDocument)
        Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")
        signedXml.LoadXml(CType(nodeList(0), XmlElement))

        If signedXml.CheckSignature(trustedKey) Then
            Console.WriteLine("Signature check OK")
        Else
            Console.WriteLine("Signature check FAILED")
        End If
    End Sub
End Class
'</Snippet1>
