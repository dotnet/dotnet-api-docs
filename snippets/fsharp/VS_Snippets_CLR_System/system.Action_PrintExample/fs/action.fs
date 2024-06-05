open System

//<snippet01>
// F# provides a type alias for System.Collections.List<'T> as ResizeArray<'T>.
let names = ResizeArray<string>()
names.Add "Bruce"
names.Add "Alfred"
names.Add "Tim"
names.Add "Richard"

let print s = printfn "%s" s

// Display the contents of the list using the print function.
names.ForEach(Action<string> print)

// The following demonstrates the lambda expression feature of F#
// to display the contents of the list to the console.
names.ForEach(fun s -> printfn "%s" s)

(* This code will produce output similar to the following:
* Bruce
* Alfred
* Tim
* Richard
* Bruce
* Alfred
* Tim
* Richard
*)
//</snippet01>
