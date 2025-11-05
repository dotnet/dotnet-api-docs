module divide1

// <Snippet1>
open System.Numerics

let c1 = Complex(1.2, 2.3);
let values = 
    [ Complex(1.2, 2.3)
      Complex(0.5, 0.75)
      Complex(3.0, -5.0) ]

for c2 in values do
    printfn $"{c1} / {c2} = {Complex.Divide(c1, c2):N2}"
// The example displays the following output:
//       (1.2, 2.3) / (1.2, 2.3) = (1.00, 0.00)
//       (1.2, 2.3) / (0.5, 0.75) = (2.86, 0.31)
//       (1.2, 2.3) / (3, -5) = (-0.23, 0.38)
// </Snippet1>