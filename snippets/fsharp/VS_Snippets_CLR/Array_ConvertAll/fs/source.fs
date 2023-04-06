// <Snippet1>
open System
open System.Drawing
open System.Collections.Generic

let pointFToPoint (pf: PointF) =
    Point(int pf.X, int pf.Y)

// Create an array of PointF objects.
let apf =
    [| PointF(27.8f, 32.62f)
       PointF(99.3f, 147.273f)
       PointF(7.5f, 1412.2f) |]

// Display each element in the PointF array.
printfn ""
for p in apf do
    printfn $"{p}"

// Convert each PointF element to a Point object.
let ap = Array.ConvertAll(apf, pointFToPoint)
// let ap = Array.map pointFToPoint apf

// Display each element in the Point array.
printfn ""
for p in ap do
    printfn $"{p}"

// This code example produces the following output:
//     {X=27.8, Y=32.62}
//     {X=99.3, Y=147.273}
//     {X=7.5, Y=1412.2}
//
//     {X=27,Y=32}
//     {X=99,Y=147}
//     {X=7,Y=1412}

// </Snippet1>
