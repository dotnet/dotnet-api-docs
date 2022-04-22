// <Snippet1>
open System.Security
open System.Reflection

let myType = typeof<System.Net.IPAddress>
let myFields = myType.GetFields(BindingFlags.Static ||| BindingFlags.NonPublic)
printfn "\nThe IPAddress class has the following nonpublic fields: "
for myField in myFields do
    printfn $"{myField}"
let myType1 = typeof<System.Net.IPAddress>
let myFields1 = myType1.GetFields()
printfn "\nThe IPAddress class has the following public fields: "
for myField in myFields1 do
    printfn $"{myField}"
try
    printfn $"The HashCode of the System.Windows.Forms.Button type is: {typeof<System.Windows.Forms.Button>.GetHashCode()}"
with
| :? SecurityException as e ->
    printfn "An exception occurred."
    printfn $"Message: {e.Message}"
| e ->
    printfn "An exception occurred."
    printfn $"Message: {e.Message}"
// </Snippet1>