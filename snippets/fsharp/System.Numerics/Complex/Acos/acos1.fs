// <Snippet1>
open System.Numerics

let values =
    [ Complex(0.5, 2.); Complex(0.5, -2.); Complex(-0.5, 2.); Complex(-0.3, -0.8) ]

for value in values do
    printfn $"Cos(ACos({value})) = {Complex.Acos value |> Complex.Cos}"
// The example displays the following output:
//       Cos(ACos((0.5, 2))) = (0.5, 2)
//       Cos(ACos((0.5, -2))) = (0.5, -2)
//       Cos(ACos((-0.5, 2))) = (-0.5, 2)
//       Cos(ACos((-0.3, -0.8))) = (-0.3, -0.8)
// </Snippet1>
