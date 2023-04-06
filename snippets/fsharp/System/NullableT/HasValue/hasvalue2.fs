// <Snippet1>
open System

let n1 = Nullable 10
let n2 = Nullable()
let mutable n3 = Nullable 20
n3 <- Nullable()
let items = [| n1; n2; n3 |]

for item in items do
    printfn $"Has a value: {item.HasValue}"
    if item.HasValue then
        printfn $"Type: {item.GetType().Name}"
        printfn $"Value: {item.Value}"
    else
        printfn $"Null: {item = Nullable()}"
        printfn $"Default Value: {item.GetValueOrDefault()}"
    printfn ""
// The example displays the following output:
//       Has a value: True
//       Type: Int32
//       Value: 10
//
//       Has a value: False
//       Null: True
//       Default Value: 0
//
//       Has a value: False
//       Null: True
//       Default Value: 0
// </Snippet1>