// <Snippet7>
using System;

public class Example
{
    public static void Main()
    {
        decimal number1 = 16.8m;
        decimal number2 = 4.1m;
        decimal number3 = number1 / number2;
        Console.WriteLine($"{number1:N2} / {number2:N2} = {number3:N2}");
    }
}
// The example displays the following output:
//        16.80 / 4.10 = 4.10
// </Snippet7>
