// <Snippet1>
open System
open System.Collections.Generic

type ReverseComparer() =
    interface IComparer<string> with
        member _.Compare(x, y) =
            // Compare y and x in reverse order.
            y.CompareTo x

let showWhere (array: 'a []) index =
    if index < 0 then
        // If the index is negative, it represents the bitwise
        // complement of the next larger element in the array.
        let index = ~~~index

        printf "Not found. Sorts between: "

        if index = 0 then
            printf "beginning of array and "
        else
            printf $"{array[index - 1]} and "

        if index = array.Length then
            printfn "end of array."
        else
            printfn $"{array[index]}."
    else
        printfn $"Found at index {index}."

let dinosaurs =
    [| "Pachycephalosaurus"
       "Amargasaurus"
       "Tyrannosaurus"
       "Mamenchisaurus"
       "Deinonychus"
       "Edmontosaurus" |]

printfn ""
for dino in dinosaurs do
    printfn $"{dino}"

let rc = ReverseComparer()

printfn "\nSort"
Array.Sort(dinosaurs, rc)

printfn ""
for dino in dinosaurs do
    printfn $"{dino}"

printfn "\nBinarySearch for 'Coelophysis':"
Array.BinarySearch(dinosaurs, "Coelophysis", rc)
|> showWhere dinosaurs

printfn "\nBinarySearch for 'Tyrannosaurus':"
Array.BinarySearch(dinosaurs, "Tyrannosaurus", rc)
|> showWhere dinosaurs


// This code example produces the following output:
//     Pachycephalosaurus
//     Amargasaurus
//     Tyrannosaurus
//     Mamenchisaurus
//     Deinonychus
//     Edmontosaurus
//
//     Sort
//
//     Tyrannosaurus
//     Pachycephalosaurus
//     Mamenchisaurus
//     Edmontosaurus
//     Deinonychus
//     Amargasaurus
//
//     BinarySearch for 'Coelophysis':
//     Not found. Sorts between: Deinonychus and Amargasaurus.
//
//     BinarySearch for 'Tyrannosaurus':
//     Found at index 0.

// </Snippet1>
