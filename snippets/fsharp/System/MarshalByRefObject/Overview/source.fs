// <Snippet1>
open System
open System.Runtime.Remoting
open System.Security.Permissions

type TestClass() =
    inherit MarshalByRefObject()

[<SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.RemotingConfiguration)>]
[<EntryPoint>]
let main _ =
    let obj = TestClass()

    RemotingServices.SetObjectUriForMarshal(obj, "testUri")
    RemotingServices.Marshal obj |> ignore

    printfn $"{RemotingServices.GetObjectUri obj}"
    0