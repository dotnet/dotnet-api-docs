// <Snippet1>
using System;

// Declare an enum type.
enum NumEnum { One, Two }

public class Example
{

    public static void Main(string[] args)
    {
        bool flag = false;
        NumEnum testEnum = NumEnum.One;
        // Get the type of testEnum.
        Type t = testEnum.GetType();
        // Get the IsValueType property of the testEnum variable.
        flag = t.IsValueType;
        Console.WriteLine($"{t.FullName} is a value type: {flag}");
    }
}
// The example displays the following output:
//        NumEnum is a value type: True
// </Snippet1>
