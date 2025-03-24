// <Snippet1>
open System

let printLoadedAssemblies (domain: AppDomain) =
    printfn "LOADED ASSEMBLIES:"
    for a in domain.GetAssemblies() do
        printfn $"{a.FullName}"
    printfn ""

let myAssemblyLoadEventHandler _ (args: AssemblyLoadEventArgs)  =
    printfn $"ASSEMBLY LOADED: {args.LoadedAssembly.FullName}\n"

let currentDomain = AppDomain.CurrentDomain
currentDomain.AssemblyLoad.AddHandler(AssemblyLoadEventHandler myAssemblyLoadEventHandler)

printLoadedAssemblies currentDomain
// Lists mscorlib and this assembly

// You must supply a valid fully qualified assembly name here.
currentDomain.CreateInstance("System.Windows.Forms, Version, Culture, PublicKeyToken", "System.Windows.Forms.TextBox")
// Loads System, System.Drawing, System.Windows.Forms

printLoadedAssemblies currentDomain
// Lists all five assemblies


// </Snippet1>