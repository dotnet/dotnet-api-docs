//<Snippet1>
using System;

internal class InternalOnly
{
    public class Nested { }
}

public class Example
{
    public class Nested { }

    public static void Main()
    {
        Type t = typeof(InternalOnly.Nested);
        Console.WriteLine($"Is the {t.FullName} class visible outside the assembly? {t.IsVisible}");

        t = typeof(Example.Nested);
        Console.WriteLine($"Is the {t.FullName} class visible outside the assembly? {t.IsVisible}");
    }
}

/* This example produces the following output:

Is the InternalOnly+Nested class visible outside the assembly? False
Is the Example+Nested class visible outside the assembly? True
 */
//</Snippet1>
