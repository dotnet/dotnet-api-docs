//<Snippet1>
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

printfn $"The 4th value of the Colors Enum is {Enum.GetName(typeof<Colors>, 3)}"
printfn $"The 4th value of the Styles Enum is {Enum.GetName(typeof<Styles>, 3)}"
// The example displays the following output:
//       The 4th value of the Colors Enum is Yellow
//       The 4th value of the Styles Enum is Corduroy
//</Snippet1>