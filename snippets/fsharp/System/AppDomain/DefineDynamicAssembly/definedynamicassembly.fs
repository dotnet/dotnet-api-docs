module definedynamicassembly

// <Snippet1>
open System
open System.Reflection
open System.Reflection.Emit

let instantiateMyDynamicType (domain: AppDomain) =
    try
        // You must supply a valid fully qualified assembly name here.
        domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyDynamicType")
        |> ignore
    with e ->
        printfn $"{e.Message}"

let defineDynamicAssembly (domain: AppDomain) =
    // Build a dynamic assembly using Reflection Emit API.
    let assemblyName = AssemblyName()
    assemblyName.Name <- "MyDynamicAssembly"

    let assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run)
    let moduleBuilder = assemblyBuilder.DefineDynamicModule "MyDynamicModule"
    let typeBuilder = moduleBuilder.DefineType("MyDynamicType", TypeAttributes.Public)
    let constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null)
    let ilGenerator = constructorBuilder.GetILGenerator()

    ilGenerator.EmitWriteLine "MyDynamicType instantiated!"
    ilGenerator.Emit OpCodes.Ret

    typeBuilder.CreateType() |> ignore

    assemblyBuilder

let myResolveEventHandler (sender: obj) _ =
    defineDynamicAssembly (sender :?> AppDomain)
    :> Assembly
   
let currentDomain = AppDomain.CurrentDomain

instantiateMyDynamicType currentDomain   // Failed!

currentDomain.add_AssemblyResolve(ResolveEventHandler myResolveEventHandler)

instantiateMyDynamicType currentDomain   // OK!

// </Snippet1>