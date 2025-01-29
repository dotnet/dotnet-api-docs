Public Class Limit
    Public Shared Sub LimitStrings()
        ' <Snippet1>
        Console.WriteLine("What is your name?")
        Dim name As String = Console.ReadLine()

        Dim substrings = name.Split(" "c, count:=2)
        Dim firstName As String = substrings(0)
        Dim lastName As String

        If substrings.Length > 1 Then
            lastName = substrings(1)
        End If

        Console.WriteLine("firstName = ""{0}""", firstName)
        Console.WriteLine("lastName = ""{0}""", lastName)

        ' If the user enters "Alex Johnson III":
        ' firstName = "Alex"
        ' lastName = "Johnson III"
        ' </Snippet1>
    End Sub
End Class


