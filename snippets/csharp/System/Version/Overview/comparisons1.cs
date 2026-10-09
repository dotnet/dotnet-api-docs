using System;

public class Example7
{
    public static void Main() => CompareSimple();

    private static void CompareSimple()
    {
        // <Snippet1>
        Version v1 = new(2, 0);
        Version v2 = new("2.1");
        string relationship = v1.CompareTo(v2) switch
        {
            -1 => "earlier than",
            0 => "the same as",
            1 => "later than",
            _ => throw new InvalidOperationException()
        };

        Console.WriteLine($"Version {v1} is {relationship} Version {v2}.");

        // The example displays the following output:
        //       Version 2.0 is earlier than Version 2.1.
        // </Snippet1>
    }
}
