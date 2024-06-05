// <Snippet1>
open System
open System.Threading

let mutable cki = Unchecked.defaultof<ConsoleKeyInfo>

while cki.Key <> ConsoleKey.X do
    printfn "\nPress a key to display; press the 'x' key to quit."

    // Your code could perform some useful task in the following loop. However,
    // for the sake of this example we'll merely pause for a quarter second.

    while not Console.KeyAvailable do
        Thread.Sleep 250 // Loop until input is entered.

    cki <- Console.ReadKey true
    printfn $"You pressed the '{cki.Key}' key."


// This example produces results similar to the following:
//
// Press a key to display; press the 'x' key to quit.
// You pressed the 'H' key.
//
// Press a key to display; press the 'x' key to quit.
// You pressed the 'E' key.
//
// Press a key to display; press the 'x' key to quit.
// You pressed the 'PageUp' key.
//
// Press a key to display; press the 'x' key to quit.
// You pressed the 'DownArrow' key.
//
// Press a key to display; press the 'x' key to quit.
// You pressed the 'X' key.
// </Snippet1>