// <Snippet1>
open System

// Divide a series of numbers by 22.1
let dividend = 1230.0m
let divisor = 22.1m
for i = 0 to 10 do
    printfn $"{dividend:N1} / {divisor:N1} = {Decimal.Divide(dividend + (decimal i) * 0.1m, divisor):N4}"

// The example displays the following output:
//       1,230.0 / 22.1 = 55.6561
//       1,230.1 / 22.1 = 55.6606
//       1,230.2 / 22.1 = 55.6652
//       1,230.3 / 22.1 = 55.6697
//       1,230.4 / 22.1 = 55.6742
//       1,230.5 / 22.1 = 55.6787
//       1,230.6 / 22.1 = 55.6833
//       1,230.7 / 22.1 = 55.6878
//       1,230.8 / 22.1 = 55.6923
//       1,230.9 / 22.1 = 55.6968
//       1,231.0 / 22.1 = 55.7014
// </Snippet1> 