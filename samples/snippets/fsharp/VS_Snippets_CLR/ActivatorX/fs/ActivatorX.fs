module ActivatorX

//<snippet1>
open System
open System.Reflection
open System.Text

type SomeType() =
    member _.DoSomething(x) = printfn $"100 / {x} = {100 / x}"

//<snippet2>
// Create an instance of the StringBuilder type using Activator.CreateInstance.
let o = Activator.CreateInstance typeof<StringBuilder>

// Append a string into the StringBuilder object and display the StringBuilder.
let sb = o :?> StringBuilder
sb.Append "Hello, there." |> ignore
printfn $"{sb}"
//</snippet2>

//<snippet3>
// Create an instance of the SomeType class that is defined in this assembly.
let oh = 
    Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().Location, typeof<SomeType>.FullName)

// Call an instance method defined by the SomeType type using this object.
let st = oh.Unwrap() :?> SomeType

st.DoSomething 5
//</snippet3>

(* This code produces the following output:

Hello, there.
100 / 5 = 20
 *)
//</snippet1>
