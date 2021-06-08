' Visual Basic .NET Document
Option Strict On

Module Midpoint1
    Public Sub Example()
        ' <Snippet5>
        Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15} {4,-15}", "Value", "Default",
                        "ToEven", "AwayFromZero", "ToZero")
        For value As Decimal = 12D To 13D Step 0.1D
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15} {4,-15}",
                           value, Math.Round(value),
                           Math.Round(value, MidpointRounding.ToEven),
                           Math.Round(value, MidpointRounding.AwayFromZero),
                           Math.Round(value, MidpointRounding.ToZero))
        Next

        ' The example displays the following output:
        '       Value      Default    ToEven     AwayFromZero     ToZero
        '       12         12         12         12               12
        '       12.1       12         12         12               12
        '       12.2       12         12         12               12
        '       12.3       12         12         12               12
        '       12.4       12         12         12               12
        '       12.5       12         12         13               12
        '       12.6       13         13         13               12
        '       12.7       13         13         13               12
        '       12.8       13         13         13               12
        '       12.9       13         13         13               12
        '       13.0       13         13         13               13
        ' </Snippet5>
    End Sub
End Module
