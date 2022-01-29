// <Snippet1>
open System

let mutable increment = 0
let mutable exitFlag = false

while not exitFlag do
    if Console.IsOutputRedirected then
        Console.Error.WriteLine $"Generating multiples of numbers from {increment + 1} to {increment + 10}"

    Console.WriteLine $"Generating multiples of numbers from {increment + 1} to {increment + 10}"

    for i = increment + 1 to increment + 10 do
        Console.Write $"Multiples of {i}: "
        for j = 1 to 10 do
            Console.Write $"""{i * j}{if j = 10 then "" else ", "}"""

        Console.WriteLine()
    Console.WriteLine()

    increment <- increment + 10
    Console.Error.Write $"Display multiples of {increment + 1} through {increment + 10} (y/n)? "
    let response = Console.ReadKey(true).KeyChar
    Console.Error.WriteLine response
    if not Console.IsOutputRedirected then
        Console.CursorTop <- Console.CursorTop - 1 

    if Char.ToUpperInvariant response = 'N' then
        exitFlag <- true

// </Snippet1>