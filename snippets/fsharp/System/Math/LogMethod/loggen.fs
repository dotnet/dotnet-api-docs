module loggen

//<snippet1>
// Example for the Math.Log( double ) and Math.Log( double, double ) methods.
open System

// Evaluate logarithmic identities that are functions of two arguments.
let useBaseAndArg argB argX =
    // Evaluate log(B)[X] == 1 / log(X)[B].
    printfn $"""
                   Math.Log({argX}, {argB}) == {Math.Log(argX, argB):E16}
             1.0 / Math.Log({argB}, {argX}) == {1. / Math.Log(argB, argX):E16}"""

    // Evaluate log(B)[X] == ln[X] / ln[B].
    printfn $"        Math.Log({argX}) / Math.Log({argB}) == {Math.Log argX / Math.Log argB:E16}"

    // Evaluate log(B)[X] == log(B)[e] * ln[X].
    printfn $"Math.Log(Math.E, {argB}) * Math.Log({argX}) == {Math.Log(Math.E, argB) * Math.Log argX:E16}"


printfn
    """This example of Math.Log( double ) and Math.Log( double, double )
generates the following output.

printfn "Evaluate these identities with selected values for X and B (base):"""
printfn "   log(B)[X] == 1 / log(X)[B]"
printfn "   log(B)[X] == ln[X] / ln[B]" 
printfn "   log(B)[X] == log(B)[e] * ln[X]" 

useBaseAndArg 0.1 1.2
useBaseAndArg 1.2 4.9
useBaseAndArg 4.9 9.9
useBaseAndArg 9.9 0.1


// This example of Math.Log( double ) and Math.Log( double, double )
// generates the following output.
//
// Evaluate these identities with selected values for X and B (base):
//    log(B)[X] == 1 / log(X)[B]
//    log(B)[X] == ln[X] / ln[B]
//    log(B)[X] == log(B)[e] * ln[X]
//
//                    Math.Log(1.2, 0.1) == -7.9181246047624818E-002
//              1.0 / Math.Log(0.1, 1.2) == -7.9181246047624818E-002
//         Math.Log(1.2) / Math.Log(0.1) == -7.9181246047624818E-002
// Math.Log(Math.E, 0.1) * Math.Log(1.2) == -7.9181246047624804E-002
//
//                    Math.Log(4.9, 1.2) == 8.7166610085093179E+000
//              1.0 / Math.Log(1.2, 4.9) == 8.7166610085093161E+000
//         Math.Log(4.9) / Math.Log(1.2) == 8.7166610085093179E+000
// Math.Log(Math.E, 1.2) * Math.Log(4.9) == 8.7166610085093179E+000
//
//                    Math.Log(9.9, 4.9) == 1.4425396251981288E+000
//              1.0 / Math.Log(4.9, 9.9) == 1.4425396251981288E+000
//         Math.Log(9.9) / Math.Log(4.9) == 1.4425396251981288E+000
// Math.Log(Math.E, 4.9) * Math.Log(9.9) == 1.4425396251981288E+000
//
//                    Math.Log(0.1, 9.9) == -1.0043839404494075E+000
//              1.0 / Math.Log(9.9, 0.1) == -1.0043839404494075E+000
//         Math.Log(0.1) / Math.Log(9.9) == -1.0043839404494075E+000
// Math.Log(Math.E, 9.9) * Math.Log(0.1) == -1.0043839404494077E+000
//</snippet1>