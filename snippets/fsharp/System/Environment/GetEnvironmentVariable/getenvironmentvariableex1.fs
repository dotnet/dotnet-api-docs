module Example

open System

let mutable toDelete = false

// Check whether the environment variable exists.
let value = 
    let v = Environment.GetEnvironmentVariable "Test1"
    // If necessary, create it.
    if isNull v then
        Environment.SetEnvironmentVariable("Test1", "Value1")
        toDelete <- true
        Environment.GetEnvironmentVariable "Test1"
    else 
        v

// Display the value.
printfn $"Test1: {value}\n"

// Confirm that the value can only be retrieved from the process
// environment block if running on a Windows system.
if Environment.OSVersion.Platform = PlatformID.Win32NT then
    printfn "Attempting to retrieve Test1 from:"
    for enumValue in Enum.GetValues typeof<EnvironmentVariableTarget> do
        let value = Environment.GetEnvironmentVariable("Test1", enumValue :?> EnvironmentVariableTarget)
        printfn $"""   {enumValue}: {if value <> null then "found" else "not found"}"""
    printfn ""

// If we've created it, now delete it.
if toDelete then
    Environment.SetEnvironmentVariable("Test1", null)
    // Confirm the deletion.
    if Environment.GetEnvironmentVariable "Test1" |> isNull then
        printfn "Test1 has been deleted."
// The example displays the following output if run on a Windows system:
//      Test1: Value1
//
//      Attempting to retrieve Test1 from:
//         Process: found
//         User: not found
//         Machine: not found
//
//      Test1 has been deleted.
//
// The example displays the following output if run on a Unix-based system:
//      Test1: Value1
//
//      Test1 has been deleted.