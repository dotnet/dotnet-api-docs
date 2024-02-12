//<snippet1>
// Sample for the Environment.GetEnvironmentVariables method
open System
open System.Collections

printfn "\nGetEnvironmentVariables: "
for de in Environment.GetEnvironmentVariables() do
    let de = de :?> DictionaryEntry
    printfn $"  {de.Key} = {de.Value}"
// Output from the example is not shown, since it is:
//    Lengthy.
//    Specific to the machine on which the example is run.
//    May reveal information that should remain secure.
//</snippet1>