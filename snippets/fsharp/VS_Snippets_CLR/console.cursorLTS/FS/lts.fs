//<snippet1>
// This example demonstrates the
//     Console.CursorLeft and
//     Console.CursorTop properties, and the
//     Console.SetCursorPosition and
//     Console.Clear methods.
open System

// Clear the screen, then save the top and left coordinates.
Console.Clear()
let origRow = Console.CursorTop
let origCol = Console.CursorLeft

let writeAt s x y =
    try
        Console.SetCursorPosition(origCol + x, origRow + y)
        printfn $"%s{s}"
    with :? ArgumentOutOfRangeException as e ->
        Console.Clear()
        printfn $"{e.Message}"

// Draw the left side of a 5x5 rectangle, from top to bottom.
writeAt "+" 0 0
writeAt "|" 0 1
writeAt "|" 0 2
writeAt "|" 0 3
writeAt "+" 0 4

// Draw the bottom side, from left to right.
writeAt "-" 1 4 // shortcut: writeAt "---", 1, 4)
writeAt "-" 2 4 // ...
writeAt "-" 3 4 // ...
writeAt "+" 4 4

// Draw the right side, from bottom to top.
writeAt "|" 4 3
writeAt "|" 4 2
writeAt "|" 4 1
writeAt "+" 4 0

// Draw the top side, from right to left.
writeAt "-" 3 0 // shortcut: writeAt "---", 1, 0)
writeAt "-" 2 0 // ...
writeAt "-" 1 0 // ...

writeAt "All done!" 0 6
printfn ""


// This example produces the following results:
//
// +---+
// |   |
// |   |
// |   |
// +---+
//
// All done!
//</snippet1>