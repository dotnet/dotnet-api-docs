module failfast1

// <Snippet2>
open System

try
    // Outer block to handle any unexpected exceptions.
    try
        let s = "This"
        let s = s.Insert(2, "is ")

        // Throw an OutOfMemoryException exception.
        raise (OutOfMemoryException())
    with
    | :? ArgumentException ->
        printfn "ArgumentException in String.Insert"

    // Execute program logic.
with :? OutOfMemoryException as e ->
    printfn "Terminating application unexpectedly..."
    Environment.FailFast $"Out of Memory: {e.Message}"
// The example displays the following output:
//        Terminating application unexpectedly...
// </Snippet2>