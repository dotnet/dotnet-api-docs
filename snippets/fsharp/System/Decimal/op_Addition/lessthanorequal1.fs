module lessthanorequal1

// <Snippet17>
open System

let number1 = 16354.0699m
let number2 = 16354.0695m
printfn $"{number1} <= {number2}: {number1 <= number2}"

let rounded1 = Decimal.Round(number1, 2)
let rounded2 = Decimal.Round(number2, 2)
printfn $"{rounded1} <= {rounded2}: {rounded1 <= rounded2}"

// The example displays the following output:
//       16354.0699 <= 16354.0695: False
//       16354.07 <= 16354.07: True
// </Snippet17> 