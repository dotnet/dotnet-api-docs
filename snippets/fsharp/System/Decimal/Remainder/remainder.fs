// <Snippet1>
open System

// Create parallel lists of Decimals to use as the dividend and divisor.
let dividends = 
    [ 79m; 1000m; -1000m; 123m; 1234567800000m; 1234.0123m ]
let divisors =
    [ 11m; 7m; 7m; 0.00123m; 0.12345678m; 1234.5678m ]

for i = 0 to dividends.Length - 1 do
    let dividend = dividends[i]
    let divisor = divisors[i]
    printfn $"{dividend:N3} / {divisor:N3} = {Decimal.Divide(dividend, divisor):N3} Remainder {Decimal.Remainder(dividend, divisor):N3}"

// The example displays the following output:
//       79.000 / 11.000 = 7.182 Remainder 2.000
//       1,000.000 / 7.000 = 142.857 Remainder 6.000
//       -1,000.000 / 7.000 = -142.857 Remainder -6.000
//       123.000 / 0.001 = 100,000.000 Remainder 0.000
//       1,234,567,800,000.000 / 0.123 = 10,000,000,000,000.000 Remainder 0.000
//       1,234.012 / 1,234.568 = 1.000 Remainder 1,234.012
// </Snippet1> 