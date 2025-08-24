using System;

public class Example3
{
    public static void Main()
    {
        for (int ctr = 0; ctr < 500; ctr++)
            Console.WriteLine($"Line {ctr + 1} of 500 written: {(ctr + 1) / 500.0:P2}");

        Console.Error.WriteLine("\nSuccessfully wrote 500 lines.\n");
    }
}
// The example displays the following output:
//      Line 1 of 500 written: 0,20%
//      Line 2 of 500 written: 0,40%
//      Line 3 of 500 written: 0,60%
//      ...
//      Line 498 of 500 written: 99,60%
//      Line 499 of 500 written: 99,80%
//      Line 500 of 500 written: 100,00%
//
//      Successfully wrote 500 lines.
