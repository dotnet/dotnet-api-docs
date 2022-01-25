// <Snippet1>
open System

let names = 
    [| "Adam"; "Bruce"; "Charles"; "Daniel"
       "Ebenezer"; "Francis"; "Gilbert"
       "Henry"; "Irving"; "John"; "Karl"
       "Lucian"; "Michael" |]

let partNames = ArraySegment<string>(names, 2, 5)

// Enumerate over the ArraySegment object.
for part in partNames do 
    printfn $"{part}"

// The example displays the following output:
//    Charles
//    Daniel
//    Ebenezer
//    Francis
//    Gilbert
// </Snippet1>