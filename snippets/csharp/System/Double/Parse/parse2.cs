using System;

public class Example
{
    public static void Main()
    {
        // <Snippet3>
        string value;

        value = double.MinValue.ToString();
        try
        {
            Console.WriteLine(double.Parse(value));
        }
        catch (OverflowException)
        {
            Console.WriteLine($"{value} is outside the range of the Double type.");
        }

        value = double.MaxValue.ToString();
        try
        {
            Console.WriteLine(double.Parse(value));
        }
        catch (OverflowException)
        {
            Console.WriteLine($"{value} is outside the range of the Double type.");
        }

        // Format without the default precision.
        value = double.MinValue.ToString("G17");
        try
        {
            Console.WriteLine(double.Parse(value));
        }
        catch (OverflowException)
        {
            Console.WriteLine($"{value} is outside the range of the Double type.");
        }
        // The example displays the following output:
        //    -1.79769313486232E+308 is outside the range of the Double type.
        //    1.79769313486232E+308 is outside the range of the Double type.
        //    -1.79769313486232E+308
        // </Snippet3>
    }
}
