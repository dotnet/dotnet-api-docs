//<snippet1>
using System;
using System.Runtime.InteropServices;

public class Program
{
    public static void MethodWithOptionalAttribute([Optional] string str)
    {
        Console.WriteLine($"str is null: {str == null}");
    }

    public static void Main()
    {
        MethodWithOptionalAttribute(); // str is null: True
        MethodWithOptionalAttribute("abc"); // str is null: False
    }
}
//</snippet1>