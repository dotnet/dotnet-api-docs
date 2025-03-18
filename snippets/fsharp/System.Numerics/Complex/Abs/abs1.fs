// <Snippet1>
open System.Numerics

let complex1 = Complex(2., 3.)
printfn $"|{complex1}| = {Complex.Abs complex1:N2}"
printfn $"Equal to Magnitude: {Complex.Abs(complex1).Equals complex1.Magnitude}"
// The example displays the following output:
//       |(2, 3)| = 3.61
//       Equal to Magnitude: True
// </Snippet1>
