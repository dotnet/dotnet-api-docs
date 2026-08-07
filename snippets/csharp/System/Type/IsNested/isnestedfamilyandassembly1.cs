// <Snippet1>
using System;

// Create a class with a number of nested classes.
public class OuterClass
{
    private class PrivateClass
    { }

    protected class ProtectedClass
    { }

    internal class InternalClass
    { }

    protected internal class ProtectedInternalClass
    { }

    public class PublicClass
    { }

    public static void Main()
    {
        // Create an array of Type objects for all the classes.
        Type[] types = { typeof(OuterClass),
                         typeof(OuterClass.PublicClass),
                         typeof(OuterClass.PrivateClass),
                         typeof(OuterClass.ProtectedClass),
                         typeof(OuterClass.InternalClass),
                         typeof(OuterClass.ProtectedInternalClass) };
        // Display the property values of each nested class.
        foreach (var type in types)
        {
            Console.WriteLine($"\n{type.Name} property values:");
            Console.WriteLine($"   Public Class: {type.IsPublic}");
            Console.WriteLine($"   Not a Public Class: {type.IsNotPublic}");
            Console.WriteLine($"   Nested Class: {type.IsNested}");
            Console.WriteLine($"   Nested Private Class: {type.IsNestedPrivate}");
            Console.WriteLine($"   Nested Internal Class: {type.IsNestedAssembly}");
            Console.WriteLine($"   Nested Protected Class: {type.IsNestedFamily}");
            Console.WriteLine($"   Nested Family Or Assembly Class: {type.IsNestedFamORAssem}");
            Console.WriteLine($"   Nested Family And Assembly Class: {type.IsNestedFamANDAssem}");
            Console.WriteLine($"   Nested Public Class: {type.IsNestedPublic}");
        }
    }
}
// The example displays the following output:
//    OuterClass property values:
//       Public Class: True
//       Not a Public Class: False
//       Nested Class: False
//       Nested Private Class: False
//       Nested Internal Class: False
//       Nested Protected Class: False
//       Nested Family Or Assembly Class: False
//       Nested Family And Assembly Class: False
//       Nested Public Class: False
//
//    PublicClass property values:
//       Public Class: False
//       Not a Public Class: False
//       Nested Class: True
//       Nested Private Class: False
//       Nested Internal Class: False
//       Nested Protected Class: False
//       Nested Family Or Assembly Class: False
//       Nested Family And Assembly Class: False
//       Nested Public Class: True
//
//    PrivateClass property values:
//       Public Class: False
//       Not a Public Class: False
//       Nested Class: True
//       Nested Private Class: True
//       Nested Internal Class: False
//       Nested Protected Class: False
//       Nested Family Or Assembly Class: False
//       Nested Family And Assembly Class: False
//       Nested Public Class: False
//
//    ProtectedClass property values:
//       Public Class: False
//       Not a Public Class: False
//       Nested Class: True
//       Nested Private Class: False
//       Nested Internal Class: False
//       Nested Protected Class: True
//       Nested Family Or Assembly Class: False
//       Nested Family And Assembly Class: False
//       Nested Public Class: False
//
//    InternalClass property values:
//       Public Class: False
//       Not a Public Class: False
//       Nested Class: True
//       Nested Private Class: False
//       Nested Internal Class: True
//       Nested Protected Class: False
//       Nested Family Or Assembly Class: False
//       Nested Family And Assembly Class: False
//       Nested Public Class: False
//
//    ProtectedInternalClass property values:
//       Public Class: False
//       Not a Public Class: False
//       Nested Class: True
//       Nested Private Class: False
//       Nested Internal Class: False
//       Nested Protected Class: False
//       Nested Family Or Assembly Class: True
//       Nested Family And Assembly Class: False
//       Nested Public Class: False
// </Snippet1>
