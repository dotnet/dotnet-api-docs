module tostring2

// <Snippet2>
let value = -123y
// Display value using default ToString method.
printfn $"{value.ToString()}"               // Displays -123
// Display value using some standard format specifiers.
printfn $"""{value.ToString "G"}"""         // Displays -123
printfn $"""{value.ToString "C"}"""         // Displays ($-123.00)
printfn $"""{value.ToString "D"}"""         // Displays -123
printfn $"""{value.ToString "F"}"""         // Displays -123.00
printfn $"""{value.ToString "N"}"""         // Displays -123.00
printfn $"""{value.ToString "X"}"""         // Displays 85
// </Snippet2>