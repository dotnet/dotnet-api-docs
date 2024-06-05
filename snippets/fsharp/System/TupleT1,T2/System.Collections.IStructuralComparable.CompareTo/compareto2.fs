module compareto2

// <Snippet2>
open System
open System.Collections
open System.Collections.Generic

type ScoreComparer<'T1, 'T2>() =
    interface IComparer with
        member _.Compare(x: obj, y: obj) =
            match x with
            | :? Tuple<'T1, 'T2> as tX ->
                let tY = y :?> Tuple<'T1, 'T2>
                Comparer<'T2>.Default.Compare(tX.Item2, tY.Item2)             
            | _ -> 0

let scores = 
    [| Tuple<string, Nullable<int>>("Jack", 78)
       Tuple<string, Nullable<int>>("Abbey", 92) 
       Tuple<string, Nullable<int>>("Dave", 88)
       Tuple<string, Nullable<int>>("Sam", 91) 
       Tuple<string, Nullable<int>>("Ed", Nullable())
       Tuple<string, Nullable<int>>("Penelope", 82)
       Tuple<string, Nullable<int>>("Linda", 99)
       Tuple<string, Nullable<int>>("Judith", 84) |]

printfn "The values in unsorted order:"
for score in scores do
    printfn $"{score}"

printfn ""

Array.Sort(scores, ScoreComparer<string, Nullable<int>>())

printfn "The values in sorted order:"
for score in scores do
    printfn $"{score}"
// The example displays the following output
//       The values in unsorted order:
//       (Jack, 78)
//       (Abbey, 92)
//       (Dave, 88)
//       (Sam, 91)
//       (Ed, )
//       (Penelope, 82)
//       (Linda, 99)
//       (Judith, 84)
//       
//       The values in sorted order:
//       (Ed, )
//       (Jack, 78)
//       (Penelope, 82)
//       (Judith, 84)
//       (Dave, 88)
//       (Sam, 91)
//       (Abbey, 92)
//       (Linda, 99)
// </Snippet2>