//<Snippet1>
open System

// appdomain setup information
let currentDomain = AppDomain.CurrentDomain

//Create a new value pair for the appdomain
currentDomain.SetData("ADVALUE", "Example value")

//get the value specified in the setdata method
currentDomain.GetData "ADVALUE"
|> printfn "ADVALUE is: %O"

//get a system value specified at appdomainsetup
currentDomain.GetData "LOADER_OPTIMIZATION"
|> printfn "System value for loader optimization: %O"

(* This code example produces the following output:

ADVALUE is: Example value
System value for loader optimization: NotSpecified
*)
//</Snippet1>