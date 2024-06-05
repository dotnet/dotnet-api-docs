module equals2

// <Snippet2>
open System
open System.Collections

type Item3And4Comparer<'T1, 'T2, 'T3, 'T4 when 'T1: equality and 'T2: equality and 'T3: equality and 'T4: equality>() =
    let mutable argument = 0
    interface IEqualityComparer with
        member _.Equals(x: obj, y: obj) =
            argument <- argument + 1
            
            // Return true for all values of Item1, Item2.
            if argument <= 2 then
                true
            else
                x.Equals y
        
        member _.GetHashCode(obj: obj) =
            match obj with
            | :? 'T1 as obj ->
                obj.GetHashCode()
            | :? 'T2 as obj ->
                obj.GetHashCode()
            | :? 'T3 as obj ->
                obj.GetHashCode()
            | _ ->
                (obj :?> 'T4).GetHashCode()

let temperatures = 
    [| Tuple.Create("New York, NY", 4, 61.0, 43.0)
       Tuple.Create("Chicago, IL", 2, 34.0, 18.0) 
       Tuple.Create("Newark, NJ", 4, 61.0, 43.0)
       Tuple.Create("Boston, MA", 6, 77.0, 59.0)
       Tuple.Create("Detroit, MI", 9, 74.0, 53.0)
       Tuple.Create("Minneapolis, MN", 8, 81.0, 61.0) |]
// Compare each item with every other item for equality.
for ctr = 0 to temperatures.Length - 1 do
    let temperatureInfo: IStructuralEquatable = temperatures[ctr]
    for ctr2 = ctr + 1 to temperatures.Length - 1 do
        printfn $"{temperatureInfo} = {temperatures[ctr2]}: {temperatureInfo.Equals(temperatures[ctr2], Item3And4Comparer<string, int, double, double>())}"
    printfn ""                                               
// The example displays the following output:
//    (New York, NY, 4, 61, 43) = (Chicago, IL, 2, 34, 18): False
//    (New York, NY, 4, 61, 43) = (Newark, NJ, 4, 61, 43): True
//    (New York, NY, 4, 61, 43) = (Boston, MA, 6, 77, 59): False
//    (New York, NY, 4, 61, 43) = (Detroit, MI, 9, 74, 53): False
//    (New York, NY, 4, 61, 43) = (Minneapolis, MN, 8, 81, 61): False
//    
//    (Chicago, IL, 2, 34, 18) = (Newark, NJ, 4, 61, 43): False
//    (Chicago, IL, 2, 34, 18) = (Boston, MA, 6, 77, 59): False
//    (Chicago, IL, 2, 34, 18) = (Detroit, MI, 9, 74, 53): False
//    (Chicago, IL, 2, 34, 18) = (Minneapolis, MN, 8, 81, 61): False
//    
//    (Newark, NJ, 4, 61, 43) = (Boston, MA, 6, 77, 59): False
//    (Newark, NJ, 4, 61, 43) = (Detroit, MI, 9, 74, 53): False
//    (Newark, NJ, 4, 61, 43) = (Minneapolis, MN, 8, 81, 61): False
//    
//    (Boston, MA, 6, 77, 59) = (Detroit, MI, 9, 74, 53): False
//    (Boston, MA, 6, 77, 59) = (Minneapolis, MN, 8, 81, 61): False
//    
//    (Detroit, MI, 9, 74, 53) = (Minneapolis, MN, 8, 81, 61): False
// </Snippet2>