// <Snippet1>
using System;

class PadLeftCharacterSample
{
    public static void Run()
    {
        string str = "forty-two";
        char pad = '.';

        Console.WriteLine(str.PadLeft(15, pad));
        Console.WriteLine(str.PadLeft(2, pad));
    }
}
// The example displays the following output:
//       ......forty-two
//       forty-two
// </Snippet1>
