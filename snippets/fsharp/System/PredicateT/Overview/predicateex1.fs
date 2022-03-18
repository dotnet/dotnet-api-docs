module predicateex1

// <Snippet2>
open System
open System.Drawing

// Create an array of Point structures.
let points = 
    [| Point(100, 200)
       Point(150, 250)
       Point(250, 375)
       Point(275, 395)
       Point(295, 450) |]

// Find the first Point structure for which X times Y
// is greater than 100000.
let first = Array.Find(points, fun x -> x.X * x.Y > 100000)

// Display the first structure found.
printfn $"Found: X = {first.X}, Y = {first.Y}"
// The example displays the following output:
//        Found: X = 275, Y = 395
// </Snippet2>