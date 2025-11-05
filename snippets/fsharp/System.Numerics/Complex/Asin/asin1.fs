// <Snippet1>
open System.Numerics

let values =
    [ Complex(2.3, 1.4)
      Complex(-2.3, 1.4)
      Complex(-2.3, -1.4)
      Complex(2.3, -1.4) ]

for value in values do
    printfn $"Sin(Asin({value})) = {Complex.Asin value |> Complex.Sin}"
// The example displays the following output:
//       Sin(Asin((2.3, 1.4))) = (2.3, 1.4)
//       Sin(Asin((-2.3, 1.4))) = (-2.3, 1.4)
//       Sin(Asin((-2.3, -1.4))) = (-2.3, -1.4)
//       Sin(Asin((2.3, -1.4))) = (2.3, -1.4)
// </Snippet1>
