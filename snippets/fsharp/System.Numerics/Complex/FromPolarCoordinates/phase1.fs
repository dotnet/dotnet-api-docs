// <Snippet1>
open System
open System.Numerics

let c1 = Complex.FromPolarCoordinates(10., 45. * Math.PI / 180.)
printfn $"{c1}:"
printfn $"   Magnitude: {Complex.Abs(c1)}"
printfn $"   Phase:     {c1.Phase} radians"
printfn $"   Phase      {c1.Phase * 180. / Math.PI} degrees"
printfn $"   Atan(b/a): {Math.Atan(c1.Imaginary / c1.Real)}"
// The example displays the following output:
//       (7.07106781186548, 7.07106781186547):
//          Magnitude: 10
//          Phase:     0.785398163397448 radians
//          Phase      45 degrees
//          Atan(b/a): 0.785398163397448
// </Snippet1>
