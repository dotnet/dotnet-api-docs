' <Snippet1>
' Declare an interface.
Interface myIFace
End Interface

Class MyIsInterface
    Public Shared Sub Main()
        ' Get the IsInterface attribute for myIFace.
        Dim myBool1 As Boolean = GetType(myIFace).IsInterface
        Console.WriteLine("Is the specified type an interface? {0}.", myBool1)

        ' Determine whether Example is an interface.
        Dim myBool2 As Boolean = GetType(MyIsInterface).IsInterface
        Console.WriteLine("Is the specified type an interface? {0}.", myBool2)
        Console.ReadLine()

    End Sub
End Class
' The example displays the following output:
'       Is the specified type an interface? True.
'       Is the specified type an interface? False.
' </Snippet1>