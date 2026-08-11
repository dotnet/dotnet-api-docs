// <Snippet8>
using System;
using System.Runtime.InteropServices;

public class MangleFixedExample
{
    [DllImport("TestDll.dll", EntryPoint = "?Double@@YAHH@Z")]
    public static extern int Double(int number);

    public static void Run() => Console.WriteLine(Double(10));
}
// The example displays the following output:
//    20
// </Snippet8>
