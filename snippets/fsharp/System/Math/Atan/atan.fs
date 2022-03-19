//<snippet1>
// This example demonstrates Math.Atan()
//                           Math.Atan2()
//                           Math.Tan()
// Functions 'atan', 'atan2', and 'tan' may be used instead. 
open System

[<EntryPoint>]
let main _ =
    let x = 1.
    let y = 2.

    // Calculate the tangent of 30 degrees.
    let angle = 30.
    let radians = angle * (Math.PI / 180.)
    let result = Math.Tan radians
    printfn $"The tangent of 30 degrees is {result}."

    // Calculate the arctangent of the previous tangent.
    let radians = Math.Atan result
    let angle = radians * (180. / Math.PI)
    printfn $"The previous tangent is equivalent to {angle} degrees."

    // Calculate the arctangent of an angle.

    let radians = Math.Atan2(y, x)
    let angle = radians * (180. / Math.PI)

    printfn 
        $"""The arctangent of the angle formed by the x-axis and 
a vector to point ({x},{y}) is {radians},
which is equivalent to {angle} degrees."""
    0

//This example produces the following results:
//     The tangent of 30 degrees is 0.577350269189626.
//     The previous tangent is equivalent to 30 degrees.
//     
//     The arctangent of the angle formed by the x-axis and
//     a vector to point (1,2) is 1.10714871779409,
//     which is equivalent to 63.434948822922 degrees.
//</snippet1>