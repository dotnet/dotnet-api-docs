//<Snippet1>
open System
open System.Diagnostics

let notePad = Process.Start "notepad"
printfn $"Started notepad process Id = {notePad.Id}"
printfn "All instances of notepad:"
// Get Process objects for all running instances on notepad.
let localByName = Process.GetProcessesByName "notepad"
let mutable i = localByName.Length

while i > 0 do
    // You can use the process Id to pass to other applications or to
    // reference that particular instance of the application.
    printfn $"{localByName.[i - 1].Id}"
    i <- i - 1

i <- localByName.Length

while i > 0 do
    printfn "Enter a process Id to kill the process"
    let id = Console.ReadLine()

    if String.IsNullOrEmpty id then
        i <- 0
    else
        try
            use chosen = Int32.Parse id |> Process.GetProcessById

            if chosen.ProcessName = "notepad" then
                chosen.Kill()
                chosen.WaitForExit()

            i <- i - 1
        with e ->
            printfn "Incorrect entry."

//</Snippet1>
