module ToByte5

// <Snippet15>
open System

let values = 
    [| null; ""; "0xC9"; "C9"; "101"; "16.3"; "$12"
       "$12.01"; "-4"; "1,032"; "255"; "   16  " |]

for value in values do
    try
        let number = Convert.ToByte(value)
        printfn $"""'%A{value}' --> {number}"""
    with
    | :? FormatException ->
        printfn $"Bad Format: '%A{value}'"
    | :? OverflowException ->
        printfn $"OverflowException: '{value}'"
        
// The example displays the following output:
//     '<null>' --> 0
//     Bad Format: ''
//     Bad Format: '0xC9'
//     Bad Format: 'C9'
//     '101' --> 101
//     Bad Format: '16.3'
//     Bad Format: '$12'
//     Bad Format: '$12.01'
//     OverflowException: '-4'
//     Bad Format: '1,032'
//     '255' --> 255
//     '   16  ' --> 16
// </Snippet15>