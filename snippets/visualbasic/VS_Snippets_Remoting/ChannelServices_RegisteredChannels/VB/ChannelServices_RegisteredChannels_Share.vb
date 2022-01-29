﻿' The class 'HelloServer' is derived from 'MarshalByRefObject' to 
' make it remotable.  

Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels

Namespace RemotingSamples
   Public Class HelloServer
      Inherits MarshalByRefObject
      
      Public Sub New()
         Console.WriteLine("HelloServer activated")
      End Sub
      
      Public Function HelloMethod(myName As String) As String
         Console.WriteLine("Hello.HelloMethod : {0}", myName)
         Return "Hi there " + myName
      End Function 'HelloMethod
   End Class
End Namespace 'RemotingSamples