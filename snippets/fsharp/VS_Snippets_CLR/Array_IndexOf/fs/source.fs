// <Snippet1>
open System

let dinosaurs =
    [| "Tyrannosaurus"
       "Amargasaurus"
       "Mamenchisaurus"
       "Brachiosaurus"
       "Deinonychus"
       "Tyrannosaurus"
       "Compsognathus" |]

printfn ""
for dino in dinosaurs do
    printfn $"{dino}"

Array.IndexOf(dinosaurs, "Tyrannosaurus")
|> printfn "\nArray.IndexOf(dinosaurs, \"Tyrannosaurus\"): %i"

Array.IndexOf(dinosaurs, "Tyrannosaurus", 3)
|> printfn "\nArray.IndexOf(dinosaurs, \"Tyrannosaurus\", 3): %i"

Array.IndexOf(dinosaurs, "Tyrannosaurus", 2, 2)
|> printfn "\nArray.IndexOf(dinosaurs, \"Tyrannosaurus\", 2, 2): %i"

// This code example produces the following output:
//
//    Tyrannosaurus
//    Amargasaurus
//    Mamenchisaurus
//    Brachiosaurus
//    Deinonychus
//    Tyrannosaurus
//    Compsognathus
//    
//    Array.IndexOf(dinosaurs, "Tyrannosaurus"): 0
//
//    Array.IndexOf(dinosaurs, "Tyrannosaurus", 3): 5
//
//    Array.IndexOf(dinosaurs, "Tyrannosaurus", 2, 2): -1

// </Snippet1>