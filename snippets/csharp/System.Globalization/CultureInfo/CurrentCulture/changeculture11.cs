// <Snippet11>
using System;
using System.Globalization;
using System.Threading;

public class Info11 : MarshalByRefObject
{
    public void ShowCurrentCulture()
    {
        Console.WriteLine($"Culture of thread {Thread.CurrentThread.Name}: {CultureInfo.CurrentCulture.Name}");
    }
}

public class SetCultureExample
{
    public static void Run()
    {
        Info11 inf = new Info11();
        // Set the current culture to Dutch (Netherlands).
        Thread.CurrentThread.Name = "MainThread";
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-NL");
        inf.ShowCurrentCulture();
    }
}

// The example displays the following output:
//
//     Culture of thread MainThread: nl-NL
// </Snippet11>
