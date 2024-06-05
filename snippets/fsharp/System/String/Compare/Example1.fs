module Example1

// <Snippet1>
open System
open System.Globalization

let name1 = "Jack Smith"
let name2 = "John Doe"

// Get position of character after the space character.
let index1 =
    let i = name1.IndexOf " "
    if i < 0 then 0 else i + 1

let index2 = 
    let i = name2.IndexOf " "
    if i < 0 then 0 else i + 1

let length = max name1.Length name2.Length

printfn "Sorted alphabetically by last name:"
if String.Compare(name1, index1, name2, index2, length, CultureInfo "en-US", CompareOptions.IgnoreCase) < 0 then
    printfn $"{name1}\n{name2}"
else
    printfn $"{name2}\n{name1}"

// The example displays the following output:
//       Sorted alphabetically by last name:
//       John Doe
//       Jack Smith
// </Snippet1>