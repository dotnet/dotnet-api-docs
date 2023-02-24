module append2

open System
open System.Text

let appendBool () =
    // <Snippet2>
    let flag = false
    let sb = StringBuilder()
    sb.Append("The value of the flag is ").Append(flag).Append "." |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       The value of the flag is False.
    // </Snippet2>

let appendByte () =
    // <Snippet3>
    let bytes = [| 16uy; 132uy; 27uy; 253uy |]
    let sb = StringBuilder()

    for value in bytes do
        sb.Append(value).Append " " |> ignore

    printfn $"The byte array: {sb}"
    // The example displays the following output:
    //         The byte array: 16 132 27 253
    // </Snippet3>

let appendChar () =
    // <Snippet4>
    let str = "Characters in a string."
    let sb = StringBuilder()

    for ch in str do
        sb.Append(" '").Append(ch).Append "' " |> ignore

    printfn "Characters in the string:"
    printfn $"  {sb}"
    // The example displays the following output:
    //    Characters in the string:
    //       'C'  'h'  'a'  'r'  'a'  'c'  't'  'e'  'r'  's'  ' '  'i'  'n'  ' '  'a'  ' '  's'  't' 'r'  'i'  'n'  'g'  '.'
    // </Snippet4>

let appendMultipleChars () =
    // <Snippet5>
    let value = 1346.19m
    let sb = StringBuilder()
    sb.Append('*', 5).AppendFormat("{0:C2}", value).Append('*', 5) |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       *****$1,346.19*****
    // </Snippet5>

let appendCharArray () =
    // <Snippet6>
    let chars = [| 'a'; 'e'; 'i'; 'o'; 'u' |]
    let sb = StringBuilder()
    sb.Append("The characters in the array: ").Append chars |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //      The characters in the array: aeiou
    // </Snippet6>

let appendPartialCharArray () =
    // <Snippet7>
    let chars = [| 'a'; 'b'; 'c'; 'd'; 'e' |]
    let sb = StringBuilder()
    let startPosition = Array.IndexOf(chars, 'a')
    let endPosition = Array.IndexOf(chars, 'c')

    if startPosition >= 0 && endPosition >= 0 then
        sb
            .Append("The array from positions ")
            .Append(startPosition)
            .Append(" to ")
            .Append(endPosition)
            .Append(" contains ")
            .Append(chars, startPosition, endPosition + 1)
            .Append "."
        |> ignore

        printfn $"{sb}"
    // The example displays the following output:
    //       The array from positions 0 to 2 contains abc.
    // </Snippet7>

let appendDecimal () =
    // <Snippet8>
    let value = 1346.19m
    let sb = StringBuilder()
    sb.Append('*', 5).Append(value).Append('*', 5) |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       *****1346.19*****
    // </Snippet8>

let appendDouble () =
    // <Snippet9>
    let value = 1034769.47
    let sb = StringBuilder()
    sb.Append('*', 5).Append(value).Append('*', 5) |> ignore
    printfn $"{sb}"
    // The example displays the following output:
    //       *****1034769.47*****
    // </Snippet9>


appendBool ()
printfn "-----"
appendByte ()
printfn "-----"
appendChar ()
printfn "-----"
appendMultipleChars ()
printfn "-----"
appendCharArray ()
printfn "-----"
appendPartialCharArray ()
printfn "-----"
appendDecimal ()
printfn "-----"
appendDouble ()
printfn "-----"
