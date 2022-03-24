﻿' <Snippet1>
Option Strict
Option Explicit

Imports System.IO
Imports System.Xml

Public Class Sample
    Private currNode As XmlNode
    Private filename As String = "space.xml"
    Private reader As XmlTextReader = Nothing
    
    Public Shared Sub Main()
        Dim test As New Sample()
    End Sub
    
    Public Sub New()
            Dim doc As New XmlDocument()
            doc.LoadXml("<author>" & _
                        "<first-name>Eva</first-name>"& _
                        "<last-name>Corets</last-name>" & _ 
                        "</author>")
            
            Console.WriteLine("InnerText before...")
            Console.WriteLine(doc.DocumentElement.InnerText)
            
            ' Add white space.     
            currNode = doc.DocumentElement
            Dim ws As XmlWhitespace = doc.CreateWhitespace(ControlChars.Lf & ControlChars.Cr)
            currNode.InsertAfter(ws, currNode.FirstChild)
            
            Console.WriteLine()
            Console.WriteLine("InnerText after...")
            Console.WriteLine(doc.DocumentElement.InnerText)
            
            ' Save and then display the file.
            doc.Save(filename)
            Console.WriteLine()
            Console.WriteLine("Reading file...")
            ReadFile(filename)
        
    End Sub
    
    ' Parse the file and display each node.
    Public Sub ReadFile(filename As String)
        Try
            reader = New XmlTextReader(filename)
            Dim sNodeType As String = Nothing
            While reader.Read()
                sNodeType = NodeTypeToString(reader.NodeType)                
                ' Print the node type, name, and value.
                Console.WriteLine("{0}<{1}> {2}", sNodeType, reader.Name, reader.Value)
            End While

        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub
     
    Public Shared Function NodeTypeToString(nodetype As XmlNodeType) As String
        Dim sNodeType As String = Nothing
        Select Case nodetype
            Case XmlNodeType.None
                sNodeType = "None"
            Case XmlNodeType.Element
                sNodeType = "Element"
            Case XmlNodeType.Attribute
                sNodeType = "Attribute"
            Case XmlNodeType.Text
                sNodeType = "Text"
            Case XmlNodeType.Comment
                sNodeType = "Comment"
            Case XmlNodeType.Document
                sNodeType = "Document"
            Case XmlNodeType.Whitespace
                sNodeType = "Whitespace"
            Case XmlNodeType.SignificantWhitespace
                sNodeType = "SignificantWhitespace"
            Case XmlNodeType.EndElement
                sNodeType = "EndElement"
        End Select
        Return sNodeType
    End Function 'NodeTypeToString
End Class
' </Snippet1>
