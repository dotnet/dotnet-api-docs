// <Snippet1>
using System;


public class ContextBoundClass : ContextBoundObject
{
    public string Value = "The Value property.";
}

public class Example
{
    public static void Main()
    {
        // Determine whether the types can be hosted in a Context.
        Console.WriteLine($"The IsContextful property for the {typeof(Example).Name} type is {typeof(Example).IsContextful}.");
        Console.WriteLine($"The IsContextful property for the {typeof(ContextBoundClass).Name} type is {typeof(ContextBoundClass).IsContextful}.");

        // Determine whether the types are marshalled by reference.
        Console.WriteLine($"The IsMarshalByRef property of {typeof(Example).Name} is {typeof(Example).IsMarshalByRef}.");
        Console.WriteLine($"The IsMarshalByRef property of {typeof(ContextBoundClass).Name} is {typeof(ContextBoundClass).IsMarshalByRef}.");

        // Determine whether the types are primitive datatypes.
        Console.WriteLine($"{typeof(int).Name} is a primitive data type: {typeof(int).IsPrimitive}.");
        Console.WriteLine($"{typeof(string).Name} is a primitive data type: {typeof(string).IsPrimitive}.");
    }
}
// The example displays the following output:
//    The IsContextful property for the Example type is False.
//    The IsContextful property for the ContextBoundClass type is True.
//    The IsMarshalByRef property of Example is False.
//    The IsMarshalByRef property of ContextBoundClass is True.
//    Int32 is a primitive data type: True.
//    String is a primitive data type: False.
// </Snippet1>
