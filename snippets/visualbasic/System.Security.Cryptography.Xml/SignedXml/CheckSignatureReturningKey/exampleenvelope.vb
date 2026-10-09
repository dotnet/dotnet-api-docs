' <Snippet1>
'
' This example signs an XML file using an
' envelope signature. It then verifies the 
' signed XML.
'
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Text
Imports System.Xml



Public Class SignVerifyEnvelope
   
   
   Overloads Public Shared Sub Main(args() As [String])
      Try
         ' Generate a RSA signing key.
         Dim RSAKey As RSA = RSA.Create()
         
         ' Create an XML file to sign.
         CreateSomeXml("Example.xml")
         Console.WriteLine("New XML file created.")
         
         ' Sign the XML that was just created and save it in a 
         ' new file.
         SignXmlFile("Example.xml", "SignedExample.xml", RSAKey)
         Console.WriteLine("XML file signed.")
         
         ' Verify the signature of the signed XML.
         Console.WriteLine("Verifying signature...")
         Dim result As Boolean = VerifyXmlFile("SignedExample.xml", RSAKey)
         
         ' Display the results of the signature verification to \
         ' the console.
         If result Then
            Console.WriteLine("The XML signature is valid.")
         Else
            Console.WriteLine("The XML signature is not valid.")
         End If
      Catch e As CryptographicException
         Console.WriteLine(e.Message)
      End Try
   End Sub 
   
   
   ' <Snippet2>
   ' Sign an XML file and save the signature in a new file.
   Public Shared Sub SignXmlFile(FileName As String, SignedFileName As String, RSAKey As RSA)
      ' Create a new XML document.
      Dim doc As New XmlDocument()
      
      ' Format the document to ignore white spaces.
      doc.PreserveWhitespace = False
      
      ' Load the passed XML file using it's name.
      Using reader As XmlReader = XmlReader.Create(FileName)
         doc.Load(reader)
      End Using
      
      ' Create a SignedXml object.
      Dim signedXml As New SignedXml(doc)
      
      ' Add the RSA key to the SignedXml document. 
      signedXml.SigningKey = RSAKey
      
      ' Create a reference to be signed.
      Dim reference As New Reference()
      reference.Uri = ""
      
      ' Add an enveloped transformation to the reference.
      Dim env As New XmlDsigEnvelopedSignatureTransform()
      reference.AddTransform(env)
      
      ' Add the reference to the SignedXml object.
      signedXml.AddReference(reference)
      
      
      ' Add a RSAKeyValue to the KeyInfo (optional; helps recipient find key to validate).
      Dim keyInfo As New KeyInfo()
      keyInfo.AddClause(New RSAKeyValue(CType(RSAKey, RSA)))
      signedXml.KeyInfo = keyInfo
      
      ' Compute the signature.
      signedXml.ComputeSignature()
      
      ' Get the XML representation of the signature and save
      ' it to an XmlElement object.
      Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
      
      ' Append the element to the XML document.
      doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, True))
      
      
      If TypeOf doc.FirstChild Is XmlDeclaration Then
         doc.RemoveChild(doc.FirstChild)
      End If
      
      ' Save the signed XML document to a file specified
      ' using the passed string.
      Dim xmltw As New XmlTextWriter(SignedFileName, New UTF8Encoding(False))
      doc.WriteTo(xmltw)
      xmltw.Close()
   End Sub 
   
   ' </Snippet2>
   ' <Snippet3>
   ' Verify the signature of an XML file and return the result.
   Public Shared Function VerifyXmlFile(Name As [String], TrustedKey As RSA) As [Boolean]
      ' Create a new XML document.
      Dim xmlDocument As New XmlDocument()
      
      ' Format using white spaces.
      xmlDocument.PreserveWhitespace = True
      
      ' Load the passed XML file into the document. 
      Using reader As XmlReader = XmlReader.Create(Name)
         xmlDocument.Load(reader)
      End Using
      
      ' Create a new SignedXml object and pass it
      ' the XML document class.
      Dim signedXml As New SignedXml(xmlDocument)
      
      ' Find the "Signature" node and create a new
      ' XmlNodeList object.
      Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")
      
      ' Load the signature node.
      signedXml.LoadXml(CType(nodeList(0), XmlElement))
      
      ' Verify the signature and retrieve the key that produced it.
      Dim signingKey As AsymmetricAlgorithm = Nothing
      Dim verified As Boolean = signedXml.CheckSignatureReturningKey(signingKey)

      ' The returned key is owned by the caller and can hold native
      ' handles, so dispose it once the comparison is complete.
      Using signingKey
         If Not verified Then
            Return False
         End If

         ' A valid signature only proves possession of some key.
         ' The caller must confirm the returned key matches a key it trusts.
         If TypeOf signingKey Is RSA Then
            Dim rsa As RSA = CType(signingKey, RSA)
            Dim expected As RSAParameters = TrustedKey.ExportParameters(False)
            Dim actual As RSAParameters = rsa.ExportParameters(False)
            Return expected.Modulus.SequenceEqual(actual.Modulus) AndAlso expected.Exponent.SequenceEqual(actual.Exponent)
         End If

         Return False
      End Using
   End Function 
   
   ' </Snippet3>
   ' Create example data to sign.
   Public Shared Sub CreateSomeXml(FileName As String)
      ' Create a new XmlDocument object.
      Dim document As New XmlDocument()
      
      ' Create a new XmlNode object.
      Dim node As XmlNode = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples")
      
      ' Add some text to the node.
      node.InnerText = "Example text to be signed."
      
      ' Append the node to the document.
      document.AppendChild(node)
      
      ' Save the XML document to the file name specified.
      Dim xmltw As New XmlTextWriter(FileName, New UTF8Encoding(False))
      document.WriteTo(xmltw)
      xmltw.Close()
   End Sub 
End Class 
' </Snippet1>