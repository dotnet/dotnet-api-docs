module Lambda

// <Snippet4>
open System

let convert = Func<string, string>(fun s -> s.ToUpper())

let name = "Dakota"
printfn $"{convert.Invoke name}"

// This code example produces the following output:
//    DAKOTA
// </Snippet4>