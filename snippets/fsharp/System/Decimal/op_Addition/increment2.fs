module increment2

// <Snippet14>
open System

let number = 1079.8m
printfn $"Original value:    {number:N}"
printfn $"Incremented value: {Decimal.Add(number, 1):N}"

// The example displays the following output:
//       Original value:    1,079.80
//       Incremented value: 1,080.80
// </Snippet14> 