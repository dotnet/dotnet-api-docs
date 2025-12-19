Imports System.Collections
Imports System.Collections.Generic

Public Class Example
    
    Public Shared Sub Main() 

        ' Create a new dictionary of strings, with string keys,
        ' and access it using the IDictionary interface.
        '
        Dim openWith As IDictionary = _
            New Dictionary(Of String, String)
        
        ' Add some elements to the dictionary. There are no 
        ' duplicate keys, but some of the values are duplicates.
        ' IDictionary.Add throws an exception if incorrect types
        ' are supplied for key or value.
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")

        ' Contains can be used to test keys before inserting 
        ' them.
        If Not openWith.Contains("ht") Then
            openWith.Add("ht", "hypertrm.exe")
            Console.WriteLine("Value added for key = ""ht"": {0}", _
                openWith("ht"))
        End If

        ' IDictionary.Contains returns False if the wrong data 
        ' type is supplied.
        Console.WriteLine("openWith.Contains(29.7) returns {0}", _
            openWith.Contains(29.7))

    End Sub

End Class
