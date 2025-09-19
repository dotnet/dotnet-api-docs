module foregroundcolor3

// <Snippet1>
open System

// Get an array with the values of ConsoleColor enumeration members.
let colors = ConsoleColor.GetValues<ConsoleColor>()

// Save the current background and foreground colors.
let currentBackground = Console.BackgroundColor
let currentForeground = Console.ForegroundColor

// Display all foreground colors except the one that matches the background.
printfn $"All the foreground colors except {currentBackground}, the background color:"

for color in colors do
    if color <> currentBackground then
        Console.ForegroundColor <- color
        printfn $"   The foreground color is {color}."
printfn ""

// Restore the foreground color.
Console.ForegroundColor <- currentForeground;

// Display each background color except the one that matches the current foreground color.
printfn $"All the background colors except {currentForeground}, the foreground color:"

for color in colors do
    if color <> currentForeground then
        Console.BackgroundColor <- color
        printfn $"   The background color is {color}."

// Restore the original console colors.
Console.ResetColor()
printfn "\nOriginal colors restored..."


//The example displays output like the following:
//    All the foreground colors except DarkCyan, the background color:
//       The foreground color is Black.
//       The foreground color is DarkBlue.
//       The foreground color is DarkGreen.
//       The foreground color is DarkRed.
//       The foreground color is DarkMagenta.
//       The foreground color is DarkYellow.
//       The foreground color is Gray.
//       The foreground color is DarkGray.
//       The foreground color is Blue.
//       The foreground color is Green.
//       The foreground color is Cyan.
//       The foreground color is Red.
//       The foreground color is Magenta.
//       The foreground color is Yellow.
//       The foreground color is White.
//
//    All the background colors except White, the foreground color:
//       The background color is Black.
//       The background color is DarkBlue.
//       The background color is DarkGreen.
//       The background color is DarkCyan.
//       The background color is DarkRed.
//       The background color is DarkMagenta.
//       The background color is DarkYellow.
//       The background color is Gray.
//       The background color is DarkGray.
//       The background color is Blue.
//       The background color is Green.
//       The background color is Cyan.
//       The background color is Red.
//       The background color is Magenta.
//       The background color is Yellow.
//
//    Original colors restored...
//</snippet1>