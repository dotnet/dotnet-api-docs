module stringconcat4

//<snippet1>
open System

[<EntryPoint>]
let main _ =
    // we want to simply quickly add this person's name together
    let fName = "Simon"
    let mName = "Jake"
    let lName = "Harrows"

    // because we want a name to appear with a space in between each name,
    // put a space on the front of the middle, and last name, allowing for
    // the fact that a space may already be there
    let mName = " " + mName.Trim()
    let lName = " " + lName.Trim()

    // this line simply concatenates the two strings
    printfn $"Welcome to this page, '{String.Concat(String.Concat(fName, mName), lName)}'!"
    0
// The example displays the following output:
//        Welcome to this page, 'Simon Jake Harrows'!
// </snippet1>