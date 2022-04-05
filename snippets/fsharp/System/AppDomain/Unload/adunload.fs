//  <SNIPPET1>
open System

//Create evidence for the new appdomain.
let adevidence = AppDomain.CurrentDomain.Evidence

// Create the new application domain.
let domain = AppDomain.CreateDomain("MyDomain", adevidence)

printfn $"Host domain: {AppDomain.CurrentDomain.FriendlyName}"
printfn $"child domain: {domain.FriendlyName}"
// Unload the application domain.
AppDomain.Unload domain

try
    printfn ""
    // Note that the following statement creates an exception because the domain no longer exists.
    printfn $"child domain: {domain.FriendlyName}"

with :? AppDomainUnloadedException ->
    printfn "The appdomain MyDomain does not exist."
//  </SNIPPET1>