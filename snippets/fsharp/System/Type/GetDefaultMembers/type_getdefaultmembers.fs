// <Snippet1>
open System
open System.Reflection
open System.IO

[<DefaultMemberAttribute "Age">]
type MyClass() =
    member _.Name(s: string) = ()
    member _.Age 
        with get () =
            20
try
    let myType = typeof<MyClass>
    let memberInfoArray = myType.GetDefaultMembers()
    if memberInfoArray.Length > 0 then
        for memberInfoObj in memberInfoArray do
            printfn $"The default member name is: {memberInfoObj}"
    else
        printfn "No default members are available."
with
| :? InvalidOperationException as e ->
    printfn $"InvalidOperationException: {e.Message}"
| :? IOException as e ->
    printfn $"IOException: {e.Message}"
| e ->
    printfn $"Exception: {e.Message}"
// </Snippet1>