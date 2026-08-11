using System;

public class PadRightCharacterSample
{
    public static void Run()
    {
        // <Snippet1>
        string str = "forty-two";
        char pad = '.';

        Console.WriteLine(str.PadRight(15, pad));    // Displays "forty-two......".
        Console.WriteLine(str.PadRight(2, pad));    // Displays "forty-two".
                                                    // </Snippet1>
    }
}
