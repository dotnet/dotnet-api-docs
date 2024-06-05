module mean1

// <Snippet2>
open System

let values = [| 1.15m; 1.25m; 1.35m; 1.45m; 1.55m; 1.65m |]
let mutable sum = 0m

// Calculate true mean.
for value in values do
    sum <- sum + value

printfn $"True mean:     {sum / decimal values.Length:N2}"

// Calculate mean with rounding away from zero.
sum <- 0m
for value in values do
    sum <- sum + Math.Round(value, 1, MidpointRounding.AwayFromZero)

printfn $"AwayFromZero:  {sum / decimal values.Length:N2}"

// Calculate mean with rounding to nearest.
sum <- 0m
for value in values do
    sum <- sum + Math.Round(value, 1, MidpointRounding.ToEven)

printfn $"ToEven:        {sum / decimal values.Length:N2}"

// The example displays the following output:
//       True mean:     1.40
//       AwayFromZero:  1.45
//       ToEven:        1.40
// </Snippet2>