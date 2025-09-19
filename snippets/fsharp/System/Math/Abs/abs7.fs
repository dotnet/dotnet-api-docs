module abs7

// <Snippet7>
open System

let values = 
    [ Single.MaxValue; 16.354e-12f; 15.098123f; 0f
      -19.069713f; -15.058e17f; Single.MinValue ]

for value in values do
    // The 'abs' function may be used instead.
    printfn $"Abs({value}) = {Math.Abs value}"

// The example displays the following output:
//       Abs(3.402823E+38) = 3.402823E+38
//       Abs(1.6354E-11) = 1.6354E-11
//       Abs(15.09812) = 15.09812
//       Abs(0) = 0
//       Abs(-19.06971) = 19.06971
//       Abs(-1.5058E+18) = 1.5058E+18
//       Abs(-3.402823E+38) = 3.402823E+38
// </Snippet7>