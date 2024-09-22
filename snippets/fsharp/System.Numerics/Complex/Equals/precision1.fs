module precision1

open System

let testForEquality () =
    // <Snippet4>
    let c1 = System.Numerics.Complex(3.33333, 0.142857)
    let c2 = System.Numerics.Complex(10. / 3., 1. / 7.)
    printfn $"{c1} = {c2}: {c1.Equals c2}"
// The example displays the following output:
//    (3.33333, 0.142857) = (3.33333333333333, 0.142857142857143): False
// </Snippet4>

let testForApproximateEquality () =
    // <Snippet5>
    let c1 = System.Numerics.Complex(3.33333, 0.142857)
    let c2 = System.Numerics.Complex(10. / 3., 1. / 7.)
    let difference = 0.0001

    // Compare the values
    let result =
        (Math.Abs(c1.Real - c2.Real) <= c1.Real * difference)
        && (Math.Abs(c1.Imaginary - c2.Imaginary) <= c1.Imaginary * difference)

    printfn $"{c1} = {c2}: {result}"
// The example displays the following output:
//    (3.33333, 0.142857) = (3.33333333333333, 0.142857142857143): True
// </Snippet5>

testForEquality ()
testForApproximateEquality ()
