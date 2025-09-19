//<Snippet1>
let myArray = [| 1; 2; 4|]
lock myArray.SyncRoot (fun () ->
    for item in myArray do
        printfn $"{item}" )
        
//</Snippet1>
    