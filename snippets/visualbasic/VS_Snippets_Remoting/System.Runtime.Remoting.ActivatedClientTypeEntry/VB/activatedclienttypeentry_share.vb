﻿'<snippet20>
Public Class HelloServer
    Inherits MarshalByRefObject
    
    Public Sub New(myString As String)
        Console.WriteLine("HelloServer activated")
        Console.WriteLine("Parameter passed to the constructor is " + myString)
    End Sub
    
    Public Function HelloMethod(myName As String) As String
        Console.WriteLine("HelloMethod : {0}", myName)
        Return "Hi there " + myName
    End Function 'HelloMethod
End Class
'</snippet20>
