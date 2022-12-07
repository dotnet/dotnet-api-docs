module tostr

//<snippet1>
// Sample for Enum.ToString(String)
open System

type Colors =
    | Red = 0 
    | Green = 1 
    | Blue = 2 
    | Yellow = 12

let myColor = Colors.Yellow

printfn $"""Colors.Red = {Colors.Red.ToString "d"}"""
printfn $"""Colors.Green = {Colors.Green.ToString "d"}"""
printfn $"""Colors.Blue = {Colors.Blue.ToString "d"}"""
printfn $"""Colors.Yellow = {Colors.Yellow.ToString "d"}"""

printfn "\nmyColor = Colors.Yellow\n"

printfn $"""myColor.ToString("g") = {myColor.ToString "g"}"""
printfn $"""myColor.ToString("G") = {myColor.ToString "G"}"""

printfn $"""myColor.ToString("x") = {myColor.ToString "x"}"""
printfn $"""myColor.ToString("X") = {myColor.ToString "X"}"""

printfn $"""myColor.ToString("d") = {myColor.ToString "d"}"""
printfn $"""myColor.ToString("D") = {myColor.ToString "d"}"""

printfn $"""myColor.ToString("f") = {myColor.ToString "f"}"""
printfn $"""myColor.ToString("F") = {myColor.ToString "F"}"""

// This example produces the following results:
//     Colors.Red = 0
//     Colors.Green = 1
//     Colors.Blue = 2
//     Colors.Yellow = 12
//    
//     myColor = Colors.Yellow
//    
//     myColor.ToString("g") = Yellow
//     myColor.ToString("G") = Yellow
//     myColor.ToString("x") = 0000000C
//     myColor.ToString("X") = 0000000C
//     myColor.ToString "d" = 12
//     myColor.ToString "d" = 12
//     myColor.ToString("f") = Yellow
//     myColor.ToString("F") = Yellow
//</snippet1>