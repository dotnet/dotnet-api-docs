// <Snippet2>
using System;
using System.Diagnostics;

public class TraceErr
{
    // <Snippet3>
    private static readonly TraceSwitch s_appSwitch = new("mySwitch",
        "Switch in config file");

    public static void Run(string[] args)
    {
        //...
        Console.WriteLine("Trace switch {0} configured as {1}",
            s_appSwitch.DisplayName, s_appSwitch.Level);
        if (s_appSwitch.TraceError)
        {
            //...
        }
    }
    // </Snippet3>
}
// </Snippet2>
