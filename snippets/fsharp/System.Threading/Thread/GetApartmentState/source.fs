//<Snippet1>
open System.Threading

let threadProc () = Thread.Sleep 2000

let t = Thread threadProc
printfn $"Before setting apartment state: {t.GetApartmentState()}"

t.SetApartmentState ApartmentState.STA
printfn $"After setting apartment state: {t.GetApartmentState()}"

let result = t.TrySetApartmentState ApartmentState.MTA
printfn $"Try to change state: {result}"

t.Start()

Thread.Sleep 500

try
    t.TrySetApartmentState ApartmentState.STA |> ignore
with :? ThreadStateException ->
    printfn "ThreadStateException occurs if apartment state is set after starting thread."

t.Join()

// This code example produces the following output:
//     Before setting apartment state: Unknown
//     After setting apartment state: STA
//     Try to change state: False
//     ThreadStateException occurs if apartment state is set after starting thread.
//</Snippet1>
