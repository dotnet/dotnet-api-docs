' <Snippet1>
Class Example
    Public Shared Sub Main()
        Dim objType As Type = GetType(Array)

        ' Display the assembly full name.
        Console.WriteLine($"Assembly full name:{vbCrLf}   {objType.Assembly.FullName}.")

        ' Display the assembly qualified name.
        Console.WriteLine($"Assembly qualified name:{vbCrLf}   {objType.AssemblyQualifiedName}.")
    End Sub
End Class

' The example displays output similar to the following:
'
'    Assembly full name:
'       System.Private.CoreLib, Version = 10.0.0.0, Culture = neutral, PublicKeyToken = 7cec85d7bea7798e.
'    Assembly qualified name:
'       System.Array, System.Private.CoreLib, Version = 10.0.0.0, Culture = neutral, PublicKeyToken = 7cec85d7bea7798e.

' </Snippet1>
