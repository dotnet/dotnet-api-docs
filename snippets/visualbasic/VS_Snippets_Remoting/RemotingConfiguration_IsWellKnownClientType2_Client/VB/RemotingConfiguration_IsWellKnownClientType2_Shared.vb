﻿
Public Class MyServerImpl
   Inherits MarshalByRefObject
   
   Public Sub New()
      Console.WriteLine("Server Activated")
   End Sub

   Public Function MyMethod(name As String) As String
      Console.WriteLine(name)
      Return "The string from server : " + name
   End Function 'MyMethod
End Class
