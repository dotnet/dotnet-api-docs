// <Snippet1>
open System.Numerics

let value = Complex.One
printfn $"{value}"

// Instantiate a complex number with real part 1 and imaginary part 0.
let value1 = Complex(1., 0.)
printfn $"{value.Equals value1}"
// The example displays the following output:
//       (1, 0)
//       True
// </Snippet1>
