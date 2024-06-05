// <Snippet1>
open System

let showConsoleStatistics () =
    printfn "Console statistics:"
    printfn $"   Buffer: {Console.BufferHeight} x {Console.BufferWidth}" 
    printfn $"   Window: {Console.WindowHeight} x {Console.WindowWidth}"
    printfn $"   Window starts at {Console.WindowLeft}."
    printfn "Press <- or -> to move window, Ctrl+C to exit."

Console.BufferWidth <- Console.BufferWidth + 4
Console.Clear()

showConsoleStatistics ()

let mutable moved = false

while true do
    let key = Console.ReadKey true
    if key.Key = ConsoleKey.LeftArrow then
        let pos = Console.WindowLeft - 1
        if pos >= 0 && pos + Console.WindowWidth <= Console.BufferWidth then
            Console.WindowLeft <- pos
            moved <- true
    elif key.Key = ConsoleKey.RightArrow then
        let pos = Console.WindowLeft + 1
        if pos + Console.WindowWidth <= Console.BufferWidth then
            Console.WindowLeft <- pos
            moved <- true
    if moved then
        showConsoleStatistics ()
        moved <- false
    
    printfn ""

// </Snippet1>