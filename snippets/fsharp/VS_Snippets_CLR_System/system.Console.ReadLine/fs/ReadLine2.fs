module ReadLine2

// <Snippet1>
open System

printfn "Enter one or more lines of text (press CTRL+Z to exit):\n"

let mutable line = ""

while line <> null do
    printf "   "
    line <- Console.ReadLine()
    if line <> null then
        printfn $"      {line}"


// The following displays possible output from this example:
//       Enter one or more lines of text (press CTRL+Z to exit):
//
//          This is line #1.
//             This is line #1.
//          This is line #2
//             This is line #2
//          ^Z
//
//       >
// </Snippet1>