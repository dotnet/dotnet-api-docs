// <Snippet1>
open System.Numerics

let values = [ Complex(12.4, 6.3);
               Complex(12.4, -6.3) ]

for value in values do
    printfn $"Original value: {value}"
    printfn $"Conjugate:      {Complex.Conjugate(value)}\n"
// The example displays the following output:
//       Original value: (12.4, 6.3)
//       Conjugate:      (12.4, -6.3)
//
//       Original value: (12.4, -6.3)
//       Conjugate:      (12.4, 6.3)
// </Snippet1>
