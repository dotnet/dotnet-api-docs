//<snippet1>
// Example for the hyperbolic Math.Sinh( double )
// and Math.Cosh( double ) methods.
// In F#, the sinh and coh functions may be used instead
open System

// Evaluate hyperbolic identities with a given argument.
let useSinhCosh arg =
    let sinhArg = Math.Sinh arg
    let coshArg = Math.Cosh arg


    // Evaluate cosh^2(X) - sinh^2(X) = 1.
    printfn $"""
                         Math.Sinh({arg}) = {Math.Sinh arg:E16}
                         Math.Cosh({arg}) = {Math.Cosh arg:E16}"""
    printfn $"(Math.Cosh({arg}))^2 - (Math.Sinh({arg}))^2 = {coshArg * coshArg - sinhArg * sinhArg:E16}"

    // Evaluate sinh(2 * X) = 2 * sinh(X) * cosh(X).
    printfn $"                         Math.Sinh({2. * arg}) = {Math.Sinh(2. * arg):E16}"
    printfn $"    2 * Math.Sinh({arg}) * Math.Cosh({arg}) = {2. * sinhArg * coshArg:E16}"

    // Evaluate cosh(2 * X) = cosh^2(X) + sinh^2(X).
    printfn $"                         Math.Cosh({2. * arg}) = {Math.Cosh(2. * arg):E16}"
    printfn $"(Math.Cosh({arg}))^2 + (Math.Sinh({arg}))^2 = {coshArg * coshArg + sinhArg * sinhArg:E16}"

// Evaluate hyperbolic identities that are functions of two arguments.
let useTwoArgs argX argY =
    // Evaluate sinh(X + Y) = sinh(X) * cosh(Y) + cosh(X) * sinh(Y).
    printfn $"""
        Math.Sinh({argX}) * Math.Cosh({argY})
        Math.Cosh({argX}) * Math.Sinh({argY}) = {Math.Sinh argX * Math.Cosh argY + Math.Cosh argX * Math.Sinh argY:E16}"""
        
    printfn $"                         Math.Sinh({argX + argY}) = {Math.Sinh(argX + argY):E16}"

    // Evaluate cosh(X + Y) = cosh(X) * cosh(Y) + sinh(X) * sinh(Y).
    printfn
        """Math.Cosh({argX}) * Math.Cosh({argY})
        Math.Sinh({argX}) * Math.Sinh({argY}) = {Math.Cosh argX * Math.Cosh argY + Math.Sinh argX * Math.Sinh argY:E16}"""
        
    printfn $"                         Math.Cosh({argX + argY}) = {Math.Cosh(argX + argY):E16}"

printfn
    """This example of hyperbolic Math.Sinh( double )
and Math.Cosh( double )
generates the following output.

Evaluate these hyperbolic identities with selected values for X:
   cosh^2(X) - sinh^2(X) = 1
   sinh(2 * X) = 2 * sinh(X) * cosh(X)
   cosh(2 * X) = cosh^2(X) + sinh^2(X)"""

useSinhCosh 0.1
useSinhCosh 1.2
useSinhCosh 4.9

printfn "\nEvaluate these hyperbolic identities with selected values for X and Y:"
printfn "   sinh(X + Y) = sinh(X) * cosh(Y) + cosh(X) * sinh(Y)"
printfn "   cosh(X + Y) = cosh(X) * cosh(Y) + sinh(X) * sinh(Y)"

useTwoArgs 0.1 1.2
useTwoArgs 1.2 4.9

// This example of hyperbolic Math.Sinh( double ) and Math.Cosh( double )
// generates the following output.

// Evaluate these hyperbolic identities with selected values for X:
//    cosh^2(X) - sinh^2(X) = 1
//    sinh(2 * X) = 2 * sinh(X) * cosh(X)
//    cosh(2 * X) = cosh^2(X) + sinh^2(X)

//                          Math.Sinh(0.1) = 1.0016675001984403E-001
//                          Math.Cosh(0.1) = 1.0050041680558035E+000
// (Math.Cosh(0.1))^2 - (Math.Sinh(0.1))^2 = 9.9999999999999989E-001
//                          Math.Sinh(0.2) = 2.0133600254109399E-001
//     2 * Math.Sinh(0.1) * Math.Cosh(0.1) = 2.0133600254109396E-001
//                          Math.Cosh(0.2) = 1.0200667556190759E+000
// (Math.Cosh(0.1))^2 + (Math.Sinh(0.1))^2 = 1.0200667556190757E+000

//                          Math.Sinh(1.2) = 1.5094613554121725E+000
//                          Math.Cosh(1.2) = 1.8106555673243747E+000
// (Math.Cosh(1.2))^2 - (Math.Sinh(1.2))^2 = 1.0000000000000000E+000
//                          Math.Sinh(2.4) = 5.4662292136760939E+000
//     2 * Math.Sinh(1.2) * Math.Cosh(1.2) = 5.4662292136760939E+000
//                          Math.Cosh(2.4) = 5.5569471669655064E+000
// (Math.Cosh(1.2))^2 + (Math.Sinh(1.2))^2 = 5.5569471669655064E+000

//                          Math.Sinh(4.9) = 6.7141166550932297E+001
//                          Math.Cosh(4.9) = 6.7148613134003227E+001
// (Math.Cosh(4.9))^2 - (Math.Sinh(4.9))^2 = 1.0000000000000000E+000
//                          Math.Sinh(9.8) = 9.0168724361884615E+003
//     2 * Math.Sinh(4.9) * Math.Cosh(4.9) = 9.0168724361884615E+003
//                          Math.Cosh(9.8) = 9.0168724916400624E+003
// (Math.Cosh(4.9))^2 + (Math.Sinh(4.9))^2 = 9.0168724916400606E+003

// Evaluate these hyperbolic identities with selected values for X and Y:
//    sinh(X + Y) = sinh(X) * cosh(Y) + cosh(X) * sinh(Y)
//    cosh(X + Y) = cosh(X) * cosh(Y) + sinh(X) * sinh(Y)

//         Math.Sinh(0.1) * Math.Cosh(1.2) +
//         Math.Cosh(0.1) * Math.Sinh(1.2) = 1.6983824372926155E+000
//                          Math.Sinh(1.3) = 1.6983824372926160E+000
//         Math.Cosh(0.1) * Math.Cosh(1.2) +
//         Math.Sinh(0.1) * Math.Sinh(1.2) = 1.9709142303266281E+000
//                          Math.Cosh(1.3) = 1.9709142303266285E+000

//         Math.Sinh(1.2) * Math.Cosh(4.9) +
//         Math.Cosh(1.2) * Math.Sinh(4.9) = 2.2292776360739879E+002
//                          Math.Sinh(6.1) = 2.2292776360739885E+002
//         Math.Cosh(1.2) * Math.Cosh(4.9) +
//         Math.Sinh(1.2) * Math.Sinh(4.9) = 2.2293000647511826E+002
//                          Math.Cosh(6.1) = 2.2293000647511832E+002
//</snippet1>