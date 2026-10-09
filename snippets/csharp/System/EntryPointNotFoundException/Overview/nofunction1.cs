// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class NoFunctionExample
{
    [DllImport("user32.dll")]
    public static extern int GetMyNumber();

    public static void Run()
    {
        try
        {
            int number = GetMyNumber();
        }
        catch (EntryPointNotFoundException e)
        {
            Console.WriteLine($"{e.GetType().Name}:\n   {e.Message}");
        }
    }
}
// The example displays the following output:
//    EntryPointNotFoundException:
//       Unable to find an entry point named 'GetMyNumber' in DLL 'User32.dll'.
// </Snippet1>
