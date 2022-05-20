module compareto2

// <Snippet2>
open System
open System.Collections
open System.Collections.Generic

type ScoreComparer<'T1, 'T2, 'T3>() =
    interface IComparer with
        member _.Compare(x: obj, y: obj) =
            match x with
            | :? Tuple<'T1, 'T2, 'T3> as tX -> 
                let tY = y :?> Tuple<'T1, 'T2, 'T3>
                Comparer<'T2>.Default.Compare(tX.Item2, tY.Item2)             
            | _ -> 0

let scores = 
    [| Tuple.Create("Jack", 78.8, 8)
       Tuple.Create("Abbey", 92.1, 9) 
       Tuple.Create("Dave", 88.3, 9)
       Tuple.Create("Sam", 91.7, 8) 
       Tuple.Create("Ed", 71.2, 5)
       Tuple.Create("Penelope", 82.9, 8)
       Tuple.Create("Linda", 99.0, 9)
       Tuple.Create("Judith", 84.3, 9) |]

printfn "The values in unsorted order:"
for score in scores do
    printfn $"{score}"

printfn ""

Array.Sort(scores, ScoreComparer<string, double, int>())

printfn "The values in sorted order:"
for score in scores do
    printfn $"{score}"
// The example displays the following output
//       The values in unsorted order:
//       (Jack, 78.8, 8)
//       (Abbey, 92.1, 9)
//       (Dave, 88.3, 9)
//       (Sam, 91.7, 8)
//       (Ed, 71.2, 5)
//       (Penelope, 82.9, 8)
//       (Linda, 99, 9)
//       (Judith, 84.3, 9)
//       
//       The values in sorted order:
//       (Ed, 71.2, 5)
//       (Jack, 78.8, 8)
//       (Penelope, 82.9, 8)
//       (Judith, 84.3, 9)
//       (Dave, 88.3, 9)
//       (Sam, 91.7, 8)
//       (Abbey, 92.1, 9)
//       (Linda, 99, 9)
// </Snippet2>