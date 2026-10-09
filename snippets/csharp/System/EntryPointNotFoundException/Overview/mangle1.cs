// <Snippet7>
using System;
using System.Runtime.InteropServices;

public class MangleMissingExample
{
    [DllImport("TestDll.dll")]
    public static extern int Double(int number);

    public static void Run() => Console.WriteLine(Double(10));
}
// The example displays the following output:
//    Unhandled Exception: System.EntryPointNotFoundException: Unable to find
//    an entry point named 'Double' in DLL '.\TestDll.dll'.
//       at Example.Double(Int32 number)
//       at Example.Main()
// </Snippet7>
