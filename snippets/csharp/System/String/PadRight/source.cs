using System;

public class PadRightWidthSample
{
    public static void Run()
    {
        // <Snippet1>
        string str;
        str = "BBQ and Slaw";

        Console.Write("|");
        Console.Write(str.PadRight(15));
        Console.WriteLine("|");       // Displays "|BBQ and Slaw   |".

        Console.Write("|");
        Console.Write(str.PadRight(5));
        Console.WriteLine("|");       // Displays "|BBQ and Slaw|".
                                      // </Snippet1>
    }
}
