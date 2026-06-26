//<snippet2>
using System.Runtime.InteropServices;

public class Program2
{
    public static void MethodWithObjectDefaultAttr1([Optional, DefaultParameterValue(123)] object obj) {} // OK
    public static void MethodWithObjectDefaultAttr2([Optional, DefaultParameterValue("abc")] object obj) {} // OK
    public static void MethodWithObjectDefaultAttr3([Optional, DefaultParameterValue(null)] object? obj) {} // OK

    // The following two lines don't compile: a default value for a reference type
    // other than string can only be initialized with null (CS1763).
    // public static void MethodWithObjectDefaultParam1(object obj = 123) {} // CS1763
    // public static void MethodWithObjectDefaultParam2(object obj = "abc") {} // CS1763
    public static void MethodWithObjectDefaultParam3(object? obj = null) {} // OK
}
//</snippet2>