module sincos

//<snippet1>
// Example for the trigonometric Math.Sin( double )
// and Math.Cos( double ) methods.
// In F#, the sin and cos functions may be used instead.
open System

// Evaluate trigonometric identities with a given angle.
let useSineCosine degrees =
    let angle = Math.PI * degrees / 180.
    let sinAngle = Math.Sin angle
    let cosAngle = Math.Cos angle

    // Evaluate sin^2(X) + cos^2(X) = 1.
    printfn $"""
                           Math.Sin({degrees} deg) = {Math.Sin angle:E16}
                           Math.Cos({degrees} deg) = {Math.Cos angle:E16}"""
    printfn $"(Math.Sin({degrees} deg))^2 + (Math.Cos({degrees} deg))^2 = {sinAngle * sinAngle + cosAngle * cosAngle:E16}"

    // Evaluate sin(2 * X) = 2 * sin(X) * cos(X).
    printfn $"                           Math.Sin({2. * degrees} deg) = {Math.Sin(2. * angle):E16}"
    printfn $"    2 * Math.Sin({degrees} deg) * Math.Cos({degrees} deg) = {2. * sinAngle * cosAngle:E16}"

    // Evaluate cos(2 * X) = cos^2(X) - sin^2(X).
    printfn $"                           Math.Cos({2. * degrees} deg) = {Math.Cos(2. * angle):E16}"
    printfn $"(Math.Cos({degrees} deg))^2 - (Math.Sin({degrees} deg))^2 = {cosAngle * cosAngle - sinAngle * sinAngle:E16}"


// Evaluate trigonometric identities that are functions of two angles.
let useTwoAngles degreesX degreesY =
    let angleX = Math.PI * degreesX / 180.
    let angleY = Math.PI * degreesY / 180.

    // Evaluate sin(X + Y) = sin(X) * cos(Y) + cos(X) * sin(Y).
    printfn $"""
        Math.Sin({degreesX} deg) * Math.Cos({degreesY} deg)
        Math.Cos({degreesX} deg) * Math.Sin({degreesY} deg) = {Math.Sin angleX * Math.Cos angleY + Math.Cos angleX * Math.Sin angleY:E16}"""
    printfn $"                           Math.Sin({degreesX + degreesY} deg) = {Math.Sin(angleX + angleY):E16}"

    // Evaluate cos(X + Y) = cos(X) * cos(Y) - sin(X) * sin(Y).
    printfn 
        $"""        Math.Cos({degreesX} deg) * Math.Cos({degreesY} deg) -
        Math.Sin({degreesX} deg) * Math.Sin({degreesY} deg) = {Math.Cos angleX * Math.Cos angleY - Math.Sin angleX * Math.Sin angleY:E16}"""
    printfn $"                           Math.Cos({degreesX + degreesY} deg) = {Math.Cos(angleX + angleY):E16}"

// Evaluate trigonometric identities with a given angle.
let useCombinedSineCosine degrees =
    let angle = Math.PI * degrees / 180.
    let struct(sinAngle, cosAngle) = Math.SinCos angle

    // Evaluate sin^2(X) + cos^2(X) = 1.
    printfn $"\n                           Math.SinCos({degrees} deg) = ({sinAngle:E16}, {cosAngle:E16})"
    printfn $"(double sin, double cos) = Math.SinCos({degrees} deg)"
    printfn $"sin^2 + cos^2 = {sinAngle * sinAngle + cosAngle * cosAngle:E16}"

printfn
    """This example of trigonometric
Math.Sin( double ), Math.Cos( double ), and Math.SinCos( double )
generates the following output.

Convert selected values for X to radians
and evaluate these trigonometric identities:
   sin^2(X) + cos^2(X) = 1\n   sin(2 * X) = 2 * sin(X) * cos(X)
   cos(2 * X) = cos^2(X) - sin^2(X)
   cos(2 * X) = cos^2(X) - sin^2(X)

"""

useSineCosine 15.
useSineCosine 30.
useSineCosine 45.

