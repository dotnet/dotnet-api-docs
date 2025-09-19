module compareto2

// <Snippet2>
open System
open System.Collections
open System.Collections.Generic

type PopulationComparer<'T1, 'T2, 'T3, 'T4, 'T5, 'T6>(comp, descending) =
    let multiplier = if descending then -1 else 1

    do 
        if comp <= 0 || comp > 6 then
            invalidArg "comp" "The component argument is out of range."

    new (comp) = PopulationComparer(comp, true)

    interface IComparer with
        member _.Compare(x, y) =
            match x with 
            | :? Tuple<'T1, 'T2, 'T3, 'T4, 'T5, 'T6> as tX ->
                let tY = y :?> Tuple<'T1, 'T2, 'T3, 'T4, 'T5, 'T6>
                match comp with
                | 1 ->
                    Comparer<'T1>.Default.Compare(tX.Item1, tY.Item1) * multiplier
                | 2 ->
                    Comparer<'T2>.Default.Compare(tX.Item2, tY.Item2) * multiplier
                | 3 ->
                    Comparer<'T3>.Default.Compare(tX.Item3, tY.Item3) * multiplier
                | 4 ->
                    Comparer<'T4>.Default.Compare(tX.Item4, tY.Item4) * multiplier
                | 5 ->
                    Comparer<'T5>.Default.Compare(tX.Item5, tY.Item5) * multiplier
                | 6 ->
                    Comparer<'T6>.Default.Compare(tX.Item6, tY.Item6) * multiplier
                | _ ->
                    Comparer<'T1>.Default.Compare(tX.Item1, tY.Item1) * multiplier
            | _ -> 0

// Create array of sextuple with population data for three U.S.
// cities, 1960-2000.
let cities =
    [| Tuple.Create("Los Angeles", 2479015, 2816061, 2966850, 3485398, 3694820)
       Tuple.Create("New York", 7781984, 7894862, 7071639, 7322564, 8008278)
       Tuple.Create("Chicago", 3550904, 3366957, 3005072, 2783726, 2896016) |]

// Display array in unsorted order.
printfn "In unsorted order:"
for city in cities do
    printfn $"{city}"
printfn ""

Array.Sort(cities, PopulationComparer<string, int, int, int, int, int> 3)

// Display array in sorted order.
printfn "Sorted by population in 1970:"
for city in cities do
    printfn $"{city}"
printfn ""

Array.Sort(cities, PopulationComparer<string, int, int, int, int, int> 6)

// Display array in sorted order.
printfn "Sorted by population in 2000:"
for city in cities do
    printfn $"{city}"
// The example displays the following output:
//    In unsorted order:
//    (Los Angeles, 2479015, 2816061, 2966850, 3485398, 3694820)
//    (New York, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Chicago, 3550904, 3366957, 3005072, 2783726, 2896016)
//    
//    Sorted by population in 1970:
//    (New York, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Chicago, 3550904, 3366957, 3005072, 2783726, 2896016)
//    (Los Angeles, 2479015, 2816061, 2966850, 3485398, 3694820)
//    
//    Sorted by population in 2000:
//    (New York, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Los Angeles, 2479015, 2816061, 2966850, 3485398, 3694820)
//    (Chicago, 3550904, 3366957, 3005072, 2783726, 2896016)
// </Snippet2>