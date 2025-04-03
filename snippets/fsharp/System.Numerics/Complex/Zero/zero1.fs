// <Snippet1>
open System.Numerics

let value = Complex.Zero
printfn $"{value}"

// Instantiate a complex number with real part 0 and imaginary part 1.
let value1 = Complex(0, 0)
printfn $"{value.Equals value1}"
// The example displays the following output:
//       (0, 0)
//       True
// </Snippet1>
