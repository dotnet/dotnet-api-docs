// <Snippet1>
using System;

public class MyBaseClass
{
}

public class MyDerivedClass : MyBaseClass
{
}

public class Test
{
    public static void Run()
    {
        MyBaseClass myBase = new();
        MyDerivedClass myDerived = new();
        object o = myDerived;
        MyBaseClass b = myDerived;

        Console.WriteLine($"mybase: Type is {myBase.GetType()}");
        Console.WriteLine($"myDerived: Type is {myDerived.GetType()}");
        Console.WriteLine($"object o = myDerived: Type is {o.GetType()}");
        Console.WriteLine($"MyBaseClass b = myDerived: Type is {b.GetType()}");
    }
}
// The example displays the following output:
//    mybase: Type is MyBaseClass
//    myDerived: Type is MyDerivedClass
//    object o = myDerived: Type is MyDerivedClass
//    MyBaseClass b = myDerived: Type is MyDerivedClass
// </Snippet1>
