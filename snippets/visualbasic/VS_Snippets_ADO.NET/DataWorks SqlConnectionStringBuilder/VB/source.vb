Option Explicit On
Option Strict On

' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        ' Create a new SqlConnectionStringBuilder and
        ' initialize it with a few name/value pairs:
        Dim builder As New SqlConnectionStringBuilder(
            "Server=(local);Integrated Security=true;" &
            "Initial Catalog=AdventureWorks"
            )

        ' The input connection string used the 
        ' Server key, but the new connection string uses
        ' the well-known Data Source key instead.
        Console.WriteLine("Original connection string: " + builder.ConnectionString)

        ' Now that the connection string has been parsed,
        ' you can work with individual items.
        Console.WriteLine("Initial catalog: " + builder.InitialCatalog)
        builder.InitialCatalog = "Northwind"
        builder.AsynchronousProcessing = True

        ' You can refer to connection keys using strings, 
        ' as well. When you use this technique (the default
        ' Item property in Visual Basic, or the indexer in C#)
        ' you can specify any synonym for the connection string key
        ' name.
        builder("Server") = "."
        builder("Connect Timeout") = 1000

        ' The Item property is the default for the class, 
        ' and setting the Item property adds the value to the 
        ' dictionary, if necessary. 
        builder.Item("Trusted_Connection") = True
        Console.WriteLine("Modified connection string: " + builder.ConnectionString)
    End Sub
End Module
' </Snippet1>

