module uri_ishexdigit

// <Snippet1>
open System

printf "Type a string: "
let myString = stdin.ReadLine()
for i = 0 to myString.Length - 1 do
    if Uri.IsHexDigit myString[i] then
        printfn $"{myString[i]} is a hexadecimal digit."
    else
        printfn $"{myString[i]} is not a hexadecimal digit."
// The example produces output like the following:
//    Type a string: 3f5EaZ
//    3 is a hexadecimal digit.
//    f is a hexadecimal digit.
//    5 is a hexadecimal digit.
//    E is a hexadecimal digit.
//    a is a hexadecimal digit.
//    Z is not a hexadecimal digit.
// </Snippet1>