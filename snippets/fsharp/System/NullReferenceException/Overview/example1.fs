module Example

// <Snippet1>
open System

[<EntryPoint>]
let main args =
    let value = Int32.Parse args[0]
    // Set names to null, don't initialize it. 
    let mutable names = Unchecked.defaultof<ResizeArray<string>>
    if value > 0 then
        names <- ResizeArray()
    names.Add "Major Major Major"
    0
// Compilation does not display a warning as this is an extremely rare occurance in F#.
// Creating a value without initalizing either requires using 'null' (not possible
// on types defined in F# without [<AllowNullLiteral>]) or Unchecked.defaultof.
//
// The example displays output like the following output:
//    Unhandled Exception: System.NullReferenceException: Object reference
//    not set to an instance of an object.
//       at Example.main()
// </Snippet1>