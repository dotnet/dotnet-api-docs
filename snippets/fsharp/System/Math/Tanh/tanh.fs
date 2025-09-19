//<snippet1>
// Example for the hyperbolic Math.Tanh( double ) method.
// In F#, the tanh function may be used instead 
open System

// Evaluate hyperbolic identities with a given argument.
let useTanh arg =
    let tanhArg = Math.Tanh arg

    // Evaluate tanh(X) = sinh(X) / cosh(X).
    printfn $"""
                       Math.Tanh({arg}) = {tanhArg:E16}
      Math.Sinh({arg}) / Math.Cosh({arg}) = {Math.Sinh arg / Math.Cosh arg:E16}"""

    // Evaluate tanh(2 * X) = 2 * tanh(X) / (1 + tanh^2(X)).
    printfn $"                   2 * Math.Tanh({arg}) / {2. * tanhArg}"
    printfn $"             (1 + (Math.Tanh({arg}))^2) = {2. * tanhArg / (1. + tanhArg * tanhArg):E16}"
    printfn $"                       Math.Tanh({2. * arg}) = {Math.Tanh(2. * arg):E16}"

// Evaluate a hyperbolic identity that is a function of two arguments.
let useTwoArgs argX argY =
    // Evaluate tanh(X + Y) = (tanh(X) + tanh(Y)) / (1 + tanh(X) * tanh(Y)).
    printfn $"\n    (Math.Tanh({argX}) + Math.Tanh({argY})) /\n(1 + Math.Tanh({argX}) * Math.Tanh({argY})) = {(Math.Tanh argX + Math.Tanh argY) / (1. + Math.Tanh argX * Math.Tanh argY):E16}"
    printfn $"                       Math.Tanh({argX + argY}) = {Math.Tanh(argX + argY):E16}"

printfn "This example of hyperbolic Math.Tanh( double )\ngenerates the following output."
printfn "\nEvaluate these hyperbolic identities with selected values for X:"
printfn "   tanh(X) = sinh(X) / cosh(X)"
printfn "   tanh(2 * X) = 2 * tanh(X) / (1 + tanh^2(X))"

useTanh 0.1
useTanh 1.2
useTanh 4.9

printfn "\nEvaluate [tanh(X + Y) = (tanh(X) + tanh(Y)) / (1 + tanh(X) * tanh(Y))]\nwith selected values for X and Y:"

useTwoArgs 0.1 1.2
useTwoArgs 1.2 4.9


// This example of hyperbolic Math.Tanh( double )
// generates the following output.
//
// Evaluate these hyperbolic identities with selected values for X:
//    tanh(X) = sinh(X) / cosh(X)
//    tanh(2 * X) = 2 * tanh(X) / (1 + tanh^2(X))
//
//                        Math.Tanh(0.1) = 9.9667994624955819E-002
//       Math.Sinh(0.1) / Math.Cosh(0.1) = 9.9667994624955819E-002
//                    2 * Math.Tanh(0.1) /
//              (1 + (Math.Tanh(0.1))^2) = 1.9737532022490401E-001
//                        Math.Tanh(0.2) = 1.9737532022490401E-001
//
//                        Math.Tanh(1.2) = 8.3365460701215521E-001
//       Math.Sinh(1.2) / Math.Cosh(1.2) = 8.3365460701215521E-001
//                    2 * Math.Tanh(1.2) /
//              (1 + (Math.Tanh(1.2))^2) = 9.8367485769368024E-001
//                        Math.Tanh(2.4) = 9.8367485769368024E-001
//
//                        Math.Tanh(4.9) = 9.9988910295055444E-001
//       Math.Sinh(4.9) / Math.Cosh(4.9) = 9.9988910295055433E-001
//                    2 * Math.Tanh(4.9) /
//              (1 + (Math.Tanh(4.9))^2) = 9.9999999385024030E-001
//                        Math.Tanh(9.8) = 9.9999999385024030E-001
//
// Evaluate [tanh(X + Y) = (tanh(X) + tanh(Y)) / (1 + tanh(X) * tanh(Y))]
// with selected values for X and Y:
//
//     (Math.Tanh(0.1) + Math.Tanh(1.2)) /
// (1 + Math.Tanh(0.1) * Math.Tanh(1.2)) = 8.6172315931330645E-001
//                        Math.Tanh(1.3) = 8.6172315931330634E-001
//
//     (Math.Tanh(1.2) + Math.Tanh(4.9)) /
// (1 + Math.Tanh(1.2) * Math.Tanh(4.9)) = 9.9998993913939649E-001
//                        Math.Tanh(6.1) = 9.9998993913939649E-001
//</snippet1>