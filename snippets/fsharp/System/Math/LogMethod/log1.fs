module log1

// <Snippet2>
open System

printfn "  Evaluate this identity with selected values for X:"
printfn "                              ln(x) = 1 / log[X](B)\n"

let XArgs = [| 1.2; 4.9; 9.9; 0.1 |]

for argX in XArgs do
    // Find natural log of argX.
    // The F# log function may be used instead
    printfn $"                      Math.Log({argX}) = {Math.Log argX:E16}"

    // Evaluate 1 / log[X](e).
    printfn $"             1.0 / Math.Log(e, {argX}) = {1. / Math.Log(Math.E, argX):E16}\n"

// This example displays the following output:
//         Evaluate this identity with selected values for X:
//                                     ln(x) = 1 / log[X](B)
//
//                             Math.Log(1.2) = 1.8232155679395459E-001
//                    1.0 / Math.Log(e, 1.2) = 1.8232155679395459E-001
//
//                             Math.Log(4.9) = 1.5892352051165810E+000
//                    1.0 / Math.Log(e, 4.9) = 1.5892352051165810E+000
//
//                             Math.Log(9.9) = 2.2925347571405443E+000
//                    1.0 / Math.Log(e, 9.9) = 2.2925347571405443E+000
//
//                             Math.Log(0.1) = -2.3025850929940455E+000
//                    1.0 / Math.Log(e, 0.1) = -2.3025850929940455E+000
// </Snippet2>