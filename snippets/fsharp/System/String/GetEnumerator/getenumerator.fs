//<snippet1>
open System

let enumerateAndDisplay phrase =
    printfn $"The characters in the string \"{phrase}\" are:"

    let mutable CharCount = 0
    let mutable controlChars = 0
    let mutable alphanumeric = 0
    let mutable punctuation = 0

    for ch in phrase do
        if Char.IsControl ch then
            printf $"{ch}"
        else
            printf $"0x{uint16 ch:X4}"

        if Char.IsLetterOrDigit ch then
            alphanumeric <- alphanumeric + 1
        elif Char.IsControl ch then
            controlChars <- controlChars + 1
        elif Char.IsPunctuation ch then
            punctuation <- punctuation + 1             
            CharCount <- CharCount + 1

    printfn $"\n   Total characters:        {CharCount,3}"
    printfn $"   Alphanumeric characters: {alphanumeric,3}"
    printfn $"   Punctuation characters:  {punctuation,3}"
    printfn $"   Control Characters:      {controlChars,3}\n"

enumerateAndDisplay "Test Case"
enumerateAndDisplay "This is a sentence."
enumerateAndDisplay "Has\ttwo\ttabs"
enumerateAndDisplay "Two\nnew\nlines"


// The example displays the following output:
//    The characters in the string "Test Case" are:
//    'T' 'e' 's' 't' ' ' 'C' 'a' 's' 'e'
//       Total characters:          9
//       Alphanumeric characters:   8
//       Punctuation characters:    0
//       Control Characters:        0
//    
//    The characters in the string "This is a sentence." are:
//    'T' 'h' 'i' 's' ' ' 'i' 's' ' ' 'a' ' ' 's' 'e' 'n' 't' 'e' 'n' 'c' 'e' '.'
//       Total characters:         19
//       Alphanumeric characters:  15
//       Punctuation characters:    1
//       Control Characters:        0
//    
//    The characters in the string "Has       two     tabs" are:
//    'H' 'a' 's' '0x0009' 't' 'w' 'o' '0x0009' 't' 'a' 'b' 's'
//       Total characters:         12
//       Alphanumeric characters:  10
//       Punctuation characters:    0
//       Control Characters:        2
//    
//    The characters in the string "Two
//    new
//    lines" are:
//    'T' 'w' 'o' '0x000A' 'n' 'e' 'w' '0x000A' 'l' 'i' 'n' 'e' 's'
//       Total characters:         13
//       Alphanumeric characters:  11
//       Punctuation characters:    0
//       Control Characters:        2
//</snippet1>