module testfullname

//<Snippet1>
open System

let t = typeof<Array>
printfn $"The full name of the Array type is {t.FullName}."

(* This example produces the following output:

The full name of the Array type is System.Array.
 *)
//</Snippet1>