module equals4
// <Snippet8>
open System.Numerics

let n1 = 1.430718e-12f
let c1 = Complex(1.430718e-12, 0);
printfn $"{c1} = {n1}: {c1.Equals n1}"
// The example displays the following output:
//       (1.430718E-12, 0) = 1.430718E-12: False
// </Snippet8>
