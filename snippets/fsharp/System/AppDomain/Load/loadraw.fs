module loadraw

// <Snippet1>
open System
open System.IO
open System.Reflection
open System.Reflection.Emit

let instantiateMyType (domain: AppDomain) =
    try
        // You must supply a valid fully qualified assembly name here.
        domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyType")
        |> ignore  
    with e ->
        printfn $"{e.Message}"

// Loads the content of a file to a byte array.
let loadFile filename =
    use fs = new FileStream(filename, FileMode.Open)
    let buffer = Array.zeroCreate<byte> (int fs.Length)
    fs.Read(buffer, 0, buffer.Length) |> ignore
    fs.Close()
    buffer

// Creates a dynamic assembly with symbol information
// and saves them to temp.dll and temp.pdb
let emitAssembly (domain: AppDomain) =
    let assemblyName = AssemblyName()
    assemblyName.Name <- "MyAssembly"

    let assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save)
    let moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule", "temp.dll", true)
    let typeBuilder = moduleBuilder.DefineType("MyType", TypeAttributes.Public)

    let constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null)
    let ilGenerator = constructorBuilder.GetILGenerator()
    ilGenerator.EmitWriteLine "MyType instantiated!"
    ilGenerator.Emit OpCodes.Ret

    typeBuilder.CreateType() |> ignore

    assemblyBuilder.Save "temp.dll"

let myResolver (sender: obj) (args: ResolveEventArgs) =
    let domain = sender :?> AppDomain

    // Once the files are generated, this call is
    // actually no longer necessary.
    emitAssembly domain

    let rawAssembly = loadFile "temp.dll"
    let rawSymbolStore = loadFile "temp.pdb"
    domain.Load(rawAssembly, rawSymbolStore)

let currentDomain = AppDomain.CurrentDomain

instantiateMyType currentDomain   // Failed!

currentDomain.add_AssemblyResolve (ResolveEventHandler myResolver)

instantiateMyType currentDomain   // OK!
// </Snippet1>