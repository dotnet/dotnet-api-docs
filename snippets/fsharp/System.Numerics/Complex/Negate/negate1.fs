module negate1
// <Snippet1>
open System.Numerics

let values =
    [ Complex.One; Complex(-7.1, 2.5); Complex(1.3, -4.2); Complex(-3.3, -1.8) ]

for c1 in values do
    printfn $"{c1} --> {Complex.Negate(c1)}"
// The example displays the following output:
//       (1, 0) --> (-1, 0)
//       (-7.1, 2.5) --> (7.1, -2.5)
//       (1.3, -4.2) --> (-1.3, 4.2)
//       (-3.3, -1.8) --> (3.3, 1.8)
// </Snippet1>
