//<Snippet1>
open System
open System.Threading
open System.Reflection
open System.Reflection.Emit

// This code creates an assembly that contains one type,
// named "MyDynamicType", that has a private field, a property
// that gets and sets the private field, constructors that
// initialize the private field, and a method that multiplies
// a user-supplied number by the private field value and returns
// the result. In C# the type might look like this:
(*
public class MyDynamicType
{
    private int m_number;

    public MyDynamicType() : this(42) {}
    public MyDynamicType(int initNumber)
    {
        m_number = initNumber;
    }

    public int Number
    {
        get { return m_number; }
        set { m_number = value; }
    }

    public int MyMethod(int multiplier)
    {
        return m_number * multiplier;
    }
}
*)

let assemblyName = new AssemblyName("DynamicAssemblyExample")
let assemblyBuilder =
    AssemblyBuilder.DefineDynamicAssembly(
        assemblyName,
        AssemblyBuilderAccess.Run)

// The module name is usually the same as the assembly name.
let moduleBuilder =
    assemblyBuilder.DefineDynamicModule(assemblyName.Name)

let typeBuilder =
    moduleBuilder.DefineType(
        "MyDynamicType",
        TypeAttributes.Public)

// Add a private field of type int (Int32)
let fieldBuilderNumber =
    typeBuilder.DefineField(
        "m_number",
        typeof<int>,
        FieldAttributes.Private)

// Define a constructor1 that takes an integer argument and
// stores it in the private field.
let parameterTypes = [| typeof<int> |]
let ctor1 =
    typeBuilder.DefineConstructor(
        MethodAttributes.Public,
        CallingConventions.Standard,
        parameterTypes)

let ctor1IL = ctor1.GetILGenerator()

// For a constructor, argument zero is a reference to the new
// instance. Push it on the stack before calling the base
// class constructor. Specify the default constructor of the
// base class (System.Object) by passing an empty array of
// types (Type.EmptyTypes) to GetConstructor.
ctor1IL.Emit(OpCodes.Ldarg_0)
ctor1IL.Emit(OpCodes.Call,
                 typeof<obj>.GetConstructor(Type.EmptyTypes))

// Push the instance on the stack before pushing the argument
// that is to be assigned to the private field m_number.
ctor1IL.Emit(OpCodes.Ldarg_0)
ctor1IL.Emit(OpCodes.Ldarg_1)
ctor1IL.Emit(OpCodes.Stfld, fieldBuilderNumber)
ctor1IL.Emit(OpCodes.Ret)

// Define a default constructor1 that supplies a default value
// for the private field. For parameter types, pass the empty
// array of types or pass null.
let ctor0 =
    typeBuilder.DefineConstructor(
        MethodAttributes.Public,
        CallingConventions.Standard,
        Type.EmptyTypes)

let ctor0IL = ctor0.GetILGenerator()
// For a constructor, argument zero is a reference to the new
// instance. Push it on the stack before pushing the default
// value on the stack, then call constructor ctor1.
ctor0IL.Emit(OpCodes.Ldarg_0)
ctor0IL.Emit(OpCodes.Ldc_I4_S, 42)
ctor0IL.Emit(OpCodes.Call, ctor1)
ctor0IL.Emit(OpCodes.Ret)

// Define a property named Number that gets and sets the private
// field.
//
// The last argument of DefineProperty is null, because the
// property has no parameters. (If you don't specify null, you must
// specify an array of Type objects. For a parameterless property,
// use the built-in array with no elements: Type.EmptyTypes)
let propertyBuilderNumber =
    typeBuilder.DefineProperty(
        "Number",
        PropertyAttributes.HasDefault,
        typeof<int>,
        null)

// The property "set" and property "get" methods require a special
// set of attributes.
let getSetAttr = MethodAttributes.Public ||| MethodAttributes.SpecialName ||| MethodAttributes.HideBySig

