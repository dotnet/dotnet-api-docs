using System;

public partial class Midpoint
{
    public static void Example2()
    {
        // <Snippet6>
        Double[] values = { 12.0, 12.1, 12.2, 12.3, 12.4, 12.5, 12.6,
                          12.7, 12.8, 12.9, 13.0 };
        Console.WriteLine($"{"Value",-10} {"Default",-10} {"ToEven",-10} {"AwayFromZero",-15} {"ToZero",-15}");

        foreach (var value in values)
            Console.WriteLine($"{value,-10:R} {Math.Round(value),-10} " +
                $"{Math.Round(value, MidpointRounding.ToEven),-10} " +
                $"{Math.Round(value, MidpointRounding.AwayFromZero),-15} " +
                $"{Math.Round(value, MidpointRounding.ToZero),-15}");

        // The example displays the following output:
        //       Value      Default    ToEven     AwayFromZero    ToZero
        //       12         12         12         12              12
        //       12.1       12         12         12              12
        //       12.2       12         12         12              12
        //       12.3       12         12         12              12
        //       12.4       12         12         12              12
        //       12.5       12         12         13              12
        //       12.6       13         13         13              12
        //       12.7       13         13         13              12
        //       12.8       13         13         13              12
        //       12.9       13         13         13              12
        //       13         13         13         13              13
        // </Snippet6>
    }
}
