module changetype_enum2

// <Snippet5>
open System

type Continent =
    | Africa = 0
    | Antarctica = 1
    | Asia = 2
    | Australia = 3
    | Europe = 4
    | NorthAmerica = 5
    | SouthAmerica = 6

// Convert a Continent to a Double.
let cont = Continent.NorthAmerica
printfn $"{Convert.ChangeType(cont, typeof<Double>):N2}"

// Convert a Double to a Continent.
let number = 6.0
try
    printfn $"{Convert.ChangeType(number, typeof<Continent>)}"
with :? InvalidCastException ->
    printfn "Cannot convert a Double to a Continent"

printfn $"{int number |> enum<Continent>}"
// The example displays the following output:
//       5.00
//       Cannot convert a Double to a Continent
//       SouthAmerica
// </Snippet5>