//<Snippet1>
using System;
class TestType
{
    public static void Main()
    {
        Type t = typeof(int);
        Console.WriteLine($"{t} inherits from {t.BaseType}.");
    }
}
//</Snippet1>
