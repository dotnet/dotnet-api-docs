// <Snippet3>
using System;

public class Example
{
    public static void Main()
    {
        string value;
        double number;

        value = double.MinValue.ToString();
        if (double.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"{value} is outside the range of a Double.");

        value = double.MaxValue.ToString();
        if (double.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"{value} is outside the range of a Double.");
    }
}
// The example displays the following output:
//    -1.79769313486232E+308 is outside the range of the Double type.
//    1.79769313486232E+308 is outside the range of the Double type.
// </Snippet3>
