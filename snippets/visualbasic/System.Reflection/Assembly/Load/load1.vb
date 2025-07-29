<<<<<<< HEAD
﻿' <Snippet1>
Imports System.Reflection

Class Class1
    Public Shared Sub Main()
		' You must supply a valid fully qualified assembly name.            
		Dim SampleAssembly As [Assembly] = _
			[Assembly].Load("SampleAssembly, Version=1.0.2004.0, Culture=neutral, PublicKeyToken=8744b20f8da049e3")
        Dim oType As Type
        ' Display all the types contained in the specified assembly.
		For Each oType In SampleAssembly.GetTypes()
			Console.WriteLine(oType.Name)
		Next oType
	End Sub	'LoadSample
End Class
' </Snippet1>
=======
﻿' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim longName As String = "system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
      Dim assem As Assembly = Assembly.Load(longName)
      If assem Is Nothing Then
         Console.WriteLine("Unable to load assembly...")
      Else
         Console.WriteLine(assem.FullName)
      End If
   End Sub
End Module
' The example displays the following output:
'       system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
' </Snippet1>
>>>>>>> 888bb64f55349b13f1342f20d22b825c7eb339d7
