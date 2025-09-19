module source

//<Snippet1>
open System
open System.Reflection
open System.Reflection.Emit
open System.Security

// Create a CustomAttributeBuilder for the assembly attribute.
//
// SecurityTransparentAttribute has a parameterless constructor,
// which is retrieved by passing an array of empty types for the
// constructor's parameter types. The CustomAttributeBuilder is
// then created by passing the ConstructorInfo and an empty array
// of objects to represent the parameters.
//
let transparentCtor =
    typeof<SecurityTransparentAttribute>.GetConstructor(Type.EmptyTypes)
let transparent = CustomAttributeBuilder(transparentCtor, [||])

// Create a dynamic assembly using the attribute. The attribute is
// passed as an array with one element.
let aName = AssemblyName "EmittedAssembly"
let ab = AppDomain.CurrentDomain.DefineDynamicAssembly(
    aName,
    AssemblyBuilderAccess.Run,
    [| transparent |])

let mb = ab.DefineDynamicModule aName.Name
let tb = mb.DefineType(
    "MyDynamicType",
    TypeAttributes.Public )
tb.CreateType() |> ignore

printfn $"{ab}\nAssembly attributes:"
for attr in ab.GetCustomAttributes true do
    printfn $"\t{attr}"

(* This code example produces the following output:

EmittedAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
Assembly attributes:
        System.Security.SecurityTransparentAttribute
 *)
//</Snippet1>