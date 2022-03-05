module divrem2

// <Snippet2>
open System

// Define several positive and negative dividends.
let dividends =
    [ Int64.MaxValue; 13952; 0; -14032; Int64.MinValue ]
// Define one positive and one negative divisor.
let divisors = [ 2000; -2000 ]

for divisor in divisors do
    for dividend in dividends do
        let quotient, remainder = Math.DivRem(dividend, divisor)
        printfn $@"{dividend:N0} \ {divisor:N0} = {quotient:N0}, remainder {remainder:N0}"

// The example displays the following output:
//    9,223,372,036,854,775,807 \ 2,000 = 4,611,686,018,427,387, remainder 1,807
//    13,952 \ 2,000 = 6, remainder 1,952
//    0 \ 2,000 = 0, remainder 0
//    -14,032 \ 2,000 = -7, remainder -32
//    -9,223,372,036,854,775,808 \ 2,000 = -4,611,686,018,427,387, remainder -1,808
//    9,223,372,036,854,775,807 \ -2,000 = -4,611,686,018,427,387, remainder 1,807
//    13,952 \ -2,000 = -6, remainder 1,952
//    0 \ -2,000 = 0, remainder 0
//    -14,032 \ -2,000 = 7, remainder -32
//    -9,223,372,036,854,775,808 \ -2,000 = 4,611,686,018,427,387, remainder -1,808
// </Snippet2>