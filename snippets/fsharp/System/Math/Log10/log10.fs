// <Snippet1>
open System

let numbers =
    [ -1.; 0; 0.105; 0.5; 0.798; 1; 4; 6.9; 10
      50; 100; 500; 1000; Double.MaxValue ]

for number in numbers do
    // the F# log10 function may be used instead
    printfn $"The base 10 log of {number} is {Math.Log10 number}."
// The example dislays the following output:
//       The base 10 log of -1 is NaN.
//       The base 10 log of 0 is -Infinity.
//       The base 10 log of 0.105 is -0.978810700930062.
//       The base 10 log of 0.5 is -0.301029995663981.
//       The base 10 log of 0.798 is -0.0979971086492706.
//       The base 10 log of 1 is 0.
//       The base 10 log of 4 is 0.602059991327962.
//       The base 10 log of 6.9 is 0.838849090737255.
//       The base 10 log of 10 is 1.
//       The base 10 log of 50 is 1.69897000433602.
//       The base 10 log of 100 is 2.
//       The base 10 log of 500 is 2.69897000433602.
//       The base 10 log of 1000 is 3.
//       The base 10 log of 1.79769313486232E+308 is 308.254715559917.
// </Snippet1>