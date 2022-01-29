﻿' <Snippet1>
Option Explicit
Option Strict

Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        'Create a writer to write XML to the console.
        Dim writer As XmlTextWriter = Nothing
        writer = New XmlTextWriter(Console.Out)
        
        'Use indentation for readability.
        writer.Formatting = Formatting.Indented
        
        'Write an element (this one is the root).
        writer.WriteStartElement("order")
        
        'Write some attributes.
        writer.WriteAttributeString("date", "2/19/01")
        writer.WriteAttributeString("orderID", "136A5")
        
        'Write a full end element. Because this element has no
        'content, calling WriteEndElement would have written a
        'short end tag '/>'.
        writer.WriteFullEndElement()
        
        'Write the XML to file and close the writer
        writer.Close()
    End Sub
End Class
' </Snippet1>