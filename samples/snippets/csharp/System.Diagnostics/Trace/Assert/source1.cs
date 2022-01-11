using System;
using System.Diagnostics;

public class Form1
{
    // <Snippet1>
    public static void MyMethod(Type type, Type baseType)
    {
        Trace.Assert(type != null, "Type parameter is null");

        // Perform some processing.
    }

    // </Snippet1>
}
