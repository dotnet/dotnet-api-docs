module stringconcat3

//<snippet1>
open System

// Make an array of strings. Note that we have included spaces.
let s = 
    [| "hello "; "and "; "welcome "; "to "
       "this "; "demo! " |]

// Put all the strings together.
printfn $"{String.Concat s}"

// Sort the strings, and put them together.
Array.Sort s
printfn $"{String.Concat s}"
// The example displays the following output:
//       hello and welcome to this demo!
//       and demo! hello this to welcome
// </snippet1>