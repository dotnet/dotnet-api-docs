module divrem1

// <Snippet1>
open System

// Define several positive and negative dividends.
let dividends = 
    [ Int32.MaxValue; 13952; 0; -14032; Int32.MinValue ]
// Define one positive and one negative divisor.
let divisors = [ 2000; -2000 ]

for divisor in divisors do
    for dividend in dividends do
        let quotient, remainder = Math.DivRem(dividend, divisor)
        printfn $@"{dividend:N0} \ {divisor:N0} = {quotient:N0}, remainder {remainder:N0}"

// The example displays the following output:
//       2,147,483,647 \ 2,000 = 1,073,741, remainder 1,647
//       13,952 \ 2,000 = 6, remainder 1,952
//       0 \ 2,000 = 0, remainder 0
//       -14,032 \ 2,000 = -7, remainder -32
//       -2,147,483,648 \ 2,000 = -1,073,741, remainder -1,648
//       2,147,483,647 \ -2,000 = -1,073,741, remainder 1,647
//       13,952 \ -2,000 = -6, remainder 1,952
//       0 \ -2,000 = 0, remainder 0
//       -14,032 \ -2,000 = 7, remainder -32
//       -2,147,483,648 \ -2,000 = 1,073,741, remainder -1,648
// </Snippet1>