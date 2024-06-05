module ParseExample1

// <Snippet1>
open System

[<Flags>]
type Colors =
    | None = 0
    | Red = 1
    | Green = 2
    | Blue = 4

let colorStrings = [ "0"; "2"; "8"; "blue"; "Blue"; "Yellow"; "Red, Green" ]
for colorString in colorStrings do
    try
        let colorValue = Enum.Parse(typeof<Colors>, colorString) :?> Colors
        if Enum.IsDefined(typeof<Colors>, colorValue) || (string colorValue).Contains "," then
            printfn $"Converted '{colorString}' to {colorValue}."
        else
            printfn $"{colorString} is not an underlying value of the Colors enumeration."
    with :? ArgumentException ->
        printfn $"'{colorString}' is not a member of the Colors enumeration."
// The example displays the following output:
//       Converted '0' to None.
//       Converted '2' to Green.
//       8 is not an underlying value of the Colors enumeration.
//       'blue' is not a member of the Colors enumeration.
//       Converted 'Blue' to Blue.
//       'Yellow' is not a member of the Colors enumeration.
//       Converted 'Red, Green' to Red, Green.
// </Snippet1>