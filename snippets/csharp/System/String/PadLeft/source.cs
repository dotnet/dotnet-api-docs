using System;

public class PadLeftWidthSample
{
    public static void Run()
    {
        // <Snippet1>
        string str = "BBQ and Slaw";
        Console.WriteLine(str.PadLeft(15));  // Displays "   BBQ and Slaw".
        Console.WriteLine(str.PadLeft(5));   // Displays "BBQ and Slaw".
                                             // </Snippet1>
    }
}
