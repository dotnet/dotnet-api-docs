// <Snippet1>
using System;


public abstract class MyClassA
{

    public abstract class MyClassB
    {
    }

    public static void Main(string[] args)
    {
        Console.WriteLine($"Reflected type of MyClassB is {typeof(MyClassB).ReflectedType}"); //outputs MyClassA, the enclosing class
    }
}
// </Snippet1>
