// <Snippet1>
open System
open System.Collections.Generic

type ReverseComparer() =
    interface  IComparer<string> with
        member _.Compare(x, y) =
            y.CompareTo x

let dinosaurs = 
    [| "Pachycephalosaurus"
       "Amargasaurus"
       "Mamenchisaurus"
       "Tarbosaurus"
       "Tyrannosaurus"
       "Albertasaurus" |]

printfn ""
for dino in dinosaurs do
    printfn $"{dino}"

printfn "\nSort(dinosaurs, 3, 3)"
Array.Sort(dinosaurs, 3, 3)

printfn ""
for dino in dinosaurs do
    printfn $"{dino}"

let rc = ReverseComparer()

printfn "\nSort(dinosaurs, 3, 3, rc)"
Array.Sort(dinosaurs, 3, 3, rc)

printfn ""
for dino in dinosaurs do
    printfn $"{dino}"


// This code example produces the following output:
//
//    Pachycephalosaurus
//    Amargasaurus
//    Mamenchisaurus
//    Tarbosaurus
//    Tyrannosaurus
//    Albertasaurus
//    
//    Sort(dinosaurs, 3, 3)
//    
//    Pachycephalosaurus
//    Amargasaurus
//    Mamenchisaurus
//    Albertasaurus
//    Tarbosaurus
//    Tyrannosaurus
//    
//    Sort(dinosaurs, 3, 3, rc)
//    
//    Pachycephalosaurus
//    Amargasaurus
//    Mamenchisaurus
//    Tyrannosaurus
//    Tarbosaurus
//    Albertasaurus

// </Snippet1>