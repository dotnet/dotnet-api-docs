// <Snippet1>
open System.Numerics

let values =
    [ Complex(2.5, 1.5)
      Complex(2.5, -1.5)
      Complex(-2.5, 1.5)
      Complex(-2.5, -1.5) ]

for value in values do
    printfn $"Tan(Atan({value})) = {Complex.Atan value |> Complex.Tan}"
// The example displays the following output:
//       Tan(Atan((2.5, 1.5))) = (2.5, 1.5)
//       Tan(Atan((2.5, -1.5))) = (2.5, -1.5)
//       Tan(Atan((-2.5, 1.5))) = (-2.5, 1.5)
//       Tan(Atan((-2.5, -1.5))) = (-2.5, -1.5)
// </Snippet1>
