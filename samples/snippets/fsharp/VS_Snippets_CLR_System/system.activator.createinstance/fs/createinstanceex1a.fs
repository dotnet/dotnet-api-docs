module createinstanceex1a

// <Snippet3>
open System

let handle =
    Activator.CreateInstance("PersonInfo", "Person")

let p = handle.Unwrap()
let t = p.GetType()
let prop = t.GetProperty "Name"

if not (isNull prop) then
    prop.SetValue(p, "Samuel")

let method = t.GetMethod "ToString"
let retVal = method.Invoke(p, null)

if not (isNull retVal) then
    printfn $"{retVal}"

// The example displays the following output:
//        Samuel
// </Snippet3>
