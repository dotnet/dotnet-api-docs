// <Snippet1>
open System

type Comparison =
    | LessThan = -1 
    | Equal = 0
    | GreaterThan = 1

let mainValue = 16325
let zeroValue = 0
let negativeValue = -1934
let positiveValue = 903624
let sameValue = 16325

printfn $"Comparing {mainValue} and {zeroValue}: {mainValue.CompareTo zeroValue} ({enum<Comparison>(mainValue.CompareTo zeroValue)})."

printfn $"Comparing {mainValue} and {sameValue}: {mainValue.CompareTo sameValue} ({enum<Comparison>(mainValue.CompareTo sameValue)})."

printfn $"Comparing {mainValue} and {negativeValue}: {mainValue.CompareTo negativeValue} ({enum<Comparison>(mainValue.CompareTo negativeValue)})." 

printfn $"Comparing {mainValue} and {positiveValue}: {mainValue.CompareTo positiveValue} ({enum<Comparison>(mainValue.CompareTo positiveValue)})."

// The example displays the following output:
//       Comparing 16325 and 0: 1 (GreaterThan).
//       Comparing 16325 and 16325: 0 (Equal).
//       Comparing 16325 and -1934: 1 (GreaterThan).
//       Comparing 16325 and 903624: -1 (LessThan).
// </Snippet1>
