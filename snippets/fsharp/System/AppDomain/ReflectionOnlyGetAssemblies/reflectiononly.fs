//<Snippet1>
open System
open System.Reflection
open System.Timers

// Get the assembly display name for System.dll, the assembly
// that contains System.Timers.Timer. Note that this causes
// System.dll to be loaded into the execution context.
let displayName = typeof<Timer>.Assembly.FullName

// Load System.dll into the reflection-only context. Note that
// if you obtain the display name (for example, by running this
// example program), and enter it as a literal string in the
// preceding line of code, you can load System.dll into the
// reflection-only context without loading it into the execution
// context.
Assembly.ReflectionOnlyLoad displayName |> ignore

// Display the assemblies loaded into the execution and
// reflection-only contexts. System.dll appears in both contexts.
printfn "------------- Execution Context --------------"
for a in AppDomain.CurrentDomain.GetAssemblies() do
    printfn $"\t{a.GetName()}"
printfn "------------- Reflection-only Context --------------"
for a in AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies() do
    printfn $"\t{a.GetName()}"
//</Snippet1>