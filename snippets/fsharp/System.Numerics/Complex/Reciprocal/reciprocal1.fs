// <Snippet1>
open System.Numerics

let values =
    [ Complex(1., 1.); Complex(-1., 1.); Complex(10., -1.); Complex(3., 5.) ]

for value in values do
    let r1 = Complex.Reciprocal value
    printfn $"{value:N0} x {r1:N2} = {value * r1:N2}"
// The example displays the following output:
//       (1, 1) x (0.50, -0.50) = (1.00, 0.00)
//       (-1, 1) x (-0.50, -0.50) = (1.00, 0.00)
//       (10, -1) x (0.10, 0.01) = (1.00, 0.00)
//       (3, 5) x (0.09, -0.15) = (1.00, 0.00)
// </Snippet1>
