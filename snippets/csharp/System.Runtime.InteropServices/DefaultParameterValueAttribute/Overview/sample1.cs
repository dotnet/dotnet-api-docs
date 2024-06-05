//<snippet1>
using System;
using System.Runtime.InteropServices;

public class Program
{
    public static void MethodWithDefaultParam([Optional, DefaultParameterValue("DEFAULT_PARAM_VALUE")] string str)
    {
        Console.WriteLine($"The passed value is: {str}");
    }

    public static void Main()
    {
        MethodWithDefaultParam(); // The passed value is: DEFAULT_PARAM_VALUE
        MethodWithDefaultParam("NEW_VALUE"); // The passed value is: NEW_VALUE
    }    
}
//</snippet1>