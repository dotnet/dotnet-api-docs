// <Snippet1>
open System
open System.Reflection
open System.Reflection.Emit

let currDom = AppDomain.CurrentDomain

// Create a dynamic assembly with one module, to be saved to
// disk (AssemblyBuilderAccess.Save).
//
let aName = AssemblyName()
aName.Name <- "Transient"
let moduleName = aName.Name + ".dll"
let ab = currDom.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Save)

let handleTypeResolve _ _ =
    printfn "TypeResolve event handler."

    // Save the dynamic assembly, and then load it using its
    // display name. Return the loaded assembly.
    ab.Save moduleName
    Assembly.Load ab.FullName

let mb = ab.DefineDynamicModule(aName.Name, moduleName)

// The dynamic assembly has just one dummy type, to demonstrate
// type resolution.
let tb = mb.DefineType "Example"
tb.CreateType() |> ignore

// First, try to load the type without saving the dynamic
// assembly and without hooking up the TypeResolve event. The
// type cannot be loaded.
try
    let temp = Type.GetType("Example", true)
    printfn $"Loaded type {temp}."
with :? TypeLoadException ->
    printfn "Loader could not resolve the type."

// Hook up the TypeResolve event.
//
currDom.add_TypeResolve(ResolveEventHandler handleTypeResolve)

// Now try to load the type again. The TypeResolve event is
// raised, the dynamic assembly is saved, and the dummy type is
// loaded successfully. Display it to the console, and create
// an instance.
let t = Type.GetType("Example", true)
printfn $"Loaded type \"{t}\"."
let o = Activator.CreateInstance t

(* This code example produces the following output:

Loader could not resolve the type.
TypeResolve event handler.
Loaded type "Example".
 *)
// </Snippet1>