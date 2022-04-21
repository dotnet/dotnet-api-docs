module isassignablefrom_ex1

// <Snippet1>
open System
open System.Reflection
open System.Reflection.Emit

type A() = class end

let domain = AppDomain.CurrentDomain
let assemName = AssemblyName()
assemName.Name <- "TempAssembly"

// Define a dynamic assembly in the current application domain.
let assemBuilder = 
    domain.DefineDynamicAssembly(assemName, AssemblyBuilderAccess.Run)

// Define a dynamic module in this assembly.
let moduleBuilder = 
    assemBuilder.DefineDynamicModule "TempModule"

let b1 = moduleBuilder.DefineType("B", TypeAttributes.Public, typeof<A>)
printfn $"{typeof<A>.IsAssignableFrom b1}"
// The example displays the following output:
//        True
// </Snippet1>