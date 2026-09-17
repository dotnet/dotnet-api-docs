using System;
using System.Diagnostics;

public class SomeClass
{
    // <Snippet2>
    private static readonly BooleanSwitch s_boolSwitch = new("mySwitch",
        "Switch in config file");

    public static void Run()
    {
        //...
        Console.WriteLine($"Boolean switch {s_boolSwitch.DisplayName} configured as {s_boolSwitch.Enabled}");
        if (s_boolSwitch.Enabled)
        {
            //...
        }
    }
    // </Snippet2>
}
