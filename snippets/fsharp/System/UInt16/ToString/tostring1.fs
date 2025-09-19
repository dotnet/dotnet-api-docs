module tostring1

// <Snippet1>
let value = 16324us
// Display value using default ToString method.
printfn $"{value.ToString()}\n"     

// Define an array of format specifiers.
let formats = [| "G"; "C"; "D"; "F"; "N"; "X" |]
// Display value using the standard format specifiers.
for format in formats do
    printfn $"{format} format specifier: {value.ToString format,12}" 
// The example displays the following output:
//       16324
//
//       G format specifier:        16324
//       C format specifier:   $16,324.00
//       D format specifier:        16324
//       F format specifier:     16324.00
//       N format specifier:    16,324.00
//       X format specifier:         3FC4
// </Snippet1>