module precision2

// <Snippet7>
open System.Numerics

let n1 = 1.430718e-12f
let c1 = Complex(1.430718e-12, 0);
let difference = 0.0001f;

// Compare the values
let result = (abs (c1.Real - float n1) <= c1.Real * float difference) && c1.Imaginary = 0;
printfn $"{c1} = {n1}: {result}"
// The example displays the following output:
//       (1.430718E-12, 0) = 1.430718E-12: True
// </Snippet7>
