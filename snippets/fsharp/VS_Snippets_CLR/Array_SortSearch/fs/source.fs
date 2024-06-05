// <Snippet1>
open System

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

printfn "\nSort"
Array.Sort dinosaurs

printfn ""
for dino in dinosaurs do
    printfn $"{dino}"

printfn "\nBinarySearch for 'Coelophysis':"
let index = Array.BinarySearch(dinosaurs, "Coelophysis")
showWhere dinosaurs index

printfn "\nBinarySearch for 'Tyrannosaurus':"
Array.BinarySearch(dinosaurs, "Tyrannosaurus")
|> showWhere dinosaurs


// This code example produces the following output:
//
//     Pachycephalosaurus
//     Amargasaurus
//     Tyrannosaurus
//     Mamenchisaurus
//     Deinonychus
//     Edmontosaurus
//
//     Sort
//
//     Amargasaurus
//     Deinonychus
//     Edmontosaurus
//     Mamenchisaurus
//     Pachycephalosaurus
//     Tyrannosaurus
//
//     BinarySearch for 'Coelophysis':
//     Not found. Sorts between: Amargasaurus and Deinonychus.
//
//     BinarySearch for 'Tyrannosaurus':
//     Found at index 5.

// </Snippet1>
