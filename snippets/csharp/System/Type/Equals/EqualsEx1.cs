// <Snippet1>
using System;
using System.Collections.Generic;
using System.Reflection;

public class Example
{
    public static void Main()
    {
        Type t = typeof(int);
        object obj1 = typeof(int).GetTypeInfo();
        IsEqualTo(t, obj1);

        object obj2 = typeof(string);
        IsEqualTo(t, obj2);

        t = typeof(object);
        object obj3 = typeof(object);
        IsEqualTo(t, obj3);

        t = typeof(List<>);
        object obj4 = (new List<string>()).GetType();
        IsEqualTo(t, obj4);

        t = typeof(Type);
        object obj5 = null;
        IsEqualTo(t, obj5);
    }

    private static void IsEqualTo(Type t, object inst)
    {
        Type t2 = inst as Type;
        if (t2 != null)
            Console.WriteLine($"{t.Name} = {t2.Name}: {t.Equals(t2)}");
        else
            Console.WriteLine("Cannot cast the argument to a type.");

        Console.WriteLine();
    }
}
// The example displays the following output:
//       Int32 = Int32: True
//
//       Int32 = String: False
//
//       Object = Object: True
//
//       List`1 = List`1: False
//
//       Cannot cast the argument to a type.
// </Snippet1>
