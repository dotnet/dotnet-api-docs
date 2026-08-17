// The following code example demonstrates that Type objects are returned
// by the typeid operator, and shows how Type objects are used in reflection
// to explore information about types and to invoke members of types.
//<Snippet1>
using System;
using System.Reflection;

class Example3
{
    static void Main()
    {
        Type t = typeof(string);

        MethodInfo substr = t.GetMethod("Substring",
            [typeof(int), typeof(int)]);

        object result =
            substr.Invoke("Hello, World!", [7, 5]);
        Console.WriteLine($"{substr} returned \"{result}\".");
    }
}

/* This code example produces the following output:

System.String Substring(Int32, Int32) returned "World".
 */
//</Snippet1>
