module equals2

// <Snippet2>
open System
open System.Collections

type DoubleComparer<'T1, 'T2, 'T3, 'T4, 'T5 when 'T1: equality and 'T2: equality and 'T3: equality and 'T4: equality and 'T5: equality>(difference: double) =
    let mutable argument = 0

    interface IEqualityComparer with
        member _.Equals(x, y) =
            argument <- argument + 1
            
            // Return true for Item1.
            if argument = 1 then
                true
            else
                let d1 = x :?> double
                let d2 = y :?> double

                d1 - d2 < d1 * difference

        member _.GetHashCode(obj) =
            match obj with
            | :? 'T1 as obj -> obj.GetHashCode()
            | :? 'T2 as obj -> obj.GetHashCode()
            | :? 'T3 as obj -> obj.GetHashCode()
            | :? 'T4 as obj -> obj.GetHashCode()
            | _ -> (obj :?> 'T5).GetHashCode()   

let getValues ctr =
    // Generate four random numbers between 0 and 1
    let rnd = Random(DateTime.Now.Ticks >>> 32 >>> ctr |> int)
    Tuple.Create(ctr, rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble())

let value1 = getValues 1
let value2 = getValues 2
let iValue1 = value1
printfn $"{value1} =\n{value2} :\n{(DoubleComparer<int, double, double, double, double> 0.01 :> IEqualityComparer).Equals(iValue1, value2)}"
// </Snippet2>