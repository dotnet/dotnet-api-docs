module compareto2

// <Snippet2>
open System
open System.Collections.Generic

type DescendingComparer<'T>() =
    interface IComparer<'T> with
        member _.Compare(x: 'T, y: 'T) = 
            -1 * Comparer<'T>.Default.Compare(x, y)

let values = 
    [| Tuple.Create 13.54
       Tuple.Create Double.NaN
       Tuple.Create -189.42993
       Tuple.Create Double.PositiveInfinity
       Tuple.Create Double.Epsilon
       Tuple.Create 1.934E-17
       Tuple.Create Double.NegativeInfinity
       Tuple.Create -0.000000000003588
       null |]
printfn "The values in unsorted order:"
for value in values do
    printfn $"   %A{value.Item1}"
printfn ""

Array.Sort(values, DescendingComparer<Tuple<Double>>())

printfn "The values sorted in descending order:"
for value in values do
    printfn $"   %A{value.Item1}"
// The example displays the following output:
//      The values in unsorted order:
//         13.54
//         NaN
//         -189.42993
//         Infinity
//         4.94065645841247E-324
//         1.934E-17
//         -Infinity
//         -3.588E-12
//         <null>
//
//      The values sorted in descending order:
//         Infinity
//         13.54
//         1.934E-17
//         4.94065645841247E-324
//         -3.588E-12
//         -189.42993
//         -Infinity
//         NaN
//         <null>
// </Snippet2>