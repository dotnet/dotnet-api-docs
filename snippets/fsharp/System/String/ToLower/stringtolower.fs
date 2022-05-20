module stringtolower

//<snippet1>
open System

let info = [| "Name"; "Title"; "Age"; "Location"; "Gender" |]

printfn "The initial values in the array are:"
for s in info do
    printfn $"{s}"

printfn $"{Environment.NewLine}The lowercase of these values is:"

for s in info do
    printfn $"{s.ToLower()}"

printfn $"{Environment.NewLine}The uppercase of these values is:"

for s in info do
    printfn $"{s.ToUpper()}"
// The example displays the following output:
//       The initial values in the array are:
//       Name
//       Title
//       Age
//       Location
//       Gender
//
//       The lowercase of these values is:
//       name
//       title
//       age
//       location
//       gender
//
//       The uppercase of these values is:
//       NAME
//       TITLE
//       AGE
//       LOCATION
//       GENDER
//</snippet1>