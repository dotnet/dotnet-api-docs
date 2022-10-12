module equals2

// <Snippet2>
open System
open System.Collections

type Item2Comparer<'T1, 'T2 when 'T1: equality and 'T2: equality>() = 
    interface IEqualityComparer with    
        member _.GetHashCode(obj) =
            match obj with
            | :? 'T1 as obj->
                obj.GetHashCode()
            | _ ->
                (obj :?> 'T2).GetHashCode()

        member _.Equals(x, y) =
            // Return true for all values of Item1.
            match x with
            | :? 'T1 ->
                true
            | _ ->
                x.Equals y

let distancesWalked =
    [| Tuple.Create("Jan", Double.NaN) 
       Tuple.Create("Joe", Double.NaN) 
       Tuple.Create("Adam", 1.36)
       Tuple.Create("Selena", 2.01)
       Tuple.Create("Jake", 1.36) |]

for ctr = 0 to distancesWalked.Length - 1 do
    let distanceWalked = distancesWalked[ctr]
    for ctr2 = ctr + 1 to distancesWalked.Length - 1 do
        printfn $"{distanceWalked} = {distancesWalked[ctr2]}: {(distanceWalked :> IStructuralEquatable).Equals(distancesWalked[ctr2], Item2Comparer<string, double>())}"
    printfn ""
// The example displays the following output:
//       (Jan, NaN) = (Joe, NaN): True
//       (Jan, NaN) = (Adam, 1.36): False
//       (Jan, NaN) = (Selena, 2.01): False
//       (Jan, NaN) = (Jake, 1.36): False
//       
//       (Joe, NaN) = (Adam, 1.36): False
//       (Joe, NaN) = (Selena, 2.01): False
//       (Joe, NaN) = (Jake, 1.36): False
//       
//       (Adam, 1.36) = (Selena, 2.01): False
//       (Adam, 1.36) = (Jake, 1.36): True
//       
//       (Selena, 2.01) = (Jake, 1.36): False
// </Snippet2>