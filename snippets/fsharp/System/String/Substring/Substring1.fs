module Substring1.fs
open System

// <Snippet1>
let pairs = 
    [| "Color1=red"; "Color2=green"; "Color3=blue"
       "Title=Code Repository" |]
for pair in pairs do
    let position = pair.IndexOf "="
    if position >= 0 then
        printfn $"Key: {pair.Substring(0, position)}, Value: '{pair.Substring(position + 1)}'"

// The example displays the following output:
//     Key: Color1, Value: 'red'
//     Key: Color2, Value: 'green'
//     Key: Color3, Value: 'blue'
//     Key: Title, Value: 'Code Repository'
// </Snippet1>
