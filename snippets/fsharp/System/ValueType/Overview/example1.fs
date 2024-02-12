// <Snippet1>
open System
open System.Numerics

module Utility =
    type NumericRelationship =
        | GreaterThan = 1 
        | EqualTo = 0
        | LessThan = -1
   
    let isInteger (value: ValueType) =
        match value with
        | :? sbyte | :? int16 | :? int32 | :? int64 
        | :? byte | :? uint16  | :? uint32 
        | :? uint64 | :? bigint -> true
        | _ -> false

    let isFloat (value: ValueType) = 
        match value with
        | :? float32 | :? float | :? decimal -> true
        | _ -> false

    let tryToBigInt (value: ValueType) =
        match value with
        | :? sbyte as v -> bigint v |> Some
        | :? int16 as v -> bigint v |> Some
        | :? int32 as v -> bigint v |> Some
        | :? int64 as v -> bigint v |> Some
        | :? byte as v -> bigint v |> Some
        | :? uint16 as v -> bigint v |> Some
        | :? uint32 as v -> bigint v |> Some
        | :? uint64 as v -> bigint v |> Some
        | :? float32 as v -> bigint v |> Some
        | _ -> None

    let isNumeric (value: ValueType) =
        isInteger value || isFloat value

    let compare (value1: ValueType) (value2: ValueType) =
        if isNumeric value1 |> not then
            invalidArg "value1" "value1 is not a number."
        elif isNumeric value2 |> not then
            invalidArg "value2" "value2 is not a number."

        // Use BigInteger as common integral type
        match tryToBigInt value1, tryToBigInt value2 with
        | Some bigint1, Some bigint2 ->
            BigInteger.Compare(bigint1, bigint2) |> enum<NumericRelationship>

        // At least one value is floating point use Double.
        | _ ->
            let dbl1 = 
                try
                    Convert.ToDouble value1
                with
                | :? OverflowException ->
                    printfn "value1 is outside the range of a Double."
                    0.
                | _ -> 0.

            let dbl2 = 
                try
                    Convert.ToDouble value2
                with
                | :? OverflowException ->
                    printfn "value2 is outside the range of a Double."
                    0.
                | _ -> 0.
                
            dbl1.CompareTo dbl2 |> enum<NumericRelationship>
// </Snippet1>

// <Snippet2> 
printfn $"{Utility.isNumeric 12}"
printfn $"{Utility.isNumeric true}"
printfn $"{Utility.isNumeric 'c'}"
printfn $"{Utility.isNumeric (DateTime(2012, 1, 1))}"
printfn $"{Utility.isInteger 12.2}"
printfn $"{Utility.isInteger 123456789}"
printfn $"{Utility.isFloat true}"
printfn $"{Utility.isFloat 12.2}"
printfn $"{Utility.isFloat 12}"
printfn $"{12.1} {Utility.compare 12.1 12} {12}"
// The example displays the following output:
//       True
//       False
//       False
//       False
//       False
//       True
//       False
//       True
//       False
//       12.1 GreaterThan 12
// </Snippet2>