// <Snippet1>
open System

type Relationship =
    | LessThan = -1
    | Equals = 0
    | GreaterThan = 1

[<EntryPoint>]
let main _ =
    let value1 = Decimal.MaxValue
    let value2 = value1 - 0.01m
    printfn $"{value1} {Decimal.Compare(value1, value2) |> enum<Relationship>} {value2}"

    let value2 = value1 / 12m - 0.1m
    let value1 = value1 / 12m
    printfn $"{value1} {Decimal.Compare(value1, value2) |> enum<Relationship>} {value2}"

    let value1 = value1 - 0.2m
    let value2 = value2 + 0.1m
    printfn $"{value1} {Decimal.Compare(value1, value2) |> enum<Relationship>} {value2}"

    0

// The example displays the following output:
//     79228162514264337593543950335 Equals 79228162514264337593543950335
//     6602346876188694799461995861.2 GreaterThan 6602346876188694799461995861.1
//     6602346876188694799461995861.0 LessThan 6602346876188694799461995861.2
// </Snippet1> 