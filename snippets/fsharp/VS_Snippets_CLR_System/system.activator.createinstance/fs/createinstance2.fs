module createinstanceex2
// <Snippet4>
open System

let chars = [| 'a' .. 'f' |]

let arguments =
    [| chars
       chars[1..4]
       Array.create 20 chars[1] |]

for args in arguments do
    let result =
        Activator.CreateInstance(typeof<string>, args)

    printfn $"{result.GetType().Name}: {result}"

// The example displays the following output:
//    String: abcdef
//    String: bcde
//    String: bbbbbbbbbbbbbbbbbbbb
// </Snippet4>
