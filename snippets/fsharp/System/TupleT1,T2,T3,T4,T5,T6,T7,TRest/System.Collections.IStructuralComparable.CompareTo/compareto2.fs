module compareto2

// <Snippet2>
open System
open System.Collections
open System.Collections.Generic

type PopulationComparer<'T1, 'T2, 'T3, 'T4, 'T5, 'T6, 'T7, 'T8>(itemPosition, descending) =
    let multiplier = if descending then -1 else 1

    do 
        if itemPosition <= 0 || itemPosition > 8 then
            invalidArg "itemPosition" "The component argument is out of range."
    new(itemPosition) = PopulationComparer (itemPosition, true)

    interface IComparer with
        member _.Compare(x, y) =
            match x with
            | :? Tuple<'T1, 'T2, 'T3, 'T4, 'T5, 'T6, 'T7, Tuple<'T8>> as tX ->
                let tY = y :?> Tuple<'T1, 'T2, 'T3, 'T4, 'T5, 'T6, 'T7, Tuple<'T8>>
                match itemPosition with
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
                | 7 ->
                    Comparer<'T7>.Default.Compare(tX.Item7, tY.Item7) * multiplier
                | 8 ->
                    Comparer<'T8>.Default.Compare(tX.Rest.Item1, tY.Rest.Item1) * multiplier
                | _ ->
                    Comparer<'T1>.Default.Compare(tX.Item1, tY.Item1) * multiplier
            | _ -> 0

// Create array of octuples with population data for three U.S. 
// cities, 1940-2000.
let cities  = 
    [| Tuple.Create("Los Angeles", 1504277, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
       Tuple.Create("Chicago", 3396808, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)  
       Tuple.Create("New York", 7454995, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)  
       Tuple.Create("Detroit", 1623452, 1849568, 1670144, 1511462, 1203339, 1027974, 951270) |]
// Display array in unsorted order.
printfn "In unsorted order:"
for city in cities do
    printfn $"{city}"
printfn ""

Array.Sort(cities, PopulationComparer<string, int, int, int, int, int, int, int> 2)

// Display array in sorted order.
printfn "Sorted by population in 1950:"
for city in cities do
    printfn $"{city}"
printfn ""

Array.Sort(cities, PopulationComparer<string, int, int, int, int, int, int, int>(8))
                    
// Display array in sorted order.
printfn "Sorted by population in 2000:"
for city in cities do
    printfn $"{city}"
// The example displays the following output:
//    In unsorted order:
//    (Los Angeles, 1504277, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
//    (New York, 7454995, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Chicago, 3396808, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)
//    (Detroit, 1623452, 1849568, 1670144, 1511462, 1203339, 1027974, 951270)
//    
//    Sorted by population in 1950:
//    (New York, 7454995, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Chicago, 3396808, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)
//    (Detroit, 1623452, 1849568, 1670144, 1511462, 1203339, 1027974, 951270)
//    (Los Angeles, 1504277, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
//    
//    Sorted by population in 2000:
//    (New York, 7454995, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Los Angeles, 1504277, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
//    (Chicago, 3396808, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)
//    (Detroit, 1623452, 1849568, 1670144, 1511462, 1203339, 1027974, 951270)
// </Snippet2>