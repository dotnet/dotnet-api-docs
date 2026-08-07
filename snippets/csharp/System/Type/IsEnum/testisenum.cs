// <Snippet1>
using System;
public enum Color
{ Red, Blue, Green }

class TestIsEnum
{
    public static void Main()
    {
        Type colorType = typeof(Color);
        Type enumType = typeof(Enum);
        Console.WriteLine($"Is Color an enum? {colorType.IsEnum}.");
        Console.WriteLine($"Is Color a value type? {colorType.IsValueType}.");
        Console.WriteLine($"Is Enum an enum Type? {enumType.IsEnum}.");
        Console.WriteLine($"Is Enum a value type? {enumType.IsValueType}.");
    }
}
// The example displays the following output:
//     Is Color an enum? True.
//     Is Color a value type? True.
//     Is Enum an enum type? False.
//     Is Enum a value type? False.
// </Snippet1>
