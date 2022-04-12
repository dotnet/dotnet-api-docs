module equals2

// <Snippet2>
open System
open System.Collections

type Item2Comparer<'T1, 'T2, 'T3 when 'T1: equality and 'T2: equality and 'T3: equality>() =
    interface IEqualityComparer with
        member _.Equals(x: obj, y: obj) =
            // Return true for all values of Item1.
            match x with
            | :? 'T1 ->
                true
            | :? 'T2 ->
                x.Equals y
            | _ -> true
   
        member _.GetHashCode(obj: obj) =
            match obj with
            | :? 'T1 as obj->
                obj.GetHashCode()
            | :? 'T2 as obj ->
                obj.GetHashCode()
            | _ ->
                (obj :?> 'T3).GetHashCode()

let scores = 
    [| Tuple.Create("Ed", 78.8, 8)
       Tuple.Create("Abbey", 92.1, 9) 
       Tuple.Create("Jim", 71.2, 9)
       Tuple.Create("Sam", 91.7, 8)
       Tuple.Create("Sandy", 71.2, 5)
       Tuple.Create("Penelope", 82.9, 8)
       Tuple.Create("Serena", 71.2, 9)
       Tuple.Create("Judith", 84.3, 9) |]

for ctr = 0 to scores.Length - 1 do
    let score : IStructuralEquatable = scores[ctr]
    for ctr2 = ctr + 1 to scores.Length - 1 do
        printfn $"{score} = {scores[ctr2]}: {score.Equals(scores[ctr2], Item2Comparer<string, double, int>())}"
    printfn ""
// The example displays the following output:
//      (Ed, 78.8, 8) = (Abbey, 92.1, 9): False
//      (Ed, 78.8, 8) = (Jim, 71.2, 9): False
//      (Ed, 78.8, 8) = (Sam, 91.7, 8): False
//      (Ed, 78.8, 8) = (Sandy, 71.2, 5): False
//      (Ed, 78.8, 8) = (Penelope, 82.9, 8): False
//      (Ed, 78.8, 8) = (Serena, 71.2, 9): False
//      (Ed, 78.8, 8) = (Judith, 84.3, 9): False
//
//      (Abbey, 92.1, 9) = (Jim, 71.2, 9): False
//      (Abbey, 92.1, 9) = (Sam, 91.7, 8): False
//      (Abbey, 92.1, 9) = (Sandy, 71.2, 5): False
//      (Abbey, 92.1, 9) = (Penelope, 82.9, 8): False
//      (Abbey, 92.1, 9) = (Serena, 71.2, 9): False
//      (Abbey, 92.1, 9) = (Judith, 84.3, 9): False
//      
//      (Jim, 71.2, 9) = (Sam, 91.7, 8): False
//      (Jim, 71.2, 9) = (Sandy, 71.2, 5): True
//      (Jim, 71.2, 9) = (Penelope, 82.9, 8): False
//      (Jim, 71.2, 9) = (Serena, 71.2, 9): True
//      (Jim, 71.2, 9) = (Judith, 84.3, 9): False
//
//      (Sam, 91.7, 8) = (Sandy, 71.2, 5): False
//      (Sam, 91.7, 8) = (Penelope, 82.9, 8): False
//      (Sam, 91.7, 8) = (Serena, 71.2, 9): False
//      (Sam, 91.7, 8) = (Judith, 84.3, 9): False
//
//      (Sandy, 71.2, 5) = (Penelope, 82.9, 8): False
//      (Sandy, 71.2, 5) = (Serena, 71.2, 9): True
//      (Sandy, 71.2, 5) = (Judith, 84.3, 9): False
//
//      (Penelope, 82.9, 8) = (Serena, 71.2, 9): False
//      (Penelope, 82.9, 8) = (Judith, 84.3, 9): False
//
//      (Serena, 71.2, 9) = (Judith, 84.3, 9): False
// </Snippet2>