// <Snippet1>

using System;


class EqualsSourceExample
{
    public static void Run()
    {

        Type a = typeof(string);
        Type b = typeof(int);

        Console.WriteLine($"{a} == {b}: {a.Equals(b)}");

        // The Type objects in a and b are not equal,
        // because they represent different types.

        a = typeof(EqualsSourceExample);
        b = new EqualsSourceExample().GetType();

        Console.WriteLine($"{a} is equal to {b}: {a.Equals(b)}");

        // The Type objects in a and b are equal,
        // because they both represent type Example.

        b = typeof(Type);

        Console.WriteLine($"typeof({a}).Equals(typeof({b})): {a.Equals(b)}");

        // The Type objects in a and b are not equal,
        // because variable a represents type Example
        // and variable b represents type Type.

        //Console.ReadLine();
    }
}

//
/* This code example produces the following output:
    System.String == System.Int32: False
    Example is equal to Example: True
    typeof(Example).Equals(typeof(System.Type)): False
*/
// </Snippet1>
