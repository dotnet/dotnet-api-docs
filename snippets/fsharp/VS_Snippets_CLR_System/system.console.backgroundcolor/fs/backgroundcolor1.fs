// <Snippet1>
open System

let writeCharacterStrings start end' changeColor =
    for i = start to end' do
        if changeColor then
            Console.BackgroundColor <- (i - 1) % 16 |> enum

        Console.WriteLine(String(char (i + 64), 30))

writeCharacterStrings 1 26 true
Console.MoveBufferArea(0, Console.CursorTop - 10, 30, 1, Console.CursorLeft, Console.CursorTop + 1)
Console.CursorTop <- Console.CursorTop + 3
Console.WriteLine "Press any key..."
Console.ReadKey() |> ignore

Console.Clear()
writeCharacterStrings 1 26 false


// </Snippet1>