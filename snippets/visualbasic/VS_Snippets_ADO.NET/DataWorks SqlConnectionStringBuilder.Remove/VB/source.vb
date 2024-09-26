Option Explicit On
Option Strict On
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Try
            ' <Snippet1>
            Dim connectString As String =
             "Data Source=(local);User ID=ab;Password=a1Pass@@11;" &
             "Initial Catalog=AdventureWorks"

            Dim builder As New SqlConnectionStringBuilder(connectString)
            Console.WriteLine("Original: " & builder.ConnectionString)

            ' Remove the user ID and password.
            builder.Remove("User ID")
            builder.Remove("Password")

            ' Turn on integrated security:
            builder.IntegratedSecurity = True

            Console.WriteLine("Modified: " & builder.ConnectionString)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        ' This code produces the following output:
        ' Original: Data Source=(local);Initial Catalog=AdventureWorks;User ID=ab;Password=a1Pass@@11
        ' Modified: Data Source = (local);Initial Catalog=AdventureWorks;Integrated Security=True
        ' </Snippet1>
    End Sub
End Module

