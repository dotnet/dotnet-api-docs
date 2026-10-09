// <Snippet4>
using System;

public class Example
{
    public static void Main()
    {
        decimal number = 1079.8m;
        Console.WriteLine($"Original value:    {number:N}");
        Console.WriteLine($"Decremented value: {--number:N}");
    }
}
// The example displays the following output:
//       Original value:    1,079.80
//       Decremented value: 1,078.80
// </Snippet4>
