// <Snippet1>
using System;

public class Example
{
    public static void Run()
    {
        string[] strings = [ "This is a string.", "Hello!", "Nothing.",
                           "Yes.", "randomize" ];
        foreach (string value in strings)
        {
            bool endsInPeriod = value.EndsWith(".");
            Console.WriteLine($"'{value}' ends in a period: {endsInPeriod}");
        }
    }
}
// The example displays the following output:
//       'This is a string.' ends in a period: True
//       'Hello!' ends in a period: False
//       'Nothing.' ends in a period: True
//       'Yes.' ends in a period: True
//       'randomize' ends in a period: False
// </Snippet1>
