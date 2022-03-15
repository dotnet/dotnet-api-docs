module sb_example1

// <Snippet1>
open System
open System.Text

let sb = StringBuilder(15, 15)
sb.Append "Substring #1 "
|> ignore
try
    sb.Insert(0, "Substring #2 ", 1)
    |> ignore
with :? OutOfMemoryException as e ->
    printfn $"Out of Memory: {e.Message}"
// The example displays the following output:
//    Out of Memory: Insufficient memory to continue the execution of the program.
// </Snippet1>