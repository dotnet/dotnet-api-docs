//<snippet1>
// This example demonstrates the OperatingSystem.ServicePack property.
open System

let os = Environment.OSVersion
let sp = os.ServicePack
printfn $"Service pack version = \"{sp}\""
// This example produces the following results:
//     Service pack version = "Service Pack 1"
//</snippet1>