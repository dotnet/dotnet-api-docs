module source2

//<snippet4>
open System

let instanceSpec =
    "System.EventArgs;System.Random;System.Exception;System.Object;System.Version"

let instances = instanceSpec.Split ';'
let instlist = Array.zeroCreate instances.Length
let mutable item = obj ()

for i = 0 to instances.Length - 1 do
    // create the object from the specification string
    printfn $"Creating instance of: {instances.[i]}"
    item <- Activator.CreateInstance(Type.GetType instances.[i])
    instlist.[i] <- item

printfn "\nObjects and their default values:\n"

for o in instlist do
    printfn $"Type:     {o.GetType().FullName}\nValue:    {o}\nHashCode: {o.GetHashCode()}\n"


// This program will display output similar to the following:
//
// Creating instance of: System.EventArgs
// Creating instance of: System.Random
// Creating instance of: System.Exception
// Creating instance of: System.Object
// Creating instance of: System.Version
//
// Objects and their default values:
//
// Type:     System.EventArgs
// Value:    System.EventArgs
// HashCode: 46104728
//
// Type:     System.Random
// Value:    System.Random
// HashCode: 12289376
//
// Type:     System.Exception
// Value:    System.Exception: Exception of type 'System.Exception' was thrown.
// HashCode: 55530882
//
// Type:     System.Object
// Value:    System.Object
// HashCode: 30015890
//
// Type:     System.Version
// Value:    0.0
// HashCode: 1048575
//</snippet4>
