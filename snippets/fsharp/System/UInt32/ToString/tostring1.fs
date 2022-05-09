module tostring1

// <Snippet1>
let value = 1632490u
// Display value using default ToString method.
printfn $"{value.ToString()}\n"      

// Define an array of format specifiers.
let formats = [| "G"; "C"; "D"; "F"; "N"; "X" |]
// Display value using the standard format specifiers.
for format in formats do
    printfn $"{format} format specifier: {value.ToString format,16}"
// The example displays the following output:
//       1632490
//       
//       G format specifier:          1632490
//       C format specifier:    $1,632,490.00
//       D format specifier:          1632490
//       F format specifier:       1632490.00
//       N format specifier:     1,632,490.00
//       X format specifier:           18E8EA
// </Snippet1>