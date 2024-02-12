module ignorecase

// <Snippet1>
open System
open System.Reflection


let instantiateINT32 ignoreCase =
    try
        let currentDomain = AppDomain.CurrentDomain
        let instance = currentDomain.CreateInstanceAndUnwrap(
            "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "SYSTEM.INT32",
            ignoreCase,
            BindingFlags.Default,
            null,
            null,
            null,
            null,
            null)
        printfn $"{instance.GetType()}"
    with :? TypeLoadException as e ->
        printfn $"{e.Message}"

instantiateINT32 false     // Failed!
instantiateINT32 true      // OK!
// </Snippet1>