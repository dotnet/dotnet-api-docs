module EnumGetValues

//<snippet1>
open System

type Colors =
    | Red = 0
    | Green = 1
    | Blue = 2
    | Yellow = 3
    
type Styles =
    | Plaid = 0
    | Striped = 23
    | Tartan = 65
    | Corduroy = 78

printfn $"The values of the Colors Enum are:"
for i in Enum.GetValues typeof<Colors> do
    printfn $"{i}"

printfn "\nThe values of the Styles Enum are:"
for i in Enum.GetValues typeof<Styles> do
    printfn $"{i}"

// The example produces the following output:
//       The values of the Colors Enum are:
//       0
//       1
//       2
//       3
//
//       The values of the Styles Enum are:
//       0
//       23
//       65
//       78
//</snippet1>