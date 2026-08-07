// <Snippet1>
using System;

public class Example
{
    // Declare InnerClass as sealed.
    sealed public class InnerClass
    {
    }

    public static void Main()
    {
        InnerClass inner = new();
        // Get the type of InnerClass.
        Type innerType = inner.GetType();
        // Get the IsSealed property of  innerClass.
        bool isSealed = innerType.IsSealed;
        Console.WriteLine($"{innerType.FullName} is sealed: {isSealed}.");
    }
}
// The example displays the following output:
//        Example+InnerClass is sealed: True.
// </Snippet1>