printfn """
Convert selected values for X and Y to radians
and evaluate these trigonometric identities:
   sin(X + Y) = sin(X) * cos(Y) + cos(X) * sin(Y)
   cos(X + Y) = cos(X) * cos(Y) - sin(X) * sin(Y)
"""

useTwoAngles 15. 30.
useTwoAngles 30. 45.

printfn """
When you have calls to sin(X) and cos(X) they
can be replaced with a single call to sincos(x):"""

useCombinedSineCosine 15.
useCombinedSineCosine 30.
useCombinedSineCosine 45.

// This example of trigonometric Math.Sin( double ) and Math.Cos( double )
// generates the following output.
//
// Convert selected values for X to radians
// and evaluate these trigonometric identities:
//    sin^2(X) + cos^2(X) = 1
//    sin(2 * X) = 2 * sin(X) * cos(X)
//    cos(2 * X) = cos^2(X) - sin^2(X)
//
//                            Math.Sin(15 deg) = 2.5881904510252074E-001
//                            Math.Cos(15 deg) = 9.6592582628906831E-001
// (Math.Sin(15 deg))^2 + (Math.Cos(15 deg))^2 = 1.0000000000000000E+000
//                            Math.Sin(30 deg) = 4.9999999999999994E-001
//     2 * Math.Sin(15 deg) * Math.Cos(15 deg) = 4.9999999999999994E-001
//                            Math.Cos(30 deg) = 8.6602540378443871E-001
// (Math.Cos(15 deg))^2 - (Math.Sin(15 deg))^2 = 8.6602540378443871E-001
//
//                            Math.Sin(30 deg) = 4.9999999999999994E-001
//                            Math.Cos(30 deg) = 8.6602540378443871E-001
// (Math.Sin(30 deg))^2 + (Math.Cos(30 deg))^2 = 1.0000000000000000E+000
//                            Math.Sin(60 deg) = 8.6602540378443860E-001
//     2 * Math.Sin(30 deg) * Math.Cos(30 deg) = 8.6602540378443860E-001
//                            Math.Cos(60 deg) = 5.0000000000000011E-001
// (Math.Cos(30 deg))^2 - (Math.Sin(30 deg))^2 = 5.0000000000000022E-001
//
//                            Math.Sin(45 deg) = 7.0710678118654746E-001
//                            Math.Cos(45 deg) = 7.0710678118654757E-001
// (Math.Sin(45 deg))^2 + (Math.Cos(45 deg))^2 = 1.0000000000000000E+000
//                            Math.Sin(90 deg) = 1.0000000000000000E+000
//     2 * Math.Sin(45 deg) * Math.Cos(45 deg) = 1.0000000000000000E+000
//                            Math.Cos(90 deg) = 6.1230317691118863E-017
// (Math.Cos(45 deg))^2 - (Math.Sin(45 deg))^2 = 2.2204460492503131E-016
//
// Convert selected values for X and Y to radians
// and evaluate these trigonometric identities:
//    sin(X + Y) = sin(X) * cos(Y) + cos(X) * sin(Y)
//    cos(X + Y) = cos(X) * cos(Y) - sin(X) * sin(Y)
//
//         Math.Sin(15 deg) * Math.Cos(30 deg) +
//         Math.Cos(15 deg) * Math.Sin(30 deg) = 7.0710678118654746E-001
//                            Math.Sin(45 deg) = 7.0710678118654746E-001
//         Math.Cos(15 deg) * Math.Cos(30 deg) -
//         Math.Sin(15 deg) * Math.Sin(30 deg) = 7.0710678118654757E-001
//                            Math.Cos(45 deg) = 7.0710678118654757E-001
//
//         Math.Sin(30 deg) * Math.Cos(45 deg) +
//         Math.Cos(30 deg) * Math.Sin(45 deg) = 9.6592582628906831E-001
//                            Math.Sin(75 deg) = 9.6592582628906820E-001
//         Math.Cos(30 deg) * Math.Cos(45 deg) -
//         Math.Sin(30 deg) * Math.Sin(45 deg) = 2.5881904510252085E-001
//                            Math.Cos(75 deg) = 2.5881904510252096E-001
//</snippet1>