// <Snippet1>
open System

let futureFeature () =
    // Not developed yet.
    raise (NotImplementedException())

[<EntryPoint>]
let main _ =
    try
        futureFeature ()
    with :? NotImplementedException as notImp ->
        printfn $"{notImp.Message}"
    0
//</Snippet1>