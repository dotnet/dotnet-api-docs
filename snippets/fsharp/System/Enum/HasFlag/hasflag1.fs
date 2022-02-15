module hasflag1

// <Snippet2>
open System

[<Flags>] 
type DinnerItems =
    | None = 0
    | Entree = 1
    | Appetizer = 2
    | Side = 4
    | Dessert = 8
    | Beverage = 16
    | BarBeverage = 32

let myOrder = 
    DinnerItems.Appetizer ||| DinnerItems.Entree ||| DinnerItems.Beverage ||| DinnerItems.Dessert
let flagValue = 
    DinnerItems.Entree ||| DinnerItems.Beverage
printfn $"{myOrder} includes {flagValue}: {myOrder.HasFlag flagValue}"
// The example displays the following output:
//    Entree, Appetizer, Dessert, Beverage includes Entree, Beverage: True
// </Snippet2>