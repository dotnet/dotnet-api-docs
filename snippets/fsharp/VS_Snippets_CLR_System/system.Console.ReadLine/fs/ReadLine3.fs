module ReadLine3

// <Snippet3>
open System

if not Console.IsInputRedirected then
    printfn "This example requires that input be redirected from a file."

printfn "About to call Console.ReadLine in a loop."
printfn "----"

let mutable s = ""
let mutable i = 0

while s <> null do
    i <- i + 1
    s <- Console.ReadLine()
    printfn $"Line {i}: {s}"
printfn "---"


// The example displays the following output:
//       About to call Console.ReadLine in a loop.
//       ----
//       Line 1: This is the first line.
//       Line 2: This is the second line.
//       Line 3: This is the third line.
//       Line 4: This is the fourth line.
//       Line 5:
//       ---
// </Snippet3>