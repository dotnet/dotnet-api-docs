
// This function takes a file's creation time as an unsigned long,
// and returns its age.
//<Snippet1>
open System

let fileAge fileCreationTime =
    let now = DateTime.Now
    try
        let fCreationTime =
            DateTime.FromFileTime fileCreationTime
        now.Subtract fCreationTime
    with :? ArgumentOutOfRangeException ->
        // fileCreationTime is not valid, so re-raise the exception.
        reraise ()
//</Snippet1>
