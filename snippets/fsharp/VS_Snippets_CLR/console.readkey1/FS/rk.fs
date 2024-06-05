// <Snippet1>
open System

// Prevent example from ending if CTL+C is pressed.
Console.TreatControlCAsInput <- true

printfn "Press any combination of CTL, ALT, and SHIFT, and a console key."
printfn "Press the Escape (Esc) key to quit: \n"

let mutable cki = Unchecked.defaultof<ConsoleKeyInfo>

while cki.Key <> ConsoleKey.Escape do
    cki <- Console.ReadKey()
    printf " --- You pressed "
    if int (cki.Modifiers &&& ConsoleModifiers.Alt) <> 0 then printf "ALT+"
    if int (cki.Modifiers &&& ConsoleModifiers.Shift) <> 0 then printf "SHIFT+"
    if int (cki.Modifiers &&& ConsoleModifiers.Control) <> 0 then printf "CTL+"
    printfn $"{cki.Key}"


// This example displays output similar to the following:
//       Press any combination of CTL, ALT, and SHIFT, and a console key.
//       Press the Escape (Esc) key to quit:
//
//       a --- You pressed A
//       k --- You pressed ALT+K
//       ► --- You pressed CTL+P
//         --- You pressed RightArrow
//       R --- You pressed SHIFT+R
//                --- You pressed CTL+I
//       j --- You pressed ALT+J
//       O --- You pressed SHIFT+O
//       § --- You pressed CTL+U
// </Snippet1>