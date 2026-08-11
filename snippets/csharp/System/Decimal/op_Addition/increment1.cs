// <Snippet12>
using System;

public class Example
{
    public static void Main()
    {
        decimal number = 1079.8m;
        Console.WriteLine($"Original value:    {number:N}");
        Console.WriteLine($"Incremented value: {++number:N}");
    }
}
// The example displays the following output:
//       Original value:    1,079.80
//       Incremented value: 1,080.80
// </Snippet12>
