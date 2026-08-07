using System;

class MyClass
{

    static void Main()
    {
        // <Snippet1>
        object o = null;
        object p = null;
        object q = new();

        Console.WriteLine(object.ReferenceEquals(o, p));
        p = q;
        Console.WriteLine(object.ReferenceEquals(p, q));
        Console.WriteLine(object.ReferenceEquals(o, p));

        // This code produces the following output:
        //   True
        //   True
        //   False
        // </Snippet1>
    }
}
