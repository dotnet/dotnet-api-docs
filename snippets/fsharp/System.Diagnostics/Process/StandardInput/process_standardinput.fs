// System.Diagnostics.Process.StandardInput
//
//
// The following example illustrates how to redirect the StandardInput
// stream of a process.  The example starts the sort command with
// redirected input.  It then prompts the user for text, and passes
// that to the sort command by means of the redirected input stream.
// The sort command results are displayed to the user on the console.

// <Snippet1>
open System.Diagnostics

printfn "Ready to sort one or more text lines..."

// Start the Sort.exe process with redirected input.
// Use the sort command to sort the input text.
use myProcess = new Process()

myProcess.StartInfo.FileName <- "Sort.exe"
myProcess.StartInfo.UseShellExecute <- false
myProcess.StartInfo.RedirectStandardInput <- true

myProcess.Start() |> ignore

let myStreamWriter = myProcess.StandardInput

// Prompt the user for input text lines to sort.
// Write each line to the StandardInput stream of
// the sort command.

let mutable inputText = ""
let mutable numLines = 0

while inputText.Length > 0 do
    printfn "Enter a line of text (or press the Enter key to stop):"

    inputText <- stdin.ReadLine()

    if inputText.Length > 0 then
        numLines <- numLines + 1
        myStreamWriter.WriteLine inputText

// Write a report header to the console.
if numLines > 0 then
    printfn $" {numLines} sorted text line(s) "
    printfn "------------------------"
else
    printfn $" No input was sorted"

// End the input stream to the sort command.
// When the stream closes, the sort command
// writes the sorted text lines to the
// console.
myStreamWriter.Close()

// Wait for the sort process to write the sorted text lines.
myProcess.WaitForExit()
// </Snippet1>
