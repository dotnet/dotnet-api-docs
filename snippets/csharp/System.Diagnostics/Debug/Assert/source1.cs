using System;
using System.Diagnostics;

public class Form2
{
    // <Snippet1>
    public static void MyMethod(Type type, Type baseType)
    {
        Debug.Assert(type is not null, "Type parameter is null");

        // Perform some processing.
    }
    // </Snippet1>
}
