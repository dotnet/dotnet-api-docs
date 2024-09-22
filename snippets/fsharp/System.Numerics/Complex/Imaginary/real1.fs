// <Snippet1>
open System.Numerics

let values = [ Complex(12.5, -6.3); Complex(-17.8, 1.7); Complex(14.4, 8.9) ]

for value in values do
    printfn $"{value.Real} + {value.Imaginary}i"
// The example displays the following output:
//       12.5 + -6.3i
//       -17.8 + 1.7i
//       14.4 + 8.9i
// </Snippet1>