// Define the "get" accessor method for Number. The method returns
// an integer and has no arguments. (Note that null could be
// used instead of Types.EmptyTypes)
let methodBuilderNumberGetAccessor =
    typeBuilder.DefineMethod(
        "get_number",
        getSetAttr,
        typeof<int>,
        Type.EmptyTypes)

let numberGetIL =
    methodBuilderNumberGetAccessor.GetILGenerator()

// For an instance property, argument zero ir the instance. Load the
// instance, then load the private field and return, leaving the
// field value on the stack.
numberGetIL.Emit(OpCodes.Ldarg_0)
numberGetIL.Emit(OpCodes.Ldfld, fieldBuilderNumber)
numberGetIL.Emit(OpCodes.Ret)

// Define the "set" accessor method for Number, which has no return
// type and takes one argument of type int (Int32).
let methodBuilderNumberSetAccessor =
    typeBuilder.DefineMethod(
        "set_number",
        getSetAttr,
        null,
        [| typeof<int> |])

let numberSetIL =
    methodBuilderNumberSetAccessor.GetILGenerator()
// Load the instance and then the numeric argument, then store the
// argument in the field
numberSetIL.Emit(OpCodes.Ldarg_0)
numberSetIL.Emit(OpCodes.Ldarg_1)
numberSetIL.Emit(OpCodes.Stfld, fieldBuilderNumber)
numberSetIL.Emit(OpCodes.Ret)

// Last, map the "get" and "set" accessor methods to the
// PropertyBuilder. The property is now complete.
propertyBuilderNumber.SetGetMethod(methodBuilderNumberGetAccessor)
propertyBuilderNumber.SetSetMethod(methodBuilderNumberSetAccessor)

// Define a method that accepts an integer argument and returns
// the product of that integer and the private field m_number. This
// time, the array of parameter types is created on the fly.
let methodBuilder =
    typeBuilder.DefineMethod(
        "MyMethod",
        MethodAttributes.Public,
        typeof<int>,
        [| typeof<int> |])

let methodIL = methodBuilder.GetILGenerator()
// To retrieve the private instance field, load the instance it
// belongs to (argument zero). After loading the field, load the
// argument one and then multiply. Return from the method with
// the return value (the product of the two numbers) on the
// execution stack.
methodIL.Emit(OpCodes.Ldarg_0)
methodIL.Emit(OpCodes.Ldfld, fieldBuilderNumber)
methodIL.Emit(OpCodes.Ldarg_1)
methodIL.Emit(OpCodes.Mul)
methodIL.Emit(OpCodes.Ret)

// Finish the type
let typ = typeBuilder.CreateType()

// Because AssemblyBuilderAccess includes Run, the code can be
// executed immediately. Start by getting reflection objects for
// the method and the property.
let methodInfo = typ.GetMethod("MyMethod")
let propertyInfo = typ.GetProperty("Number")

// Create an instance of MyDynamicType using the default
// constructor.
let obj1 = Activator.CreateInstance(typ)

// Display the value of the property, then change it to 127 and
// display it again. Use null to indicate that the property
// has no index.
printfn "obj1.Number: %A" (propertyInfo.GetValue(obj1, null))
propertyInfo.SetValue(obj1, 127, null)
printfn "obj1.Number: %A" (propertyInfo.GetValue(obj1, null))

// Call MyMethod, pasing 22, and display the return value, 22
// times 127. Arguments must be passed as an array, even when
// there is only one.
let arguments: obj array = [| 22 |]
printfn "obj1.MyMethod(22): %A" (methodInfo.Invoke(obj1, arguments))

// Create an instance of MyDynamicType using the constructor
// that specifies m_Number. The constructor is identified by
// matching the types in the argument array. In this case,
// the argument array is created on the fly. Display the
// property value.
let constructorArguments: obj array = [| 5280 |]
let obj2 = Activator.CreateInstance(typ, constructorArguments)
printfn "obj2.Number: %A" (propertyInfo.GetValue(obj2, null))

(* This code produces the following output:

obj1.Number: 42
obj1.Number: 127
obj1.MyMethod(22): 2794
obj1.Number: 5280
*)
//</Snippet1>
