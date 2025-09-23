module tostring3
// <Snippet3>
open System.Numerics

let c =
    [ Complex(17.3, 14.1)
      Complex(-18.9, 147.2)
      Complex(13.472, -18.115)
      Complex(-11.154, -17.002) ]

let formats = [ "F2"; "N2"; "G5" ]

for c1 in c do
    for format in formats do
        printf $"{format}: {c1.ToString(format)}    "

    printfn ""
// The example displays the following output:
//       F2: (17.30, 14.10)
//       N2: (17.30, 14.10)
//       G5: (17.3, 14.1)
//
//       F2: (-18.90, 147.20)
//       N2: (-18.90, 147.20)
//       G5: (-18.9, 147.2)
//
//       F2: (13.47, -18.12)
//       N2: (13.47, -18.12)
//       G5: (13.472, -18.115)
//
//       F2: (-11.15, -17.00)
//       N2: (-11.15, -17.00)
//       G5: (-11.154, -17.002)
// </Snippet3>
