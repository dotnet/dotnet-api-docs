// System.Reflection.Emit.TypeBuilder.FullName
// System.Reflection.Emit.TypeBuilder.GetConstructors
// System.Reflection.Emit.TypeBuilder.DefineTypeInitializer

/*
   The following program demonstrates DefineTypeInitializer and 'GetConstructors' methods and
   the 'FullName' property of 'TypeBuilder' class. It builds an assembly by defining 'HelloWorld'
   type. It also defines a constructor for 'HelloWorld' type. Then it displays the
   full name of type and its constructors to the console.
*/

using System;
using System.Reflection;
using System.Reflection.Emit;

// <Snippet1>
// <Snippet2>
// <Snippet3>
public class MyApplication
{
   public static void Main()
   {
      // Create the "HelloWorld" class
      Type helloWorldType = CreateType();
      Console.WriteLine("Full Name : " + helloWorldType.FullName);
      Console.WriteLine("Static constructors:");
      ConstructorInfo[] info =
         helloWorldType.GetConstructors(BindingFlags.Static | BindingFlags.NonPublic);
      for(int index=0; index < info.Length; index++)
         Console.WriteLine(info[index].ToString());
      
      // Print value stored in the static field
      Console.WriteLine(helloWorldType.GetField("Greeting").GetValue(null)); 
      Activator.CreateInstance(helloWorldType);
   }

   // Create the dynamic type.
   private static Type CreateType()
   {
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "EmittedAssembly";

      // Create the callee dynamic assembly.
      AssemblyBuilder myAssembly = AssemblyBuilder.DefineDynamicAssembly(myAssemblyName,
         AssemblyBuilderAccess.Run);
      // Create a dynamic module named "CalleeModule" in the callee assembly.
      ModuleBuilder myModule = myAssembly.DefineDynamicModule("EmittedModule");

      // Define a public class named "HelloWorld" in the assembly.
      TypeBuilder helloWorldClass = myModule.DefineType("HelloWorld", TypeAttributes.Public);
      // Define a public static string field named "Greeting" in the type.
      FieldBuilder greetingField = helloWorldClass.DefineField("Greeting", typeof(String),
         FieldAttributes.Static | FieldAttributes.Public);

      // Create the static constructor.
      ConstructorBuilder constructor = helloWorldClass.DefineTypeInitializer();

      // Generate IL for the method. 
      // The constructor stores its "Hello emit!" in the public field.
      ILGenerator constructorIL = constructor.GetILGenerator();

      constructorIL.Emit(OpCodes.Ldstr, "Hello emit!");
      constructorIL.Emit(OpCodes.Stsfld, greetingField);      
      constructorIL.Emit(OpCodes.Ret);

      return helloWorldClass.CreateType();
   }
}
// </Snippet3>
// </Snippet2>
// </Snippet1>
