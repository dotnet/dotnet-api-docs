//<snippet1>
// This example demonstrates the ConsoleKeyInfo.Equals() method.

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
let mutable cki2 = Unchecked.defaultof<ConsoleKeyInfo>

// Request that the user enter two key presses. A key press and any
// combination shift, CTRL, and ALT modifier keys is permitted.
while cki1.Key <> ConsoleKey.Escape do
    printf "\nEnter a key ......... "
    cki1 <- Console.ReadKey false
    printf "\nEnter another key ... "
    cki2 <- Console.ReadKey false
    printfn ""

    let key1 = keyCombination cki1
    let key2 = keyCombination cki2
    let equalValue =
        if cki1.Equals cki2 then ""
        else "not "

    printfn $"The {key1} and {key2} keys are {equalValue}equal."

    printfn "Press the escape key (ESC) to quit, or any other key to continue."
    cki1 <- Console.ReadKey true

// Note: This example requires the Escape (Esc) key.


// This example produces results similar to the following output:
//
// Enter a key ......... a
// Enter another key ... a
// The A and A keys are equal.
// Press the escape key (ESC) to quit, or any other key to continue.
//
// Enter a key ......... a
// Enter another key ... A
// The A and SHIFT+A keys are not equal.
// Press the escape key (ESC) to quit, or any other key to continue.
//
// Enter a key ......... S
// Enter another key ...
// The ALT+SHIFT+S and ALT+CTL+F keys are not equal.
// Press the escape key (ESC) to quit, or any other key to continue.
//
// Enter a key .........
// Enter another key ...
// The UpArrow and UpArrow keys are equal.
// Press the escape key (ESC) to quit, or any other key to continue.
//</snippet1>