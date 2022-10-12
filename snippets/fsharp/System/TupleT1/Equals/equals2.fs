module equals2

// <Snippet2>
open System
open System.Collections

type Tuple1Comparer() =
    interface IEqualityComparer with
        member _.Equals(x: obj, y: obj) =
            match x with
            | :? double as dblX -> 
                // Convert to Double values.
                let dblY = y :?> double
                if Double.IsNaN dblX || Double.IsInfinity dblX ||
                    Double.IsNaN dblY || Double.IsInfinity dblY then
                    dblX.Equals dblY
                else
                    abs (dblX - dblY) <= dblX * 0.0001
            | _ ->
                x.Equals y
                
        member _.GetHashCode(obj: obj) =
            obj.GetHashCode()

let testEquality (tuple: Tuple<double>) (obj: obj) =
    printfn $"{tuple} = {obj}: {(tuple :> IStructuralEquatable).Equals(obj, Tuple1Comparer())}"

let doubleTuple1 = Tuple.Create 12.3455
let doubleTuple2 = Tuple.Create 16.8912
let doubleTuple3 = Tuple.Create 12.3449599

// Compare first tuple with a Tuple<double> with a different value.
testEquality doubleTuple1 doubleTuple2
//Compare first tuple with a Tuple<double> with the same value.
testEquality doubleTuple1 doubleTuple3

// The example displays the following output:
//       (12.3455) = (16.8912): False
//       (12.3455) = (12.3449599): True
// </Snippet2>