module midpoint1

open System

// <Snippet5>
printfn $"""{"Value",-10} {"Default",-10} {"ToEven",-10} {"AwayFromZero",-15} {"ToZero",-15}"""
for value in 12m .. 0.1m .. 13m do
    printfn "%-10O %-10O %-10O %-15O %-15O" 
        value
        (Math.Round value)
        (Math.Round(value, MidpointRounding.ToEven))
        (Math.Round(value, MidpointRounding.AwayFromZero))
        (Math.Round(value, MidpointRounding.ToZero))

// The example displays the following output:
//       Value      Default    ToEven     AwayFromZero    ToZero
//       12.0       12         12         12              12
//       12.1       12         12         12              12
//       12.2       12         12         12              12
//       12.3       12         12         12              12
//       12.4       12         12         12              12
//       12.5       12         12         13              12
//       12.6       13         13         13              12
//       12.7       13         13         13              12
//       12.8       13         13         13              12
//       12.9       13         13         13              12
//       13.0       13         13         13              13
// </Snippet5> 