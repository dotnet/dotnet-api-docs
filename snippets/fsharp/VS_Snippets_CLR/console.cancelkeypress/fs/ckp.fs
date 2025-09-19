// <Snippet1>
open System

let myHandler sender (args: ConsoleCancelEventArgs) =
    printfn "\nThe read operation has been interrupted."

    printfn $"  Key pressed: {args.SpecialKey}"

    printfn $"  Cancel property: {args.Cancel}"

    // Set the Cancel property to true to prevent the process from terminating.
    printfn "Setting the Cancel property to true..."
    args.Cancel <- true

    // Announce the new value of the Cancel property.
    printfn $"  Cancel property: {args.Cancel}"
    printfn "The read operation will resume...\n"

// Establish an event handler to process key press events.
Console.CancelKeyPress.AddHandler(ConsoleCancelEventHandler myHandler)

let mutable quit = false
while not quit do
    printf "Press any key, or 'X' to quit, or "
    printfn "CTRL+C to interrupt the read operation:"

    // Start a console read operation. Do not display the input.
    let cki = Console.ReadKey true

    // Announce the name of the key that was pressed .
    printfn $"  Key pressed: {cki.Key}\n"

    // Exit if the user pressed the 'X' key.
    if cki.Key = ConsoleKey.X then
        quit <- true

// The example displays output similar to the following:
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: J
//
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: Enter
//
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//
//    The read operation has been interrupted.
//      Key pressed: ControlC
//      Cancel property: False
//    Setting the Cancel property to true...
//      Cancel property: True
//    The read operation will resume...
//
//      Key pressed: Q
//
//    Press any key, or 'X' to quit, or CTRL+C to interrupt the read operation:
//      Key pressed: X
// </Snippet1>