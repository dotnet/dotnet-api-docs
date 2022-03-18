//<Snippet1>
open System

[<EntryPoint>]
let main _ =
    let names = [| "Dog"; "Cat"; "Fish" |]
    let objs = box names :?> obj[]

    try
        objs[2] <- "Mouse"

        for animalName in objs do
            printfn $"{animalName}"
                    
    with :? ArrayTypeMismatchException ->
        // Not reached; "Mouse" is of the correct type.
        printfn "Exception Thrown."

    try
        let obj = 13 :> obj
        objs[2] <- obj
    with :? ArrayTypeMismatchException ->
        // Always reached, 13 is not a string.
        printfn "New element is not of the correct type."

    // Shadow objs as an array of objects instead of an array of strings.
    let objs: obj[] = [| "Turtle"; 12; 2.341 |]
    try
        for element in objs do
            printfn $"{element}"
        
    with :? ArrayTypeMismatchException ->
        // ArrayTypeMismatchException is not thrown this time.
        printfn "Exception Thrown."

    0
//</Snippet1>