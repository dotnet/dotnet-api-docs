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

Array.FindIndex(dinosaurs, endsWithSaurus)
|> printfn "\nArray.FindIndex(dinosaurs, EndsWithSaurus): %i"

Array.FindIndex(dinosaurs, 2, endsWithSaurus)
|> printfn "\nArray.FindIndex(dinosaurs, 2, EndsWithSaurus): %i"

Array.FindIndex(dinosaurs, 2, 3, endsWithSaurus)
|> printfn "\nArray.FindIndex(dinosaurs, 2, 3, EndsWithSaurus): %i"


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
//     Array.FindIndex(dinosaurs, EndsWithSaurus): 1
//
//     Array.FindIndex(dinosaurs, 2, EndsWithSaurus): 5
//
//     Array.FindIndex(dinosaurs, 2, 3, EndsWithSaurus): -1

// </Snippet1>
