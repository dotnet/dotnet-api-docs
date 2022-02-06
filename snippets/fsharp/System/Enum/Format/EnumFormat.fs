// <Snippet1>
open System

type Colors =
    | Red = 0
    | Green = 1
    | Blue = 2
    | Yellow = 3

let myColor = Colors.Blue

printfn $"My favorite color is {myColor}."
printfn $"""The value of my favorite color is {Enum.Format(typeof<Colors>, myColor, "d")}."""
printfn $"""The hex value of my favorite color is {Enum.Format(typeof<Colors>, myColor, "x")}."""
// The example displays the following output:
//    My favorite color is Blue.
//    The value of my favorite color is 2.
//    The hex value of my favorite color is 00000002.
// </Snippet1>