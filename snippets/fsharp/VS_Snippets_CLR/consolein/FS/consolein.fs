//<snippet1>
open System

let tIn = Console.In
let tOut = Console.Out

tOut.WriteLine "Hola Mundo!"
tOut.Write "What is your name: "
let name = tIn.ReadLine()

tOut.WriteLine $"Buenos Dias, {name}!"

//</snippet1>