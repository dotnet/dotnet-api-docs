using System;
using System.ComponentModel;

namespace WarningEx;

public static class WarningEx_Doc
{
    static void Main()
    {
        //<snippet1>
        WarningException myEx = new("This is a warning");
        Console.WriteLine(myEx.Message);
        Console.WriteLine(myEx.ToString());
        //</snippet1>
    }
}
