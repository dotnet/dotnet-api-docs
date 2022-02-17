module EnumGetNames

//<snippet1>
open System

type Colors =
    | Red = 0
    | Green = 1
    | Blue = 2
    | Yellow = 3

type Styles =
    | Plaid = 0
    | Striped = 1
    | Tartan = 2
    | Corduroy = 3

printfn "The members of the Colors enum are:"
for s in Enum.GetNames typeof<Colors> do
    printfn $"{s}"

printfn "\nThe members of the Styles enum are:"
for s in Enum.GetNames typeof<Styles> do
    printfn $"{s}"
// The example displays the following output:
//       The members of the Colors enum are:
//       Red
//       Green
//       Blue
//       Yellow
//
//       The members of the Styles enum are:
//       Plaid
//       Striped
//       Tartan
//       Corduroy
//</snippet1>