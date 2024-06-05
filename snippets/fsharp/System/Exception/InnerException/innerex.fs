module Example

//<Snippet1>
open System

type AppException =
    inherit Exception
    
    new (message: string) = { inherit Exception(message) }

    new (message: string, inner) = { inherit Exception(message, inner) }

let throwInner () =
    raise (AppException "Exception in throwInner function.")
    ()

let catchInner () =
    try
        throwInner ()
    with :? AppException as e ->
        raise (AppException("Error in catchInner caused by calling the throwInner function.", e) )

[<EntryPoint>]
let main _ =
    try
        catchInner ()
    with :? AppException as e ->
        printfn "In with block of main function."
        printfn $"Caught: {e.Message}"
        if e.InnerException <> null then
            printfn $"Inner exception: {e.InnerException}"
    0
// The example displays the following output:
//    In with block of main function.
//    Caught: Error in catchInner caused by calling the throwInner function.
//    Inner exception: Example+AppException: Exception in throwInner function.
//       at Example.throwInner()
//       at Example.catchInner()
// </Snippet1>