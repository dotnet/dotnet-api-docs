module subtract1
// <Snippet1>
open System.Numerics

let c1 = Complex(4.93, 6.87)

let values =
    [ Complex(12.5, 9.6)
      Complex(4.3, -8.1)
      Complex(-1.9, 7.4)
      Complex(-5.3, -6.6) ]

for c2 in values do
    printfn $"{c1} - {c2} = {Complex.Subtract(c1, c2)}"
// The example displays the following output:
//       (4.93, 6.87) - (12.5, 9.6) = (-7.57, -2.73)
//       (4.93, 6.87) - (4.3, -8.1) = (0.63, 14.97)
//       (4.93, 6.87) - (-1.9, 7.4) = (6.83, -0.53)
//       (4.93, 6.87) - (-5.3, -6.6) = (10.23, 13.47)
// </Snippet1>
