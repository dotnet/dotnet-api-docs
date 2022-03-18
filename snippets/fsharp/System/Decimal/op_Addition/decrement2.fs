module decrement2

// <Snippet6>
open System

let number = 1079.8m
printfn $"Original value:    {number:N}"
printfn $"Decremented value: {Decimal.Subtract(number, 1):N}"

// The example displays the following output:
//       Original value:    1,079.80
//       Decremented value: 1,078.80
// </Snippet6> 