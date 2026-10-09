// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

public class A
{ }

public class IsAssignableFromExample1
{
    public static void Run()
    {
        AssemblyName assemName = new()
        {
            Name = "TempAssembly"
        };

        // Define a dynamic assembly.
        AssemblyBuilder assemBuilder = AssemblyBuilder.DefineDynamicAssembly(
            assemName, AssemblyBuilderAccess.Run);

        // Define a dynamic module in this assembly.
        ModuleBuilder moduleBuilder = assemBuilder.DefineDynamicModule("TempModule");

        TypeBuilder b1 = moduleBuilder.DefineType("B", TypeAttributes.Public, typeof(A));
        Console.WriteLine(typeof(A).IsAssignableFrom(b1));
    }
}
// The example displays the following output:
//        True
// </Snippet1>
