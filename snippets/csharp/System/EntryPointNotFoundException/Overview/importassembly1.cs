// <Snippet4>
using System;
using System.Runtime.InteropServices;

public class ImportAssemblyExample
{
    [DllImport("StringUtilities.dll", CharSet = CharSet.Unicode)]
    public static extern string SayGoodMorning(string name);

    public static void Run() => Console.WriteLine(SayGoodMorning("Dakota"));
}
// The example displays the following output:
//    Unhandled Exception: System.EntryPointNotFoundException: Unable to find an entry point
//    named 'GoodMorning' in DLL 'StringUtilities.dll'.
//       at Example.GoodMorning(String& name)
//       at Example.Main()
// </Snippet4>
