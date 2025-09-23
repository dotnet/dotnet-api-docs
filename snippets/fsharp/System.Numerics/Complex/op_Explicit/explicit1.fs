open System
open System.Numerics

let fromDecimal () =
    // <Snippet1>
    let numbers = [ Decimal.MinValue; -18.35m; 0m; 1893.019m; Decimal.MaxValue ]

    for number in numbers do
        let c1 = Complex(float number, 0.)
        printfn $"{number, 30}  -->  {c1}"

// The example displays the following output:
//    -79228162514264337593543950335  -->  (-7.92281625142643E+28, 0)
//                            -18.35  -->  (-18.35, 0)
//                                 0  -->  (0, 0)
//                          1893.019  -->  (1893.019, 0)
//     79228162514264337593543950335  -->  (7.92281625142643E+28, 0)
// </Snippet1>

let fromBigInteger () =
    // <Snippet2>
    let numbers =
        [ (bigint Double.MaxValue) * 2I
          BigInteger.Parse "901345277852317852466891423"
          BigInteger.One ]

    for number in numbers do
        let c1 = Complex(float number, 0.)
        printfn $"{number, 30}  -->  {c1}"
// The example displays the following output:
//       (Infinity, 0)
//       (9.01345277852318E+26, 0)
//       (1, 0)
// </Snippet2>


fromDecimal ()
fromBigInteger ()
