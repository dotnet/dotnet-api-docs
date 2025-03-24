module tostring1

// <Snippet1>
open System.Numerics

let c =
    [ Complex(17.3, 14.1)
      Complex(-18.9, 147.2)
      Complex(13.472, -18.115)
      Complex(-11.154, -17.002) ]

for c1 in c do
    printfn $"{c1.ToString()}"
// The example display the following output:
//       (17.3, 14.1)
//       (-18.9, 147.2)
//       (13.472, -18.115)
//       (-11.154, -17.002)
// </Snippet1>
