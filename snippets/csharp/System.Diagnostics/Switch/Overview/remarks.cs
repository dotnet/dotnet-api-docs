using System;
using System.Diagnostics;

public class SomeClass
{
    // <Snippet4>
    private static BooleanSwitch boolSwitch = new("mySwitch",
        "Switch in config file");

    public static void Run()
    {
        //...
        Console.WriteLine("Boolean switch {0} configured as {1}",
            boolSwitch.DisplayName, boolSwitch.Enabled);
        if (boolSwitch.Enabled)
        {
            //...
        }
    }
    // </Snippet4>
}
