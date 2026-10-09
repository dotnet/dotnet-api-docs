// <Snippet1>
using System;
using System.Globalization;
using System.Reflection;

public class Example
{
    public static void Main()
    {
        Type[] interf = [typeof(IFormatProvider), typeof(IFormattable)];
        Type[] impl = [typeof(CultureInfo), typeof(DateTime)];

        for (int ctr = 0; ctr < interf.Length; ctr++)
            ShowInterfaceMapping(interf[ctr], impl[ctr]);
    }

    private static void ShowInterfaceMapping(Type intType, Type implType)
    {
        InterfaceMapping map = implType.GetInterfaceMap(intType);
        Console.WriteLine($"Mapping of {map.InterfaceType} to {map.TargetType}: ");
        for (int ctr = 0; ctr < map.InterfaceMethods.Length; ctr++)
        {
            MethodInfo im = map.InterfaceMethods[ctr];
            MethodInfo tm = map.TargetMethods[ctr];
            Console.WriteLine($"   {im.Name} --> {tm.Name}");
        }
        Console.WriteLine();
    }
}
// The example displays the following output:
//    Mapping of System.IFormatProvider to System.Globalization.CultureInfo:
//       GetFormat --> GetFormat
//
//    Mapping of System.IFormattable to System.DateTime:
//       ToString --> ToString
// </Snippet1>
