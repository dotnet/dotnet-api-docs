module compareto2

// <Snippet2>
open System
open System.Collections
open System.Collections.Generic

type PitcherComparer<'T1, 'T2, 'T3, 'T4>() =
    interface IComparer with
        member _.Compare(x: obj, y: obj) =
            match x with
            | :? Tuple<'T1, 'T2, 'T3, 'T4> as tX ->
                let tY = y :?> Tuple<'T1, 'T2, 'T3, 'T4>
                Comparer<'T3>.Default.Compare(tX.Item3, tY.Item3)             
            | _ -> 0

let pitchers = 
    [| Tuple.Create("McHale, Joe", 240.1, 3.60, 221)
       Tuple.Create("Paul, Dave", 233.1, 3.24, 231)
       Tuple.Create("Williams, Mike", 193.2, 4.00, 183)
       Tuple.Create("Blair, Jack", 168.1, 3.48, 146)
       Tuple.Create("Henry, Walt", 140.1, 1.92, 96)
       Tuple.Create("Lee, Adam", 137.2, 2.94, 109)
       Tuple.Create("Rohr, Don", 101.0, 3.74, 110) |]

printfn "The values in unsorted order:"
for pitcher in pitchers do
    printfn $"{pitcher}"

printfn ""

Array.Sort(pitchers, PitcherComparer<string, double, double, int>())

printfn "The values sorted by earned run average (component 3):"
for pitcher in pitchers do
    printfn $"{pitcher}"
// The example displays the following output
//       The values in unsorted order:
//       (McHale, Joe, 240.1, 3.6, 221)
//       (Paul, Dave, 233.1, 3.24, 231)
//       (Williams, Mike, 193.2, 4, 183)
//       (Blair, Jack, 168.1, 3.48, 146)
//       (Henry, Walt, 140.1, 1.92, 96)
//       (Lee, Adam, 137.2, 2.94, 109)
//       (Rohr, Don, 101, 3.74, 110)
//       
//       The values sorted by earned run average (component 3):
//       (Henry, Walt, 140.1, 1.92, 96)
//       (Lee, Adam, 137.2, 2.94, 109)
//       (Rohr, Don, 101, 3.74, 110)
//       (Blair, Jack, 168.1, 3.48, 146)
//       (McHale, Joe, 240.1, 3.6, 221)
//       (Paul, Dave, 233.1, 3.24, 231)
//       (Williams, Mike, 193.2, 4, 183)
// </Snippet2>