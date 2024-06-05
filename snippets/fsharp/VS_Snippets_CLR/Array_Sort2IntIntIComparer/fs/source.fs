// <Snippet1>
open System
open System.Collections.Generic

type ReverseComparer() =
    interface IComparer<string> with
        member _.Compare(x, y) =
            y.CompareTo x

let dinosaurs =
    [| "Seismosaurus"
       "Chasmosaurus"
       "Coelophysis"
       "Mamenchisaurus"
       "Caudipteryx"
       "Cetiosaurus" |]

let dinosaurSizes = [| 40; 5; 3; 22; 1; 18 |]

printfn ""
for i = 0 to dinosaurs.Length - 1 do
    printfn $"{dinosaurs[i]}: up to {dinosaurSizes[i]} meters long."

printfn "\nSort(dinosaurs, dinosaurSizes)"
Array.Sort(dinosaurs, dinosaurSizes)

printfn ""
for i = 0 to dinosaurs.Length - 1 do
    printfn $"{dinosaurs[i]}: up to {dinosaurSizes[i]} meters long."

let rc = ReverseComparer()

printfn "\nSort(dinosaurs, dinosaurSizes, rc)"
Array.Sort(dinosaurs, dinosaurSizes, rc)

printfn ""
for i = 0 to dinosaurs.Length - 1 do
    printfn $"{dinosaurs[i]}: up to {dinosaurSizes[i]} meters long."

printfn "\nSort(dinosaurs, dinosaurSizes, 3, 3)"
Array.Sort(dinosaurs, dinosaurSizes, 3, 3)

printfn ""
for i = 0 to dinosaurs.Length - 1 do
    printfn $"{dinosaurs[i]}: up to {dinosaurSizes[i]} meters long."

printfn "\nSort(dinosaurs, dinosaurSizes, 3, 3, rc)"
Array.Sort(dinosaurs, dinosaurSizes, 3, 3, rc)

printfn ""
for i = 0 to dinosaurs.Length - 1 do
    printfn $"{dinosaurs[i]}: up to {dinosaurSizes[i]} meters long."

// This code example produces the following output:
//
//    Seismosaurus: up to 40 meters long.
//    Chasmosaurus: up to 5 meters long.
//    Coelophysis: up to 3 meters long.
//    Mamenchisaurus: up to 22 meters long.
//    Caudipteryx: up to 1 meters long.
//    Cetiosaurus: up to 18 meters long.
//    
//    Sort(dinosaurs, dinosaurSizes)
//    
//    Caudipteryx: up to 1 meters long.
//    Cetiosaurus: up to 18 meters long.
//    Chasmosaurus: up to 5 meters long.
//    Coelophysis: up to 3 meters long.
//    Mamenchisaurus: up to 22 meters long.
//    Seismosaurus: up to 40 meters long.
//    
//    Sort(dinosaurs, dinosaurSizes, rc)
//    
//    Seismosaurus: up to 40 meters long.
//    Mamenchisaurus: up to 22 meters long.
//    Coelophysis: up to 3 meters long.
//    Chasmosaurus: up to 5 meters long.
//    Cetiosaurus: up to 18 meters long.
//    Caudipteryx: up to 1 meters long.
//    
//    Sort(dinosaurs, dinosaurSizes, 3, 3)
//    
//    Seismosaurus: up to 40 meters long.
//    Mamenchisaurus: up to 22 meters long.
//    Coelophysis: up to 3 meters long.
//    Caudipteryx: up to 1 meters long.
//    Cetiosaurus: up to 18 meters long.
//    Chasmosaurus: up to 5 meters long.
//    
//    Sort(dinosaurs, dinosaurSizes, 3, 3, rc)
//    
//    Seismosaurus: up to 40 meters long.
//    Mamenchisaurus: up to 22 meters long.
//    Coelophysis: up to 3 meters long.
//    Chasmosaurus: up to 5 meters long.
//    Cetiosaurus: up to 18 meters long.
//    Caudipteryx: up to 1 meters long.

// </Snippet1>