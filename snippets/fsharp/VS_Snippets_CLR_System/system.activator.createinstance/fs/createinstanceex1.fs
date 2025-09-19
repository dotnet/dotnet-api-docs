module createinstanceex1

// <Snippet2>
open System

let handle = Activator.CreateInstance("PersonInfo", "Person")
let p = handle.Unwrap() :?> Person
p.Name <- "Samuel"
printfn $"{p}"

// The example displays the following output:
//        Samuel
// </Snippet2>