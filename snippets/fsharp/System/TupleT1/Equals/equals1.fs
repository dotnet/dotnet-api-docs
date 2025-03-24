module equals1

// <Snippet1>
open System

let testEquality (tuple: Tuple<double>) (obj: obj) =
    printfn $"{tuple} = {obj}: {tuple.Equals obj}"

let doubleTuple1 = Tuple.Create 12.3455
let doubleTuple2 = Tuple.Create 16.8912
let doubleTuple3 = Tuple.Create 12.3455
let singleTuple1 = Tuple.Create 12.3455f
let tuple2 = Tuple.Create("James", 97.3) 

// Compare first tuple with a Tuple(Of Double) with a different value.
testEquality doubleTuple1 doubleTuple2
// Compare first tuple with a Tuple(Of Double) with the same value.
testEquality doubleTuple1 doubleTuple3
// Compare first tuple with a Tuple(Of Single) with the same value.
testEquality doubleTuple1 singleTuple1
// Compare a 1-tuple with a 2-tuple.
testEquality doubleTuple1 tuple2 

// The example displays the following output:
//       (12.3455) = (16.8912): False
//       (12.3455) = (12.3455): True
//       (12.3455) = (12.3455): False
//       (12.3455) = (James, 97.3): False
// </Snippet1>