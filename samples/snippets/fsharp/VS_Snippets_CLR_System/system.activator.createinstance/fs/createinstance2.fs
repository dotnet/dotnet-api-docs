module createinstanceex2
// <Snippet4>
open System

let characters = [| 'a'; 'b'; 'c'; 'd'; 'e'; 'f' |]

let arguments =
    [| characters
       characters[1..4]
       Array.create 20 characters[1] |]

for i = 0 to arguments.GetUpperBound 0 do
    let args = arguments[i]

    let result =
        Activator.CreateInstance(typeof<string>, args)

    printfn $"{result.GetType().Name}: {result}"

// The example displays the following output:
//    String: abcdef
//    String: bcde
//    String: bbbbbbbbbbbbbbbbbbbb
// </Snippet4>
