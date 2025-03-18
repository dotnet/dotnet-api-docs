// <Snippet1>
open System.Numerics

let value = Complex.ImaginaryOne
printfn $"{value}"

// Instantiate a complex number with real part 0 and imaginary part 1.
let value1 = Complex(0., 1.)
printfn $"{value.Equals value1}"
// The example displays the following output:
//       (0, 1)
//       True
// </Snippet1>
