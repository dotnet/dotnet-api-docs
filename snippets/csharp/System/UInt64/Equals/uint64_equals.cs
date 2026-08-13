// <Snippet1>
using System;

class UInt64EqualsExample
{
    public static void Run()
    {
        ulong value1 = 50;
        ulong value2 = 50;

        // Display the values.
        Console.WriteLine($"value1:   Type: {value1.GetType().Name}   Value: {value1}");
        Console.WriteLine($"value2:   Type: {value2.GetType().Name}   Value: {value2}");

        // Compare the two values.
        Console.WriteLine($"value1 and value2 are equal: {value1.Equals(value2)}");
    }
}
// The example displays the following output:
//       value1:   Type: UInt64   Value: 50
//       value2:   Type: UInt64   Value: 50
//       value1 and value2 are equal: True
// </Snippet1>
