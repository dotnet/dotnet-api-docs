//<snippet1>
// This example demonstrates the ConsoleKeyInfo.GetHashCode() method.

open System
open System.Text

// The keyCombination function creates a string that specifies what
// key and what combination of shift, CTRL, and ALT modifier keys
// were pressed simultaneously.
let keyCombination (sourceCki: ConsoleKeyInfo) =
    let sb = StringBuilder()
    sb.Length <- 0
    if int sourceCki.Modifiers <> 0 then
        if int (sourceCki.Modifiers &&& ConsoleModifiers.Alt) <> 0 then
            sb.Append "ALT+" |> ignore
        if int (sourceCki.Modifiers &&& ConsoleModifiers.Shift) <> 0 then
            sb.Append "SHIFT+" |> ignore
        if int (sourceCki.Modifiers &&& ConsoleModifiers.Control) <> 0 then
            sb.Append "CTL+" |> ignore

    sourceCki.Key
    |> string
    |> sb.Append
    |> string

//
// The Console.TreatControlCAsInput property prevents this example from
// ending if you press CTL+C, however all other operating system keys and
// shortcuts, such as ALT+TAB or the Windows Logo key, are still in effect.
//
Console.TreatControlCAsInput <- true

let mutable cki1 = Unchecked.defaultof<ConsoleKeyInfo>

// Request that the user enter two key presses. A key press and any
// combination shift, CTRL, and ALT modifier keys is permitted.
while cki1.Key <> ConsoleKey.Escape do
    printf "\nEnter a key ......... " 
    cki1 <- Console.ReadKey false
    printfn ""

    let key1 = keyCombination cki1
    let hashCode = cki1.GetHashCode()
    printfn $"The hash code for the {key1} key is {hashCode}."

    printfn "Press the escape key (ESC) to quit, or any other key to continue."
    cki1 <- Console.ReadKey true

// Note: This example requires the Escape (Esc) key.
//
// This example produces results similar to the following output:
//
// Enter a key ......... a
// The hash code for the A key is 97.
// Press the escape key (ESC) to quit, or any other key to continue.
//
// Enter a key ......... S
// The hash code for the SHIFT+S key is 83.
// Press the escape key (ESC) to quit, or any other key to continue.
//
// Enter a key .........
// The hash code for the ALT+SHIFT+CTL+J key is 7.
// Press the escape key (ESC) to quit, or any other key to continue.
//</snippet1>