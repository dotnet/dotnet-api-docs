// <Snippet5>
using System;


public class Base<T> { }

public class Derived<T> : Base<T> { }

public class Example
{
    public static void Main()
    {
        Type t = typeof(Derived<>);
        Console.WriteLine($"Generic Class: {t.FullName}");
        Console.WriteLine($"   Contains Generic Paramters: {t.ContainsGenericParameters}");
        Console.WriteLine($"   Generic Type Definition: {t.IsGenericTypeDefinition}\n");

        Type baseType = t.BaseType;
        Console.WriteLine($"Its Base Class: {baseType.FullName ??
                          "(unassigned) " + baseType}");
        Console.WriteLine($"   Contains Generic Paramters: {baseType.ContainsGenericParameters}");
        Console.WriteLine($"   Generic Type Definition: {baseType.IsGenericTypeDefinition}");
        Console.WriteLine($"   Full Name: {baseType.GetGenericTypeDefinition().FullName}\n");

        t = typeof(Base<>);
        Console.WriteLine($"Generic Class: {t.FullName}");
        Console.WriteLine($"   Contains Generic Paramters: {t.ContainsGenericParameters}");
        Console.WriteLine($"   Generic Type Definition: {t.IsGenericTypeDefinition}\n");
    }
}
// The example displays the following output:
//       Generic Class: Derived`1
//          Contains Generic Paramters: True
//          Generic Type Definition: True
//
//       Its Base Class: (unassigned) Base`1[T]
//          Contains Generic Paramters: True
//          Generic Type Definition: False
//          Full Name: Base`1
//
//       Generic Class: Base`1
//          Contains Generic Paramters: True
//          Generic Type Definition: True
// </Snippet5>
