// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        decimal[] values = {12.6m, 12.1m, 9.5m, 8.16m, .1m, -.1m,  -1.1m,
                          -1.9m, -3.9m};
        Console.WriteLine($"{"Value",-8} {"Ceiling",10} {"Floor",10}\n");
        foreach (decimal value in values)
            Console.WriteLine($"{value,-8} {decimal.Ceiling(value),10} {decimal.Floor(value),10}");
    }
}
// The example displays the following output:
//       Value       Ceiling      Floor
//
//       12.6             13         12
//       12.1             13         12
//       9.5              10          9
//       8.16              9          8
//       0.1               1          0
//       -0.1              0         -1
//       -1.1             -1         -2
//       -1.9             -1         -2
//       -3.9             -3         -4
// </Snippet1>
