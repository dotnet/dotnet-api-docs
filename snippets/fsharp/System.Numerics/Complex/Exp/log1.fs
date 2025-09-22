// <Snippet1>
open System
open System.Numerics

let values =
    [ Complex(1.53, 9.26)
      Complex(2.53, -8.12)
      Complex(-2.81, 5.32)
      Complex(-1.09, -3.43)
      Complex(Double.MinValue / 2.0, Double.MinValue / 2.0) ]

for value in values do
    printfn $"Exp(Log({value}) = {Complex.Exp(Complex.Log(value))}"
// The example displays the following output:
//       Exp(Log((1.53, 9.26)) = (1.53, 9.26)
//       Exp(Log((2.53, -8.12)) = (2.53, -8.12)
//       Exp(Log((-2.81, 5.32)) = (-2.81, 5.32)
//       Exp(Log((-1.09, -3.43)) = (-1.09, -3.43)
//       Exp(Log((-8.98846567431158E+307, -8.98846567431158E+307)) = (-8.98846567431161E+307, -8.98846567431161E+307)
// </Snippet1>
