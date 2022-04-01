module perdomain

// <Snippet2>
open System

type DisplayString() =
    inherit MarshalByRefObject()
    let s = "This is a string."
   
    override _.Equals(obj) =
        match obj with
        | :? string as s2 -> s = s2
        | _ -> false

    member _.Equals(str) =
        s = str
   
    override _.GetHashCode() =
        s.GetHashCode()
   
    override _.ToString() = 
        s

    member _.ShowStringHashCode() =
        printfn $"String '{s}' in domain '{AppDomain.CurrentDomain.FriendlyName}': {s.GetHashCode():X8}"

// Show hash code in current domain.
let display = DisplayString()
display.ShowStringHashCode()

// Create a new app domain and show string hash code.
let domain = AppDomain.CreateDomain "NewDomain"
let display2 = domain.CreateInstanceAndUnwrap(typeof<DisplayString>.Assembly.FullName, "DisplayString") :?> DisplayString   
display2.ShowStringHashCode()
// </Snippet2>