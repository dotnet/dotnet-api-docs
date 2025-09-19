using System;
using System.Diagnostics;

public class Form2
{
    // <Snippet1>
    public static void MyMethod(Type type, Type baseType)
    {
        Trace.Assert(type != null, "Type parameter is null",
           "Can't get object for null type");

        // Perform some processing.
    }
    // </Snippet1>
}
