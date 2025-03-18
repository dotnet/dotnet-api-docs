//<snippet2>
using System.Runtime.InteropServices;

public class Program
{
    public static void MethodWithObjectDefaultAttr1([Optional, DefaultParameterValue(123)] object obj) {} // OK
    public static void MethodWithObjectDefaultAttr2([Optional, DefaultParameterValue("abc")] object obj) {} // OK
    public static void MethodWithObjectDefaultAttr3([Optional, DefaultParameterValue(null)] object? obj) {} // OK

    public static void MethodWithObjectDefaultParam1(object obj = 123) {} // CS1763
    public static void MethodWithObjectDefaultParam2(object obj = "abc") {} // CS1763
    public static void MethodWithObjectDefaultParam3(object obj? = null) {} // OK
}
//</snippet2>