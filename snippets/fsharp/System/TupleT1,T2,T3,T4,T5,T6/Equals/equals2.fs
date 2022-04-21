// <Snippet2>
open System
open System.Collections

type RateComparer<'T1, 'T2, 'T3, 'T4, 'T5, 'T6>() =
    let mutable argument = 0

    interface IEqualityComparer with
        member _.Equals(x, y) = 
            argument <- argument + 1
            if argument = 1 then true
            else
                match x with
                | :? double as fx ->
                    let fy = y :?> double
                    Math.Round(fx * 1000.).Equals(Math.Round(fy * 1000.))
                | _ ->
                    x.Equals y
        
        member _.GetHashCode(obj) =
            if obj :? Single || obj :? Double then
                Math.Round((obj :?> double) * 1000.).GetHashCode()
            else
                obj.GetHashCode()

let rate1 = Tuple.Create("New York", 0.014505, -0.1042733, 0.0354833, 0.093644, 0.0290792)
let rate2 = Tuple.Create("Unknown City", 0.014505, -0.1042733, 0.0354833, 0.093644, 0.0290792)
let rate3 = Tuple.Create("Unknown City", 0.014505, -0.1042733, 0.0354833, 0.093644, 0.029079)
let rate4 = Tuple.Create("San Francisco", -0.0332858, -0.0512803, 0.0662544, 0.0728964, 0.0491912)
let eq: IStructuralEquatable = rate1
// Compare first tuple with remaining two tuples.
printfn $"{rate1} = "
printfn $"   {rate2} : {eq.Equals(rate2, RateComparer<string, double, double, double, double, double>())}"
printfn $"   {rate3} : {eq.Equals(rate3, RateComparer<string, double, double, double, double, double>())}"
printfn $"   {rate4} : {eq.Equals(rate4, RateComparer<string, double, double, double, double, double>())}"
// The example displays the following output:
//    (New York, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.0290792) =
//       (Unknown City, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.0290792) : True
//       (Unknown City, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.029079) : True
//       (San Francisco, -0.0332858, -0.0512803, 0.0662544, 0.0728964, 0.0491912) : False
// </Snippet2>