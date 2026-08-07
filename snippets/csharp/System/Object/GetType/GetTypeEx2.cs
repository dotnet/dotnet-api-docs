using System;

public class Example
{
    public static void Main()
    {
        // <Snippet2>
        object[] values = { (int) 12, (long) 10653, (byte) 12, (sbyte) -5,
                         16.3, "string" };
        foreach (object value in values)
        {
            Type t = value.GetType();
            if (t.Equals(typeof(byte)))
                Console.WriteLine($"{value} is an unsigned byte.");
            else if (t.Equals(typeof(sbyte)))
                Console.WriteLine($"{value} is a signed byte.");
            else if (t.Equals(typeof(int)))
                Console.WriteLine($"{value} is a 32-bit integer.");
            else if (t.Equals(typeof(long)))
                Console.WriteLine($"{value} is a 64-bit integer.");
            else if (t.Equals(typeof(double)))
                Console.WriteLine($"{value} is a double-precision floating point.");
            else
                Console.WriteLine($"'{value}' is another data type.");
        }

        // The example displays the following output:
        //    12 is a 32-bit integer.
        //    10653 is a 64-bit integer.
        //    12 is an unsigned byte.
        //    -5 is a signed byte.
        //    16.3 is a double-precision floating point.
        //    'string' is another data type.
        // </Snippet2>
    }
}
