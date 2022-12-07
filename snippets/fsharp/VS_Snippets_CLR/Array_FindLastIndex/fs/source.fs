// <Snippet1>
open System

// Search predicate returns true if a string ends in "saurus".
let endsWithSaurus (s: string) =
    s.Length > 5 && s.Substring(s.Length - 6).ToLower() = "saurus"

let dinosaurs =
    [| "Compsognathus"; "Amargasaurus"
       "Oviraptor"; "Velociraptor"
       "Deinonychus"; "Dilophosaurus"
       "Gallimimus"; "Triceratops" |]

printfn ""
for dino in dinosaurs do
    printfn $"{dino}"

Array.FindLastIndex(dinosaurs, endsWithSaurus)
|> printfn "\nArray.FindLastIndex(dinosaurs, EndsWithSaurus): %i"

Array.FindLastIndex(dinosaurs, 4, endsWithSaurus)
|> printfn "\nArray.FindLastIndex(dinosaurs, 4, EndsWithSaurus): %i"

Array.FindLastIndex(dinosaurs, 4, 3, endsWithSaurus)
|> printfn "\nArray.FindLastIndex(dinosaurs, 4, 3, EndsWithSaurus): %i"


// This code example produces the following output:
//
//     Compsognathus
//     Amargasaurus
//     Oviraptor
//     Velociraptor
//     Deinonychus
//     Dilophosaurus
//     Gallimimus
//     Triceratops
//
//     Array.FindLastIndex(dinosaurs, EndsWithSaurus): 5
//
//     Array.FindLastIndex(dinosaurs, 4, EndsWithSaurus): 1
//
//     Array.FindLastIndex(dinosaurs, 4, 3, EndsWithSaurus): -1

// </Snippet1>
