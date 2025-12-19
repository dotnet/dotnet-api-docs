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

        ' The Item property is the default property, so you 
        ' can omit its name when accessing elements. 
        Console.WriteLine("For key = ""rtf"", value = {0}.", _
            openWith("rtf"))
        
        ' The default Item property can be used to change the value
        ' associated with a key.
        openWith("rtf") = "winword.exe"
        Console.WriteLine("For key = ""rtf"", value = {0}.", _
            openWith("rtf"))
        
        ' If a key does not exist, setting the default Item property
        ' for that key adds a new key/value pair.
        openWith("doc") = "winword.exe"

        ' The default Item property returns Nothing if the key
        ' is of the wrong data type.
        Console.WriteLine("The default Item property returns Nothing" _
            & " if the key is of the wrong type:")
        Console.WriteLine("For key = 2, value = {0}.", _
            openWith(2))

        ' The default Item property throws an exception when setting
        ' a value if the key is of the wrong data type.
        Try
            openWith(2) = "This does not get added."
        Catch 
            Console.WriteLine("A key of the wrong type was specified" _
                & " when setting the default Item property.")
        End Try

        ' Unlike the default Item property on the Dictionary class
        ' itself, IDictionary.Item does not throw an exception
        ' if the requested key is not in the dictionary.
        Console.WriteLine("For key = ""tif"", value = {0}.", _
            openWith("tif"))

    End Sub

End Class
