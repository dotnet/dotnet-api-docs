//<snippet1>
// This example demonstrates the Console.CursorVisible property.

open System

Console.CursorVisible <- true // Initialize the cursor to visible.
let saveCursorVisibile = Console.CursorVisible
let saveCursorSize = Console.CursorSize
Console.CursorSize <- 100     // Emphasize the cursor.

let mutable quit = false
while not quit do
    printfn $"""\nThe cursor is {if Console.CursorVisible then "VISIBLE" else "HIDDEN"}.\nType any text then press Enter. Type '+' in the first column to show 
the cursor, '-' to hide the cursor, or lowercase 'x' to quit:"""
    let s = Console.ReadLine()
    if not (String.IsNullOrEmpty s) then
        match s[0] with
        | '+' ->
            Console.CursorVisible <- true
        | '-' ->
            Console.CursorVisible <- false
        | 'x' -> 
            quit <- true
        | _ -> ()

Console.CursorVisible <- saveCursorVisibile
Console.CursorSize    <- saveCursorSize


// This example produces the following results. Note that these results
// cannot depict cursor visibility. You must run the example to see the
// cursor behavior:
//
// The cursor is VISIBLE.
// Type any text then press Enter. Type '+' in the first column to show
// the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
// The quick brown fox
//
// The cursor is VISIBLE.
// Type any text then press Enter. Type '+' in the first column to show
// the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
// -
//
// The cursor is HIDDEN.
// Type any text then press Enter. Type '+' in the first column to show
// the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
// jumps over
//
// The cursor is HIDDEN.
// Type any text then press Enter. Type '+' in the first column to show
// the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
// +
//
// The cursor is VISIBLE.
// Type any text then press Enter. Type '+' in the first column to show
// the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
// the lazy dog.
//
// The cursor is VISIBLE.
// Type any text then press Enter. Type '+' in the first column to show
// the cursor, '-' to hide the cursor, or lowercase 'x' to quit:
// x
//</snippet1>