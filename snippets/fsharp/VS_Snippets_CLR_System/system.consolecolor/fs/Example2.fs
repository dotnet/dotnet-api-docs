module Example2

// <Snippet2>
open System

if Console.BackgroundColor = ConsoleColor.Black then
    Console.BackgroundColor <- ConsoleColor.Red
    Console.ForegroundColor <- ConsoleColor.Black
    Console.Clear()

// </Snippet2>