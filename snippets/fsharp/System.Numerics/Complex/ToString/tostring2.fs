module tostring2
// <Snippet2>
open System.Globalization
open System.Numerics

let c =
    [ Complex(17.3, 14.1)
      Complex(-18.9, 147.2)
      Complex(13.472, -18.115)
      Complex(-11.154, -17.002) ]

let cultures = [ CultureInfo "en-US"; CultureInfo "fr-FR" ]

for c1 in c do
    for culture in cultures do
        printf $"{c1.ToString culture} ({culture.Name})"

    printfn ""
// The example displays the following output:
//       (17.3, 14.1) (en-US)    (17,3, 14,1) (fr-FR)
//       (-18.9, 147.2) (en-US)    (-18,9, 147,2) (fr-FR)
//       (13.472, -18.115) (en-US)    (13,472, -18,115) (fr-FR)
//       (-11.154, -17.002) (en-US)    (-11,154, -17,002) (fr-FR)
// </Snippet2>
