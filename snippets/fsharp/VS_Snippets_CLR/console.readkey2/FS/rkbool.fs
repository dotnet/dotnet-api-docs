// <Snippet1>
open System

// Prevent example from ending if CTL+C is pressed.
Console.TreatControlCAsInput <- true

printfn "Press any combination of CTL, ALT, and SHIFT, and a console key."
printfn "Press the Escape (Esc) key to quit: \n"

let mutable cki = Unchecked.defaultof<ConsoleKeyInfo>

while cki.Key <> ConsoleKey.Escape do
    cki <- Console.ReadKey true
    printf "You pressed "
    if int (cki.Modifiers &&& ConsoleModifiers.Alt) <> 0 then printf "ALT+"
    if int (cki.Modifiers &&& ConsoleModifiers.Shift) <> 0 then printf "SHIFT+"
    if int (cki.Modifiers &&& ConsoleModifiers.Control) <> 0 then printf "CTL+"
    printfn $"{cki.Key} (character '{cki.KeyChar}')" 


// This example displays output similar to the following:
//       Press any combination of CTL, ALT, and SHIFT, and a console key.
//       Press the Escape (Esc) key to quit:
//
//       You pressed CTL+A (character '☺')
//       You pressed C (character 'c')
//       You pressed CTL+C (character '♥')
//       You pressed K (character 'k')
//       You pressed ALT+I (character 'i')
//       You pressed ALT+U (character 'u')
//       You pressed ALT+SHIFT+H (character 'H')
//       You pressed Escape (character '←')
// </Snippet1>