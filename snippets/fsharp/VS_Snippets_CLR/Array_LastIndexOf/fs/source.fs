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

Array.LastIndexOf(dinosaurs, "Tyrannosaurus")
|> printfn "\nArray.LastIndexOf(dinosaurs, \"Tyrannosaurus\"): %i"

Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 3)
|> printfn "\nArray.LastIndexOf(dinosaurs, \"Tyrannosaurus\", 3): %i"

Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 4, 4)
|> printfn "\nArray.LastIndexOf(dinosaurs, \"Tyrannosaurus\", 4, 4): %i"

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
//    Array.LastIndexOf(dinosaurs, "Tyrannosaurus"): 5
//
//    Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 3): 0
//
//    Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 4, 4): -1

// </Snippet1>