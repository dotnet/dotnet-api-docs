﻿//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

class DemoMethodBuilder
{

    public static void Main()
    {
        // Creating a dynamic assembly requires an AssemblyName
        // object, and the current application domain.
        //
        AssemblyName asmName =
            new AssemblyName("DemoMethodBuilder1");
        AppDomain domain = AppDomain.CurrentDomain;
        AssemblyBuilder demoAssembly =
            domain.DefineDynamicAssembly(
                asmName,
                AssemblyBuilderAccess.RunAndSave
            );

        // Define the module that contains the code. For an
        // assembly with one module, the module name is the
        // assembly name plus a file extension.
        ModuleBuilder demoModule =
            demoAssembly.DefineDynamicModule(
                asmName.Name,
                asmName.Name + ".dll"
            );

        TypeBuilder demoType = demoModule.DefineType(
            "DemoType",
            TypeAttributes.Public | TypeAttributes.Abstract
        );

        //<Snippet4>
        // Define a Shared, Public method with standard calling
        // conventions. Do not specify the parameter types or the
        // return type, because type parameters will be used for
        // those types, and the type parameters have not been
        // defined yet.
        MethodBuilder demoMethod = demoType.DefineMethod(
            "DemoMethod",
            MethodAttributes.Public | MethodAttributes.Static
        );
        //</Snippet4>

        //<Snippet3>
        // Defining generic parameters for the method makes it a
        // generic method. By convention, type parameters are
        // single alphabetic characters. T and U are used here.
        //
        string[] typeParamNames = {"T", "U"};
        GenericTypeParameterBuilder[] typeParameters =
            demoMethod.DefineGenericParameters(typeParamNames);

        // The second type parameter is constrained to be a
        // reference type.
        typeParameters[1].SetGenericParameterAttributes(
            GenericParameterAttributes.ReferenceTypeConstraint);
        //</Snippet3>

        //<Snippet7>
        // Use the IsGenericMethod property to find out if a
        // dynamic method is generic, and IsGenericMethodDefinition
        // to find out if it defines a generic method.
        Console.WriteLine("Is DemoMethod generic? {0}",
            demoMethod.IsGenericMethod);
        Console.WriteLine("Is DemoMethod a generic method definition? {0}",
            demoMethod.IsGenericMethodDefinition);
        //</Snippet7>

        //<Snippet5>
        // Set parameter types for the method. The method takes
        // one parameter, and its type is specified by the first
        // type parameter, T.
        Type[] parms = {typeParameters[0]};
        demoMethod.SetParameters(parms);

        // Set the return type for the method. The return type is
        // specified by the second type parameter, U.
        demoMethod.SetReturnType(typeParameters[1]);
        //</Snippet5>

        // Generate a code body for the method. The method doesn't
        // do anything except return null.
        //
        ILGenerator ilgen = demoMethod.GetILGenerator();
        ilgen.Emit(OpCodes.Ldnull);
        ilgen.Emit(OpCodes.Ret);

        //<Snippet6>
        // Complete the type.
        Type dt = demoType.CreateType();

        // To bind types to a dynamic generic method, you must
        // first call the GetMethod method on the completed type.
        // You can then define an array of types, and bind them
        // to the method.
        MethodInfo m = dt.GetMethod("DemoMethod");
        Type[] typeArgs = {typeof(string), typeof(DemoMethodBuilder)};
        MethodInfo bound = m.MakeGenericMethod(typeArgs);
        // Display a string representing the bound method.
        Console.WriteLine(bound);
        //</Snippet6>

        // Save the assembly, so it can be examined with Ildasm.exe.
        demoAssembly.Save(asmName.Name + ".dll");
    }
}

/* This code example produces the following output:
Is DemoMethod generic? True
Is DemoMethod a generic method definition? True
DemoMethodBuilder DemoMethod[String,DemoMethodBuilder](System.String)
*/
//</Snippet1>
