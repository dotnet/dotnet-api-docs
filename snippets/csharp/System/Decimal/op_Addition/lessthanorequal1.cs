// <Snippet17>
using System;

public class Example
{
    public static void Main()
    {
        decimal number1 = 16354.0699m;
        decimal number2 = 16354.0695m;
        Console.WriteLine($"{number1} <= {number2}: {number1 <= number2}");

        number1 = decimal.Round(number1, 2);
        number2 = decimal.Round(number2, 2);
        Console.WriteLine($"{number1} <= {number2}: {number1 <= number2}");
    }
}
// The example displays the following output:
//       16354.0699 <= 16354.0695: False
//       16354.07 <= 16354.07: True
// </Snippet17>
