﻿' <Snippet1>
Option Strict
Option Explicit

Imports System.IO
Imports System.Xml

Public Class Sample
    Public Shared Sub Main()
        
        Dim doc As New XmlDocument()
        doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "</book>")
        Dim root As XmlNode = doc.DocumentElement
        
        'Create a new node.
        Dim elem As XmlElement = doc.CreateElement("price")
        elem.InnerText = "19.95"
        
        'Add the node to the document.
        root.InsertAfter(elem, root.FirstChild)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub
End Class
' </Snippet1>
