//<snippet1>
open System

let show (s: string) =
    for x = 0 to s.Length - 1 do
        printf $"""0x{int s[x]:X}{if x = s.Length - 1 then String.Empty else ", "}"""                    

[<EntryPoint>]
let main _ =
    let letterA = 0x0041  //U+00041 = LATIN CAPITAL LETTER A
    let music   = 0x1D161 //U+1D161 = MUSICAL SYMBOL SIXTEENTH NOTE
    let comment   = "Create a UTF-16 encoded string from a code point."
    let comment1b = "Create a code point from a UTF-16 encoded string."
    let comment2b = "Create a code point from a surrogate pair at a certain position in a string."
    let comment2c = "Create a code point from a high surrogate and a low surrogate code point."

//  Convert code point U+0041 to UTF-16. The UTF-16 equivalent of
//  U+0041 is a Char with hexadecimal value 0041.

    printfn $"{comment}"
    let s1 = Char.ConvertFromUtf32 letterA
    printf $"    1a) 0x{letterA:X} => "
    show s1
    printfn ""

//  Convert the lone UTF-16 character to a code point.

    printfn $"{comment1b}"
    let letterA = Char.ConvertToUtf32(s1, 0)
    printf "    1b) "
    show s1
    printfn $" => 0x{letterA:X}"
    printfn ""

// -------------------------------------------------------------------

//  Convert the code point U+1D161 to UTF-16. The UTF-16 equivalent of
//  U+1D161 is a surrogate pair with hexadecimal values D834 and DD61.

    printfn $"{comment}"
    let s1 = Char.ConvertFromUtf32 music
    printf $"    2a) 0x{music:X} => "
    show s1
    printfn ""

//  Convert the surrogate pair in the string at index position
//  zero to a code point.

    printfn $"{comment2b}" 
    let music = Char.ConvertToUtf32(s1, 0)
    printf "    2b) "
    show s1
    printfn $" => 0x{music:X}"

//  Convert the high and low characters in the surrogate pair into a code point.

    printfn $"{comment2c}"
    let music = Char.ConvertToUtf32(s1[0], s1[1])
    printf "    2c) "
    show s1
    printfn $" => 0x{music:X}"

    0

// This example produces the following results:
//
// Create a UTF-16 encoded string from a code point.
//     1a) 0x41 => 0x41
// Create a code point from a UTF-16 encoded string.
//     1b) 0x41 => 0x41
//
// Create a UTF-16 encoded string from a code point.
//     2a) 0x1D161 => 0xD834, 0xDD61
// Create a code point from a surrogate pair at a certain position in a string.
//     2b) 0xD834, 0xDD61 => 0x1D161
// Create a code point from a high surrogate and a low surrogate code point.
//     2c) 0xD834, 0xDD61 => 0x1D161
//</snippet1>
