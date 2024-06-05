module tostring1

// <Snippet1>
let value = 163249057uL
// Display value using default ToString method.
printfn $"{value.ToString()}\n"      

// Define an array of format specifiers.
let formats = [| "G"; "C"; "D"; "F"; "N"; "X" |]
// Display value using the standard format specifiers.
for format in formats do
    printfn $"{format} format specifier: {value.ToString format,16}" 
// The example displays the following output:
//       163249057
//       
//       G format specifier:        163249057
//       C format specifier:  $163,249,057.00
//       D format specifier:        163249057
//       F format specifier:     163249057.00
//       N format specifier:   163,249,057.00
//       X format specifier:          9BAFBA1
// </Snippet1>